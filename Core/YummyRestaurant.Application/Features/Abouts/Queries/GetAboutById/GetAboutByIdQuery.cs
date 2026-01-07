using MediatR;
using YummyRestaurant.Application.DTOs.AboutDTOs;

namespace YummyRestaurant.Application.Features.Abouts.Queries.GetAboutById;

public class GetAboutByIdQuery(int id) : IRequest<GetByIdAboutDto>
{
    public int Id { get; set; } = id;
}
