using System.ComponentModel.DataAnnotations;

namespace YummyRestaurant.WebUI.Areas.Admin.Models;

public class ProfileViewModel
{
    [Required(ErrorMessage = "Ad alanı gereklidir.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Soyad alanı gereklidir.")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "Email alanı gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string? CurrentPassword { get; set; }

    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
    public string? NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor.")]
    public string? ConfirmNewPassword { get; set; }
}
