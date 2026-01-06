using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.Areas.Admin.ViewComponents.AdminLayoutComponents
{
    public class AdminLayoutFooterComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
