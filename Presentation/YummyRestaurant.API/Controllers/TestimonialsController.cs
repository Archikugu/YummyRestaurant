using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.TestimonialDTOs;
using YummyRestaurant.Application.Features.Testimonials.Commands.CreateTestimonial;
using YummyRestaurant.Application.Features.Testimonials.Commands.RemoveTestimonial;
using YummyRestaurant.Application.Features.Testimonials.Commands.UpdateTestimonial;
using YummyRestaurant.Application.Features.Testimonials.Queries.GetTestimonialById;
using YummyRestaurant.Application.Features.Testimonials.Queries.GetTestimonialList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialsController(IMediator _mediator, IValidator<CreateTestimonialDto> _createValidator, IValidator<UpdateTestimonialDto> _updateValidator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _mediator.Send(new GetTestimonialQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTestimonialDto createTestimonialDto)
    {
        var validationResult = await _createValidator.ValidateAsync(createTestimonialDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new CreateTestimonialCommand(createTestimonialDto));
        return Ok("Testimonial successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveTestimonialCommand(id));
        return Ok("Testimonial successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTestimonialDto updateTestimonialDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(updateTestimonialDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new UpdateTestimonialCommand(updateTestimonialDto));
        return Ok("Testimonial successfully updated");
    }
}
