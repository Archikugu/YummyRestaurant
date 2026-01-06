using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyRestaurant.Application.DTOs.MessageDTOs;

namespace YummyRestaurant.WebUI.Areas.Admin.ViewComponents.AdminLayoutComponents
{
    public class AdminNavbarMessageComponent(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            
            var response = await client.GetAsync($"{baseUrl}/api/Messages/filter/false");
            List<ResultMessageDto> values = new();

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData) ?? new();
            }

            return View(values);
        }
    }
}
