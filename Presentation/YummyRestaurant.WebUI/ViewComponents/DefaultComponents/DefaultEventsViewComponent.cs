using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using YummyRestaurant.Application.DTOs.RestaurantEventDTOs;

namespace YummyRestaurant.WebUI.ViewComponents.DefaultComponents
{
    public class DefaultEventsViewComponent(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var responseMessage = await client.GetAsync($"{baseUrl}/api/RestaurantEvents");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRestaurantEventDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
