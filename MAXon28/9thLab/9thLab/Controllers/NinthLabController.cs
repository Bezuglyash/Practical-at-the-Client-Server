using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9thLab.Models;
using _9thLab.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _9thLab.Controllers
{
    public class NinthLabController : Controller
    {
        private CarRepository _carRepository;

        public NinthLabController(CarRepository carRepository)
        {
            _carRepository = carRepository;
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
            return View(_carRepository.GetCars());
        }

        [HttpPost]
        public async Task<int> AddCar(string name, string model, int price)
        {
            return await _carRepository.AddCarAsync(name, model, price);
        }

        [HttpPost]
        public async Task<IActionResult> EditCar(int currentId, string name, string model, int price)
        {
            await _carRepository.UpdateCarAsync(currentId, name, model, price);
            return StatusCode(200);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carRepository.DeleteCarAsync(id);
            return StatusCode(200);
        }
    }
}