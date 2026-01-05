using MediatR;
using YummyRestaurant.Application.DTOs.ProductDTOs;

namespace YummyRestaurant.Application.Features.Products.Queries.GetProductList;

public class GetProductQuery : IRequest<List<ResultProductDto>>
{
}
