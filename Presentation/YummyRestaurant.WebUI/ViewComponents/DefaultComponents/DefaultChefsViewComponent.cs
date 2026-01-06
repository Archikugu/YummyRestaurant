using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyRestaurant.Application.DTOs.ChefDTOs;

namespace YummyRestaurant.WebUI.ViewComponents.DefaultComponents
{
    public class DefaultChefsViewComponent(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var responseMessage = await client.GetAsync($"{baseUrl}/api/Chefs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultChefDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
