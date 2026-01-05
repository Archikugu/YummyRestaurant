using MediatR;
using YummyRestaurant.Application.DTOs.FeatureDTOs;

namespace YummyRestaurant.Application.Features.Features.Queries.GetFeatureById;

public class GetFeatureByIdQuery : IRequest<GetByIdFeatureDto>
{
    public int Id { get; set; }

    public GetFeatureByIdQuery(int id)
    {
        Id = id;
    }
}
