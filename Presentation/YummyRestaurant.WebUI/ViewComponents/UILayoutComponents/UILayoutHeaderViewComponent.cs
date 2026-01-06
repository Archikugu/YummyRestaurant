using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.ViewComponents.UILayoutComponents
{
    public class UILayoutHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
