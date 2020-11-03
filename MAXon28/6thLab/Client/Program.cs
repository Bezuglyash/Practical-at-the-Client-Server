using System;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        private static MaxNumber _maxNumber;

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите 1, чтобы подключиться к серверу для работы с поиском максимального числа.");
            string response = ServerWorker.Connect(Console.ReadLine());
            if (response == "1")
            {
                Console.WriteLine(response);
                Console.WriteLine("Требуется ввести несколько целых чисел вручную. 1 - строкой, 2 - массивом, 3 - списком. Ваш вариант:");
                switch (Console.ReadLine())
                {
                    case "1":
                        SetStringNumbers();
                        break;
                    case "2":
                        SetMassiveNumbers();
                        break;
                    case "3":
                        SetListNumbers();
                        break;
                    default:
                        return;
                }
                Console.WriteLine(_maxNumber.GetResult());
                Console.Read();
            }
            else
            {
                Console.WriteLine(response);
                Console.Read();
            }
        }

        private static void SetStringNumbers()
        {
            Console.WriteLine("Введите через запятую, пробел или точку с запятой набор чисел: ");
            _maxNumber = new MaxNumber(Console.ReadLine());
        }

        private static void SetMassiveNumbers()
        {
            Console.WriteLine("Введите количество чисел: ");
            int[] numbers = new int [Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Введите {i + 1} число: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            _maxNumber = new MaxNumber(numbers);
        }

        private static void SetListNumbers()
        {
            Console.WriteLine("Введите количество чисел: ");
            int count = Convert.ToInt32(Console.ReadLine());
            var list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введите {i + 1} число: ");
                list.Add(Convert.ToInt32(Console.ReadLine()));
            }
            _maxNumber = new MaxNumber(list);
        }
    }
}