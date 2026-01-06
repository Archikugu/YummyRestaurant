using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;

namespace YummyRestaurant.WebUI.ViewComponents.DefaultComponents
{
    public class DefaultGalleryViewComponent(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var responseMessage = await client.GetAsync($"{baseUrl}/api/PhotoGalleries");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPhotoGalleryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
