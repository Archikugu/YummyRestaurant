using MediatR;

namespace YummyRestaurant.Application.Features.Chefs.Commands.RemoveChef;

public class RemoveChefCommand : IRequest
{
    public int Id { get; set; }

    public RemoveChefCommand(int id)
    {
        Id = id;
    }
}
