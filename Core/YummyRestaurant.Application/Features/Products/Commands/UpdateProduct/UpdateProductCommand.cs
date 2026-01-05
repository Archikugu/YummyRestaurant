using MediatR;
using YummyRestaurant.Application.DTOs.ProductDTOs;

namespace YummyRestaurant.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest
{
    public UpdateProductDto UpdateProductDto { get; set; }

    public UpdateProductCommand(UpdateProductDto updateProductDto)
    {
        UpdateProductDto = updateProductDto;
    }
}
