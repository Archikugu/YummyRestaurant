using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.ViewComponents.DefaultComponents
{
    public class DefaultStatsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
