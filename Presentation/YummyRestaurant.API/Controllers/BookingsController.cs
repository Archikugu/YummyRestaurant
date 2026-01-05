using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.BookingDTOs;
using YummyRestaurant.Application.Features.Bookings.Commands.CreateBooking;
using YummyRestaurant.Application.Features.Bookings.Commands.RemoveBooking;
using YummyRestaurant.Application.Features.Bookings.Commands.UpdateBooking;
using YummyRestaurant.Application.Features.Bookings.Queries.GetBookingById;
using YummyRestaurant.Application.Features.Bookings.Queries.GetBookingList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateBookingDto> _createValidator;
    private readonly IValidator<UpdateBookingDto> _updateValidator;

    public BookingsController(IMediator mediator, IValidator<CreateBookingDto> createValidator, IValidator<UpdateBookingDto> updateValidator)
    {
        _mediator = mediator;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _mediator.Send(new GetBookingQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var value = await _mediator.Send(new GetBookingByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto createBookingDto)
    {
        var validationResult = await _createValidator.ValidateAsync(createBookingDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new CreateBookingCommand(createBookingDto));
        return Ok("Booking successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveBookingCommand(id));
        return Ok("Booking successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookingDto updateBookingDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(updateBookingDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new UpdateBookingCommand(updateBookingDto));
        return Ok("Booking successfully updated");
    }
}
