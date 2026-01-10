using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.ViewComponents.DefaultComponents;

public class DefaultMessageViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
