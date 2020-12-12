using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SeventhLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string str)
        {
            if (str != null)
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
                ViewData["Response"] = response;
            }
            return View();
        }
    }
}