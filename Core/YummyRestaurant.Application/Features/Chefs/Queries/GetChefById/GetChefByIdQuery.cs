using MediatR;
using YummyRestaurant.Application.DTOs.ChefDTOs;

namespace YummyRestaurant.Application.Features.Chefs.Queries.GetChefById;

public class GetChefByIdQuery : IRequest<GetByIdChefDto>
{
    public int Id { get; set; }

    public GetChefByIdQuery(int id)
    {
        Id = id;
    }
}
