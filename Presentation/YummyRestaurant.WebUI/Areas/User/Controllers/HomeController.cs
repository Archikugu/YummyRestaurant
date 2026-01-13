using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
