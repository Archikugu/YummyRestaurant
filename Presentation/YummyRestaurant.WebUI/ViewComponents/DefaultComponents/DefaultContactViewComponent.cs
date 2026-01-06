using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyRestaurant.Application.DTOs.ContactDTOs;

namespace YummyRestaurant.WebUI.ViewComponents.DefaultComponents
{
    public class DefaultContactViewComponent(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var responseMessage = await client.GetAsync($"{baseUrl}/api/Contacts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values.FirstOrDefault()); // Return the first contact or null
            }
            return View();
        }
    }
}
