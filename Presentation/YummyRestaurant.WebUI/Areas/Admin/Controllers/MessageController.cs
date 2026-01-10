using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyRestaurant.Application.DTOs.MessageDTOs;

namespace YummyRestaurant.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Message")]
public class MessageController(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : Controller
{
    private readonly string _baseUrl = _configuration["ApiSettings:BaseUrl"]!;

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_baseUrl}/api/Messages");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"{_baseUrl}/api/Messages/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [Route("MessageStatusRead/{id}")]
    public async Task<IActionResult> MessageStatusRead(int id)
    {
        var client = _httpClientFactory.CreateClient();
        await client.GetAsync($"{_baseUrl}/api/Messages/MessageStatusRead/{id}");
        return RedirectToAction("Index");
    }
}
