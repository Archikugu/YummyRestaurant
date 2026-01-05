using MediatR;
using YummyRestaurant.Application.DTOs.ServiceDTOs;

namespace YummyRestaurant.Application.Features.Services.Queries.GetServiceById;

public class GetServiceByIdQuery : IRequest<GetByIdServiceDto>
{
    public int Id { get; set; }

    public GetServiceByIdQuery(int id)
    {
        Id = id;
    }
}
