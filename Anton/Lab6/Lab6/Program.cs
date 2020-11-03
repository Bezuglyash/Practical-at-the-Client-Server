using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        private static GreatestCommonDivisor greatest;

        static void Main(string[] args)
        {
            Console.WriteLine("Требуется ввести два целых числа вручную! 1 - ввод в строчку, 2 - ввод в массив, 3 - ввод в список. Ваш ответ:");
            switch (Console.ReadLine())
            {
                case "1":
                    SetString();
                    break;
                case "2":
                    SetMassive();
                    break;
                case "3":
                    SetList();
                    break;
                default:
                    return;
            }
            Console.WriteLine(greatest.GetResult());
            Console.Read();
        }

        private static void SetString()
        {
            Console.WriteLine("Введите через пробел два числа:");
            greatest = new GreatestCommonDivisor(Console.ReadLine());
        }

        private static void SetMassive()
        {
            int[] numbers = new int[2];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Введите " + i + 1 + " число: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            greatest = new GreatestCommonDivisor(numbers);
        }

        private static void SetList()
        {
            var list = new List<int>();
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Введите " + i + 1 + " число: ");
                list.Add(Convert.ToInt32(Console.ReadLine()));
            }
            greatest = new GreatestCommonDivisor(list);
        }
    }
}