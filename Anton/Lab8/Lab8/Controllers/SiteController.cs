using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    public class SiteController : Controller
    {
        [HttpGet]
        public IActionResult StaticPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Mission()
        {
            return View();
        }

        [HttpPost]
        public string GetGreatestCommonDivisor(string stringNumbers)
        {
            string[] stringNumbersMassive = stringNumbers.Split(new char[] { ' ' });
            var numbers = new int[stringNumbersMassive.Length];
            for (int i = 0; i < stringNumbersMassive.Length; i++)
            {
                numbers[i] = Convert.ToInt32(stringNumbersMassive[i]);
            }
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
            return (firstNumber + secondNumber).ToString();
        }

        [HttpGet]
        public IActionResult Books()
        {
            var listBooks = new List<Book>();
            listBooks.Add(new Book
            {
                Id = 1,
                Name = "Дубровский",
                Author = "А. С. Пушкин",
                Genre = "Роман"
            });
            listBooks.Add(new Book
            {
                Id = 2,
                Name = "Тарас Бульба",
                Author = "Н. В. Гоголь",
                Genre = "Повесть"
            });
            listBooks.Add(new Book
            {
                Id = 3,
                Name = "Дети капитана Гранта",
                Author = "Ж. Верн",
                Genre = "Приключенческий роман"
            });
            return View(listBooks);
        }

        [HttpPost]
        public IActionResult AddBook(string name, string author, string genre)
        {
            //Add
            return StatusCode(200);
        }

        [HttpPost]
        public IActionResult EditBook(string name, string author, string genre)
        {
            //Edit
            return StatusCode(200);
        }

        [HttpPost]
        public IActionResult DeleteBook(string name, string author)
        {
            //Delete
            return StatusCode(200);
        }
    }
}