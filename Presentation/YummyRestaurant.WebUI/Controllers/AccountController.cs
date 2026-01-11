using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Domain.Entities;
using YummyRestaurant.WebUI.Models;

namespace YummyRestaurant.WebUI.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            ModelState.AddModelError("", "Invalid login attempt.");
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }


    public IActionResult AccessDenied()
    {
        return View();
    }
}
