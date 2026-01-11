using YummyRestaurant.Domain.Entities;
using YummyRestaurant.Application.DTOs.Auth;

namespace YummyRestaurant.Application.Interfaces;

public interface IJwtService
{
    TokenResponseDto GenerateToken(AppUser user);
}
