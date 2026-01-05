using MediatR;

namespace YummyRestaurant.Application.Features.Products.Commands.RemoveProduct;

public class RemoveProductCommand : IRequest
{
    public int Id { get; set; }

    public RemoveProductCommand(int id)
    {
        Id = id;
    }
}
