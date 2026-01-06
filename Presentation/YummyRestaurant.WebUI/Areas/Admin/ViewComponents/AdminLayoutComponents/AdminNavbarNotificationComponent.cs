using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyRestaurant.Application.DTOs.NotificationDTOs;

namespace YummyRestaurant.WebUI.Areas.Admin.ViewComponents.AdminLayoutComponents
{
    public class AdminNavbarNotificationComponent(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            
            var response = await client.GetAsync($"{baseUrl}/api/Notifications/filter/false");
            List<ResultNotificationDto> values = new();

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData) ?? new();
            }

            return View(values);
        }
    }
}
