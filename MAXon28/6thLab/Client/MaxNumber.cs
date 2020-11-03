using System;
using System.Collections.Generic;
using System.Linq;

namespace Client
{
    class MaxNumber : IResult
    {
        private int[] _numbers;

        public MaxNumber(string stringNumbers)
        {
            string[] numbers = (from str in stringNumbers.Split(new char[] { ' ', ',', ';' }).ToList()
                                where str != ""
                                select str).ToArray();
            _numbers = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                _numbers[i] = Convert.ToInt32(numbers[i]);
            }
        }

        public MaxNumber(int[] numbers)
        {
            _numbers = numbers;
        }

        public MaxNumber(List<int> numbers)
        {
            _numbers = numbers.ToArray();
        }

        public string GetResult()
        {
            return ServerWorker.Get(_numbers);
        }
    }
}