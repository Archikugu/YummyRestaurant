using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.BookingDTOs;
using YummyRestaurant.Application.Features.Bookings.Commands.CreateBooking;
using YummyRestaurant.Application.Features.Bookings.Commands.RemoveBooking;
using YummyRestaurant.Application.Features.Bookings.Commands.UpdateBooking;
using YummyRestaurant.Application.Features.Bookings.Queries.GetBookingById;
using YummyRestaurant.Application.Features.Bookings.Queries.GetBookingList;
using YummyRestaurant.Application.Features.Bookings.Commands.BookingApprove;
using YummyRestaurant.Application.Features.Bookings.Commands.BookingReject;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(IMediator _mediator, IValidator<CreateBookingDto> _createValidator, IValidator<UpdateBookingDto> _updateValidator) : ControllerBase
{

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
    [HttpGet("BookingStatusApproved/{id}")]
    public async Task<IActionResult> BookingStatusApproved(int id)
    {
        await _mediator.Send(new BookingApproveCommand(id));
        return Ok("Reszervasyon Açıklaması 'Onaylandı' Olarak Değiştirildi");
    }

    [HttpGet("BookingStatusCancelled/{id}")]
    public async Task<IActionResult> BookingStatusCancelled(int id)
    {
        await _mediator.Send(new BookingRejectCommand(id));
        return Ok("Reszervasyon Açıklaması 'İptal Edildi' Olarak Değiştirildi");
    }
}
