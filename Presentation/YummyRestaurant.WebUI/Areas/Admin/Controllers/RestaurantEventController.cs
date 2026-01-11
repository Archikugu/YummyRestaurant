using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using YummyRestaurant.Application.DTOs.RestaurantEventDTOs;

namespace YummyRestaurant.WebUI.Areas.Admin.Controllers;

[Route("Admin/[controller]")]
public class RestaurantEventController(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : AdminBaseController
{
    private readonly string _baseUrl = _configuration["ApiSettings:BaseUrl"]!;

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_baseUrl}/api/RestaurantEvents");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultRestaurantEventDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [Route("Create")]
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [Route("Create")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateRestaurantEventDto createRestaurantEventDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createRestaurantEventDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync($"{_baseUrl}/api/RestaurantEvents", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"{_baseUrl}/api/RestaurantEvents/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [Route("Update/{id}")]
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_baseUrl}/api/RestaurantEvents/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateRestaurantEventDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [Route("Update/{id}")]
    [HttpPost]
    public async Task<IActionResult> Update(UpdateRestaurantEventDto updateRestaurantEventDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateRestaurantEventDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync($"{_baseUrl}/api/RestaurantEvents", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
