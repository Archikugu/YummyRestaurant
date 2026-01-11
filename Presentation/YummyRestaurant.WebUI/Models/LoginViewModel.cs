using System.ComponentModel.DataAnnotations;

namespace YummyRestaurant.WebUI.Models;

public class LoginViewModel
{
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
}
