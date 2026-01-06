using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.ViewComponents.DefaultComponents
{
    public class DefaultBookATableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
