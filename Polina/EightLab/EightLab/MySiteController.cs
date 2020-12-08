using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EightLab
{
    public class MySiteController : Controller
    {
        [HttpGet]
        public IActionResult MyPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyTask()
        {
            return View();
        }

        [HttpPost]
        public string GetCountRepeatSymbols(string str)
        {
            var symbolsMassive = str.Split(new char[] { ' ' });
            var statistic = new Dictionary<string, int>();
            foreach (var symbol in symbolsMassive)
            {
                if (statistic.ContainsKey(symbol))
                {
                    statistic[symbol]++;
                }
                else
                {
                    statistic.Add(symbol, 1);
                }
            }
            string response = "";
            foreach (var data in statistic)
            {
                response += data.Key + " - " + data.Value + "; ";
            }
            return response;
        }

        [HttpGet]
        public IActionResult MyTable()
        {
            var list = new List<Bread>();
            list.Add(new Bread
            {
                Id = 1,
                Name = "Сдобная",
                Manufacturer = "СтельмаX",
                Filling = "-"
            });
            list.Add(new Bread
            {
                Id = 2,
                Name = "Слойка",
                Manufacturer = "СтельмаX",
                Filling = "Вишня"
            });
            list.Add(new Bread
            {
                Id = 3,
                Name = "БулкаБургер",
                Manufacturer = "СтельмаX",
                Filling = "Всё подряд"
            });
            return View(list);
        }

        [HttpPost]
        public IActionResult AddBread(string name, string manufacturer, string genre)
        {
            //Add
            return StatusCode(200);
        }

        [HttpPost]
        public IActionResult EditBread(string name, string manufacturer, string genre)
        {
            //Edit
            return StatusCode(200);
        }

        [HttpPost]
        public IActionResult DeleteBread(string name, string manufacturer)
        {
            //Delete
            return StatusCode(200);
        }
    }
}