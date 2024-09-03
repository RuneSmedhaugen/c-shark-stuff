using Microsoft.AspNetCore.Mvc;

namespace RollRadar.FrontEnd
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
