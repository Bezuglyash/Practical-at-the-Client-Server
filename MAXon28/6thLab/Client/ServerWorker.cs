using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    static class ServerWorker
    {
        private static Socket _client;

        public static string Connect(string request)
        {
            IPEndPoint tcpEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),12345);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(tcpEndPoint);

            NetworkStream networkStream = new NetworkStream(client);
            BinaryWriter writer = new BinaryWriter(networkStream);

            writer.Write(request);
            writer.Flush();

            var reader = new BinaryReader(networkStream);
            string stringRequest = reader.ReadString();
            if (stringRequest == "1")
            {
                _client = client;
                return stringRequest;
            }

            client.Shutdown(SocketShutdown.Both);
            client.Close();
            return stringRequest;
        }

        public static string Get(int[] numbers)
        {
            NetworkStream networkStream = new NetworkStream(_client);
            BinaryWriter writer = new BinaryWriter(networkStream);

            writer.Write("Get max numbers");
            writer.Flush();

            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(networkStream, numbers);

            BinaryReader reader = new BinaryReader(networkStream);
            return reader.ReadString();
        }
    }
}