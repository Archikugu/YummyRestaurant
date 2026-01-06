using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.ContactDTOs;
using YummyRestaurant.Application.Features.Contacts.Commands.CreateContact;
using YummyRestaurant.Application.Features.Contacts.Commands.RemoveContact;
using YummyRestaurant.Application.Features.Contacts.Commands.UpdateContact;
using YummyRestaurant.Application.Features.Contacts.Queries.GetContactById;
using YummyRestaurant.Application.Features.Contacts.Queries.GetContactList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController(IMediator _mediator, IValidator<CreateContactDto> _createValidator, IValidator<UpdateContactDto> _updateValidator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _mediator.Send(new GetContactQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var value = await _mediator.Send(new GetContactByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContactDto createContactDto)
    {
        var validationResult = await _createValidator.ValidateAsync(createContactDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new CreateContactCommand(createContactDto));
        return Ok("Contact successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveContactCommand(id));
        return Ok("Contact successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateContactDto updateContactDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(updateContactDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new UpdateContactCommand(updateContactDto));
        return Ok("Contact successfully updated");
    }
}
