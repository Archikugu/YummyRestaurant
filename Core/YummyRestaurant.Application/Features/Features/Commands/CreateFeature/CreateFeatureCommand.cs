using MediatR;
using YummyRestaurant.Application.DTOs.FeatureDTOs;

namespace YummyRestaurant.Application.Features.Features.Commands.CreateFeature;

public class CreateFeatureCommand : IRequest
{
    public CreateFeatureDto CreateFeatureDto { get; set; }

    public CreateFeatureCommand(CreateFeatureDto createFeatureDto)
    {
        CreateFeatureDto = createFeatureDto;
    }
}
