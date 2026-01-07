using MediatR;
using YummyRestaurant.Application.DTOs.AboutDTOs;

namespace YummyRestaurant.Application.Features.Abouts.Queries.GetAboutList;

public class GetAboutListQuery : IRequest<List<ResultAboutDto>>
{
}
