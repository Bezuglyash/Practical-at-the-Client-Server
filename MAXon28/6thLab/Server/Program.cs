using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Server
{
    class Program
    {
        private static Socket _client;

        static void Main(string[] args)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Bind(ipPoint);
                server.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    Socket client = server.Accept();
                    var networkStream = new NetworkStream(client);
                    var reader = new BinaryReader(networkStream);
                    var writer = new BinaryWriter(networkStream);
                    var str = reader.ReadString();
                    Console.WriteLine("Клиент подключился!");
                    if (str == "1")
                    {
                        _client = client;
                        writer.Write(str);

                        Thread thread = new Thread(Process);
                        thread.Start();
                    }
                    else
                    {
                        writer.Write(str);
                        Console.WriteLine("Соединение разорвано!");
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    }
                    writer.Flush();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Соединение разорвано!");
            }
        }

        private static void Process()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        var networkStream = new NetworkStream(_client);
                        var reader = new BinaryReader(networkStream);
                        if (reader.ReadString() == "Get max numbers")
                        {
                            Console.WriteLine("Получен массив чисел!");
                            IFormatter formatter = new BinaryFormatter();
                            var numbers = (int[])formatter.Deserialize(networkStream);
                            var writer = new BinaryWriter(networkStream);
                            writer.Write(GetMax(numbers).ToString());
                            writer.Flush();
                            Console.WriteLine("Ответ отправлен!");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Соединение разорвано!");
                        _client.Shutdown(SocketShutdown.Both);
                        _client.Close();
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Соединение разорвано!");
                _client.Shutdown(SocketShutdown.Both);
                _client.Close();
            }
        }

        private static int GetMax(int[] numbers)
        {
            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;
        }
    }
}