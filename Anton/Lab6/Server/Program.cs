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
        private static Socket client;

        static void Main(string[] args)
        {
            IPEndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Bind(point);
                server.Listen(10);
                Console.WriteLine("Сервер запущен!");
                while (true)
                {
                    client = server.Accept();
                    NetworkStream networkStream = new NetworkStream(client);
                    IFormatter formatter = new BinaryFormatter();
                    int[] numbers = (int[])formatter.Deserialize(networkStream);
                    Console.WriteLine("Клиент подключился!");
                    formatter.Serialize(networkStream, numbers);
                    new Thread(Listen).Start();
                }
            }
            catch
            {
                Console.WriteLine("Соединение разорвано!");
            }
        }

        private static void Listen()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        NetworkStream networkStream = new NetworkStream(client);
                        BinaryReader reader = new BinaryReader(networkStream);
                        if (reader.ReadString() == "Наибольший общий делитель")
                        {
                            IFormatter formatter = new BinaryFormatter();
                            int[] numbers = (int[])formatter.Deserialize(networkStream);
                            Console.WriteLine(numbers[0] + " " + numbers[1]);
                            BinaryWriter writer = new BinaryWriter(networkStream);
                            writer.Write(GetGreatestCommonDivisor(numbers).ToString());
                            writer.Flush();
                            Console.WriteLine("Ответ отправлен!");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Соединение разорвано!");
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                        break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Соединение разорвано!");
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }

        private static int GetGreatestCommonDivisor(int[] numbers)
        {
            int firstNumber = numbers[0];
            int secondNumber = numbers[1];
            while (firstNumber != 0 && secondNumber != 0)
            {
                if (firstNumber > secondNumber)
                {
                    firstNumber = firstNumber % secondNumber;
                }
                else
                {
                    secondNumber = secondNumber % firstNumber;
                }
            }
            return firstNumber + secondNumber;
        }
    }
}