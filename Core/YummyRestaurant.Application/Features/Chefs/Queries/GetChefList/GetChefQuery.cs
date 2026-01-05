using MediatR;
using YummyRestaurant.Application.DTOs.ChefDTOs;

namespace YummyRestaurant.Application.Features.Chefs.Queries.GetChefList;

public class GetChefQuery : IRequest<List<ResultChefDto>>
{
}
