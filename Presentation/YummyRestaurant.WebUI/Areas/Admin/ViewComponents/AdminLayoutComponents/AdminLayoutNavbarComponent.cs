using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyRestaurant.Application.DTOs.MessageDTOs;
using YummyRestaurant.Application.DTOs.NotificationDTOs;

namespace YummyRestaurant.WebUI.Areas.Admin.ViewComponents.AdminLayoutComponents
{
    public class AdminLayoutNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
