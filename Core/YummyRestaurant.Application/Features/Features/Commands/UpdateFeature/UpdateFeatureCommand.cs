using MediatR;
using YummyRestaurant.Application.DTOs.FeatureDTOs;

namespace YummyRestaurant.Application.Features.Features.Commands.UpdateFeature;

public class UpdateFeatureCommand : IRequest
{
    public UpdateFeatureDto UpdateFeatureDto { get; set; }

    public UpdateFeatureCommand(UpdateFeatureDto updateFeatureDto)
    {
        UpdateFeatureDto = updateFeatureDto;
    }
}
