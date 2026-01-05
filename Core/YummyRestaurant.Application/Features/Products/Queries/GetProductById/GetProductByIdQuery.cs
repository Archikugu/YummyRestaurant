using MediatR;
using YummyRestaurant.Application.DTOs.ProductDTOs;

namespace YummyRestaurant.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<GetByIdProductDto>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}
