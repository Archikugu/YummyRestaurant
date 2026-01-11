using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using YummyRestaurant.Application.DTOs.BookingDTOs;

namespace YummyRestaurant.WebUI.Areas.Admin.Controllers;

[Route("Admin/[controller]")]
public class BookingController(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : AdminBaseController
{
    private readonly string _baseUrl = _configuration["ApiSettings:BaseUrl"]!;

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_baseUrl}/api/Bookings");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
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
    public async Task<IActionResult> Create(CreateBookingDto createBookingDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBookingDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync($"{_baseUrl}/api/Bookings", stringContent);
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
        var responseMessage = await client.DeleteAsync($"{_baseUrl}/api/Bookings/{id}");
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
        var responseMessage = await client.GetAsync($"{_baseUrl}/api/Bookings/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [Route("Update")]
    [HttpPost]
    public async Task<IActionResult> Update(UpdateBookingDto updateBookingDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateBookingDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync($"{_baseUrl}/api/Bookings", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [Route("BookingStatusApproved/{id}")]
    public async Task<IActionResult> BookingStatusApproved(int id)
    {
        var client = _httpClientFactory.CreateClient();
        string name = await GetBookingNameAsync(id, client);

        await client.GetAsync($"{_baseUrl}/api/Bookings/BookingStatusApproved/{id}");
        TempData["ToastrSuccess"] = $"{name} adlı kişinin rezervasyonu onaylandı!";
        return RedirectToAction("Index");
    }

    [Route("BookingStatusCancelled/{id}")]
    public async Task<IActionResult> BookingStatusCancelled(int id)
    {
        var client = _httpClientFactory.CreateClient();
        string name = await GetBookingNameAsync(id, client);

        await client.GetAsync($"{_baseUrl}/api/Bookings/BookingStatusCancelled/{id}");
        TempData["ToastrError"] = $"{name} adlı kişinin rezervasyonu reddedildi!";
        return RedirectToAction("Index");
    }

    private async Task<string> GetBookingNameAsync(int id, HttpClient client)
    {
        string name = "Müşteri";
        var getResponse = await client.GetAsync($"{_baseUrl}/api/Bookings/{id}");
        if (getResponse.IsSuccessStatusCode)
        {
            var jsonData = await getResponse.Content.ReadAsStringAsync();
            var booking = JsonConvert.DeserializeObject<GetByIdBookingDto>(jsonData);
            if (booking != null)
            {
                name = $"{booking.FirstName} {booking.LastName}";
            }
        }
        return name;
    }
}
