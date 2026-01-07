using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Products.Commands.RemoveProduct;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
{
    private readonly IGenericRepository<Product> _repository;

    public RemoveProductCommandHandler(IGenericRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value != null)
        {
            _repository.Remove(value);
        }
    }
}
