using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.ViewComponents.DefaultComponents
{
    public class DefaultEventsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
