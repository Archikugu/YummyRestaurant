using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler(IGenericRepository<Category> _repository) : IRequestHandler<UpdateCategoryCommand>
{

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.UpdateCategoryDto.Id);
        if (category != null)
        {
            category.Name = request.UpdateCategoryDto.Name;
            category.Description = request.UpdateCategoryDto.Description;
            category.IsActive = request.UpdateCategoryDto.IsActive;
            _repository.Update(category);
        }
    }
}
