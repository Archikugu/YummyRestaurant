using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.Areas.Admin.ViewComponents.AdminLayoutComponents
{
    public class AdminLayoutSidebarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
