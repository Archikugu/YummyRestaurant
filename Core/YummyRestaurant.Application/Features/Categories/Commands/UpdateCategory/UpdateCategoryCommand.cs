using MediatR;
using YummyRestaurant.Application.DTOs.CategoryDTOs;

namespace YummyRestaurant.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest
{
    public UpdateCategoryDto UpdateCategoryDto { get; set; }

    public UpdateCategoryCommand(UpdateCategoryDto updateCategoryDto)
    {
        UpdateCategoryDto = updateCategoryDto;
    }
}
