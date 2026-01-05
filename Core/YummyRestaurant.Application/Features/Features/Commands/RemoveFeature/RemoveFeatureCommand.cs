using MediatR;

namespace YummyRestaurant.Application.Features.Features.Commands.RemoveFeature;

public class RemoveFeatureCommand : IRequest
{
    public int Id { get; set; }

    public RemoveFeatureCommand(int id)
    {
        Id = id;
    }
}
