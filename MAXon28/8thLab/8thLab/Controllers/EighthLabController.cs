using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using _8thLab.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _8thLab.Controllers
{
    public class EighthLabController : Controller
    {
        public EighthLabController()
        {

        }

        [HttpGet]
        public IActionResult AboutMe()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IndividualTask()
        {
            return View();
        }

        [HttpPost]
        public string MaxValue(string stringNumbers)
        {
            string[] numbers = (from str in stringNumbers.Split(new char[] { ' ', ',', ';' }).ToList()
                where str != ""
                select str).ToArray();
            try
            {
                string max = numbers[0];
                for (int i = 1; i < numbers.Length; i++)
                {
                    if (Convert.ToInt32(numbers[i]) > Convert.ToInt32(max))
                    {
                        max = numbers[i];
                    }
                }
                return max;
            }
            catch
            {
                return "null";
            }
        }

        [HttpGet]
        public IActionResult Table()
        {
            var cars = new List<CarViewModel>();
            cars.Add(new CarViewModel
            {
                Id = 1,
                Name = "BMW",
                Model = "X6",
                Price = 5728000
            });
            cars.Add(new CarViewModel
            {
                Id = 2,
                Name = "BMW",
                Model = "M5",
                Price = 3128000
            });
            cars.Add(new CarViewModel
            {
                Id = 3,
                Name = "Volkswagen",
                Model = "Jetta",
                Price = 1328000
            });
            return View(cars);
        }

        [HttpPost]
        public IActionResult AddCar(string name, string model, int price)
        {
            //Add
            return StatusCode(200);
        }

        [HttpPost]
        public IActionResult EditCar(string name, string model, int price)
        {
            //Edit
            return StatusCode(200);
        }

        [HttpPost]
        public IActionResult DeleteCar(string name, string model)
        {
            //Delete
            return StatusCode(200);
        }
    }
}