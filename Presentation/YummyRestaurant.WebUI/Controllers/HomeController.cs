using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.WebUI.Models;

using Newtonsoft.Json;
using System.Text;
using YummyRestaurant.Application.DTOs.BookingDTOs;

namespace YummyRestaurant.WebUI.Controllers;

public class HomeController(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : Controller
{
    private readonly string _baseUrl = _configuration["ApiSettings:BaseUrl"]!;

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> BookTable(CreateBookingDto createBookingDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBookingDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync($"{_baseUrl}/api/Bookings", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            TempData["ToastrSuccess"] = "Rezervasyonunuz başarıyla alındı!";
            return RedirectToAction("Index");
        }
        TempData["ToastrError"] = "Rezervasyon oluşturulurken bir hata oluştu.";
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
