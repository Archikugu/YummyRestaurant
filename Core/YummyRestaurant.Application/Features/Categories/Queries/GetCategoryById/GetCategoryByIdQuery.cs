using MediatR;
using YummyRestaurant.Application.DTOs.CategoryDTOs;

namespace YummyRestaurant.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<GetByIdCategoryDto>
{
    public int Id { get; set; }

    public GetCategoryByIdQuery(int id)
    {
        Id = id;
    }
}
