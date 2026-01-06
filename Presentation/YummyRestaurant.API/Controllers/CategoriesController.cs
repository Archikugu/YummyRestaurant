using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.CategoryDTOs;
using YummyRestaurant.Application.Features.Categories.Commands.CreateCategory;
using YummyRestaurant.Application.Features.Categories.Commands.RemoveCategory;
using YummyRestaurant.Application.Features.Categories.Commands.UpdateCategory;
using YummyRestaurant.Application.Features.Categories.Queries.GetCategoryById;
using YummyRestaurant.Application.Features.Categories.Queries.GetCategoryList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(IMediator _mediator, IValidator<CreateCategoryDto> _createValidator, IValidator<UpdateCategoryDto> _updateValidator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _mediator.Send(new GetCategoryQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var value = await _mediator.Send(new GetCategoryByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
    {
        var validationResult = await _createValidator.ValidateAsync(createCategoryDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new CreateCategoryCommand(createCategoryDto));
        return Ok("Category successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveCategoryCommand(id));
        return Ok("Category successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryDto updateCategoryDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(updateCategoryDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new UpdateCategoryCommand(updateCategoryDto));
        return Ok("Category successfully updated");
    }
}
