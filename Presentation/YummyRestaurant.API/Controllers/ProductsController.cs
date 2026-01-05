using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.ProductDTOs;
using YummyRestaurant.Application.Features.Products.Commands.CreateProduct;
using YummyRestaurant.Application.Features.Products.Commands.RemoveProduct;
using YummyRestaurant.Application.Features.Products.Commands.UpdateProduct;
using YummyRestaurant.Application.Features.Products.Queries.GetProductById;
using YummyRestaurant.Application.Features.Products.Queries.GetProductList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateProductDto> _createValidator;
    private readonly IValidator<UpdateProductDto> _updateValidator;

    public ProductsController(IMediator mediator, IValidator<CreateProductDto> createValidator, IValidator<UpdateProductDto> updateValidator)
    {
        _mediator = mediator;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _mediator.Send(new GetProductQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var value = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
    {
        var validationResult = await _createValidator.ValidateAsync(createProductDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new CreateProductCommand(createProductDto));
        return Ok("Product successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveProductCommand(id));
        return Ok("Product successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(updateProductDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new UpdateProductCommand(updateProductDto));
        return Ok("Product successfully updated");
    }
}
