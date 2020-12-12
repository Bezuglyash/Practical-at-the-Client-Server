using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TenthLab.Controllers
{
    public class MySiteController : Controller
    {
        private BreadDbWorker _breadDb;

        public MySiteController(BreadDbWorker breadDb)
        {
            _breadDb = breadDb;
        }

        public IActionResult GetMenu()
        {
            return PartialView("Menu");
        }

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
            return View(_breadDb.GetBreads());
        }

        [HttpPost]
        public async Task<int> AddBread(string name, string manufacturer, string filling)
        {
            return await _breadDb.AddBreadAsync(name, manufacturer, filling);
        }

        [HttpPost]
        public async Task<IActionResult> EditBread(int currentId, string name, string manufacturer, string filling)
        {
            await _breadDb.UpdateBreadAsync(currentId, name, manufacturer, filling);
            return StatusCode(200);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBread(int id)
        {
            await _breadDb.DeleteBreadAsync(id);
            return StatusCode(200);
        }
    }
}