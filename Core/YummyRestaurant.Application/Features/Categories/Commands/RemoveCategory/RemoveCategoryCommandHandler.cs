using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Categories.Commands.RemoveCategory;

public class RemoveCategoryCommandHandler(IGenericRepository<Category> _repository) : IRequestHandler<RemoveCategoryCommand>
{

    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value != null)
        {
            _repository.Remove(value);
        }
    }
}
