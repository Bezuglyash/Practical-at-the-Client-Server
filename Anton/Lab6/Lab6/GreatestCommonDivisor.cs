using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class GreatestCommonDivisor : IResultable
    {
        private Socket client;
        private int[] numbers;

        public GreatestCommonDivisor(string stringNumbers)
        {
            string[] numbers = stringNumbers.Split(new char[] { ' ' });
            this.numbers = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                this.numbers[i] = Convert.ToInt32(numbers[i]);
            }
            Connect();
        }

        public GreatestCommonDivisor(int[] numbers)
        {
            this.numbers = numbers;
            Connect();
        }

        public GreatestCommonDivisor(List<int> digits)
        {
            numbers = new int [digits.Count];
            for (int i = 0; i < digits.Count; i++)
            {
                numbers[i] = digits[i];
            }
            Connect();
        }

        public string GetResult()
        {
            NetworkStream networkStream = new NetworkStream(client);
            BinaryWriter writer = new BinaryWriter(networkStream);

            writer.Write("Наибольший общий делитель");
            writer.Flush();

            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(networkStream, numbers);

            BinaryReader reader = new BinaryReader(networkStream);
            return reader.ReadString();
        }

        private void Connect()
        {
            IPEndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(point);

            NetworkStream networkStream = new NetworkStream(client);

            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(networkStream, numbers);

            numbers = (int[])formatter.Deserialize(networkStream);

            Console.WriteLine(numbers[0] + " " + numbers[1]);
        }
    }
}