using Microsoft.AspNetCore.Mvc;

namespace safaei.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
