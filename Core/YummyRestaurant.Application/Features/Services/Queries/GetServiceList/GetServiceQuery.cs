using MediatR;
using YummyRestaurant.Application.DTOs.ServiceDTOs;

namespace YummyRestaurant.Application.Features.Services.Queries.GetServiceList;

public class GetServiceQuery : IRequest<List<ResultServiceDto>>
{
}
