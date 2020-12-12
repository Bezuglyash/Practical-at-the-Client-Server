using Microsoft.AspNetCore.Mvc;

namespace _10thLab.Controllers
{
    public class TenthLabController : Controller
    {
        public IActionResult AboutMe()
        {
            return View();
        }
    }
}