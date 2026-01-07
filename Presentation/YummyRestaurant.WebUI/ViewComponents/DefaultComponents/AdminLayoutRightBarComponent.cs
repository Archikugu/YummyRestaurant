using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.ViewComponents.DefaultComponents
{
    public class AdminLayoutRightBarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
