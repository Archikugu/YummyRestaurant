using MediatR;
using YummyRestaurant.Application.DTOs.CategoryDTOs;

namespace YummyRestaurant.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest
{
    public CreateCategoryDto CreateCategoryDto { get; set; }

    public CreateCategoryCommand(CreateCategoryDto createCategoryDto)
    {
        CreateCategoryDto = createCategoryDto;
    }
}
