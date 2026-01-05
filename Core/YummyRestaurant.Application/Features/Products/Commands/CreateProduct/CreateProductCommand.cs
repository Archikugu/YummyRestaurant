using MediatR;
using YummyRestaurant.Application.DTOs.ProductDTOs;

namespace YummyRestaurant.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest
{
    public CreateProductDto CreateProductDto { get; set; }

    public CreateProductCommand(CreateProductDto createProductDto)
    {
        CreateProductDto = createProductDto;
    }
}
