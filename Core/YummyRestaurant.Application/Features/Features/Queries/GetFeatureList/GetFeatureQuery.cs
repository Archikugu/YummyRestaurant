using MediatR;
using YummyRestaurant.Application.DTOs.FeatureDTOs;

namespace YummyRestaurant.Application.Features.Features.Queries.GetFeatureList;

public class GetFeatureQuery : IRequest<List<ResultFeatureDto>>
{
}
