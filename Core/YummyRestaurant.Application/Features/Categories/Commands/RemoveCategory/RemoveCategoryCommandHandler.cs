using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Categories.Commands.RemoveCategory;

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
{
    private readonly IGenericRepository<Category> _repository;

    public RemoveCategoryCommandHandler(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        _repository.Remove(value);
    }
}
