namespace YummyRestaurant.Application.DTOs.Auth;

public class TokenResponseDto
{
    public string? Token { get; set; }
    public DateTime Expiration { get; set; }
}
