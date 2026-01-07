using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyRestaurant.Application.DTOs.CategoryDTOs;
using YummyRestaurant.Application.DTOs.ProductDTOs;
using YummyRestaurant.WebUI.Models;

namespace YummyRestaurant.WebUI.ViewComponents.DefaultComponents
{
    public class DefaultMenuViewComponent(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _configuration["ApiSettings:BaseUrl"];

            // Fetch Categories
            var categoriesResponse = await client.GetAsync($"{baseUrl}/api/Categories");
            var productsResponse = await client.GetAsync($"{baseUrl}/api/Products");

            if (categoriesResponse.IsSuccessStatusCode && productsResponse.IsSuccessStatusCode)
            {
                var categoriesJson = await categoriesResponse.Content.ReadAsStringAsync();
                var productsJson = await productsResponse.Content.ReadAsStringAsync();

                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoriesJson);
                var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productsJson);

                var viewModel = new MenuViewModel
                {
                    Categories = categories?.Where(x => x.IsActive).ToList() ?? [],
                    Products = products?.Where(x => x.IsActive).ToList() ?? []
                };

                return View(viewModel);
            }
            return View();
        }
    }
}
