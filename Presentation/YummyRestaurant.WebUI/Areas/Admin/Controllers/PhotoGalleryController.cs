using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;

namespace YummyRestaurant.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/PhotoGallery")]
public class PhotoGalleryController(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : Controller
{
    private readonly string _baseUrl = _configuration["ApiSettings:BaseUrl"]!;

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_baseUrl}/api/PhotoGalleries");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultPhotoGalleryDto>>(jsonData);
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
    public async Task<IActionResult> Create(CreatePhotoGalleryDto createPhotoGalleryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createPhotoGalleryDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync($"{_baseUrl}/api/PhotoGalleries", stringContent);
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
        var responseMessage = await client.DeleteAsync($"{_baseUrl}/api/PhotoGalleries/{id}");
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
        var responseMessage = await client.GetAsync($"{_baseUrl}/api/PhotoGalleries/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdatePhotoGalleryDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [Route("Update")]
    [HttpPost]
    public async Task<IActionResult> Update(UpdatePhotoGalleryDto updatePhotoGalleryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updatePhotoGalleryDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync($"{_baseUrl}/api/PhotoGalleries", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
