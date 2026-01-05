using MediatR;
using YummyRestaurant.Application.DTOs.CategoryDTOs;

namespace YummyRestaurant.Application.Features.Categories.Queries.GetCategoryList;

public class GetCategoryQuery : IRequest<List<ResultCategoryDto>>
{
}
