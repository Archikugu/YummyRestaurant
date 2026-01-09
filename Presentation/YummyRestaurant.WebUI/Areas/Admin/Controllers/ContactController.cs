using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using YummyRestaurant.Application.DTOs.ContactDTOs;

namespace YummyRestaurant.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Contact")]
public class ContactController(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : Controller
{
    private readonly string _baseUrl = _configuration["ApiSettings:BaseUrl"]!;

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_baseUrl}/api/Contacts");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
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
    public async Task<IActionResult> Create(CreateContactDto createContactDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createContactDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync($"{_baseUrl}/api/Contacts", stringContent);
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
        var responseMessage = await client.DeleteAsync($"{_baseUrl}/api/Contacts/{id}");
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
        var responseMessage = await client.GetAsync($"{_baseUrl}/api/Contacts/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [Route("Update")]
    [HttpPost]
    public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateContactDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync($"{_baseUrl}/api/Contacts", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
