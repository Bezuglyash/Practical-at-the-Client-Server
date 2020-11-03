using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Controllers
{
    public class GreatestCommonDivisorController : Controller
    {
        public IActionResult Index(string request)
        {
            if (request != null)
            {
                string[] numbers = request.Split(new char[] { ' ' });
                int[] digits = new int[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    digits[i] = Convert.ToInt32(numbers[i]);
                }
                int firstNumber = digits[0];
                int secondNumber = digits[1];
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
                ViewData["Response"] = firstNumber + secondNumber;
            }
            return View();
        }
    }
}