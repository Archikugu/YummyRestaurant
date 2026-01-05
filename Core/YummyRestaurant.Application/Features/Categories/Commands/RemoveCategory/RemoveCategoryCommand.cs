using MediatR;

namespace YummyRestaurant.Application.Features.Categories.Commands.RemoveCategory;

public class RemoveCategoryCommand : IRequest
{
    public int Id { get; set; }

    public RemoveCategoryCommand(int id)
    {
        Id = id;
    }
}
