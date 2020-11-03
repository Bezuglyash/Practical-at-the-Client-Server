using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace _7thLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string stringNumbers)
        {
            if (stringNumbers != null)
            {
                string[] numbers = (from str in stringNumbers.Split(new char[] { ' ', ',', ';' }).ToList()
                    where str != ""
                    select str).ToArray();
                int[] digits = new int[numbers.Length];
                for (int i = 0; i < digits.Length; i++)
                {
                    digits[i] = Convert.ToInt32(numbers[i]);
                }
                int max = digits[0];
                for (int i = 1; i < digits.Length; i++)
                {
                    if (digits[i] > max)
                    {
                        max = digits[i];
                    }
                }
                ViewData["Response"] = max;
            }
            return View();
        }
    }
}