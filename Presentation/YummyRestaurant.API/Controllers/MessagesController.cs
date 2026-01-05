using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.MessageDTOs;
using YummyRestaurant.Application.Features.Messages.Commands.CreateMessage;
using YummyRestaurant.Application.Features.Messages.Commands.RemoveMessage;
using YummyRestaurant.Application.Features.Messages.Commands.UpdateMessage;
using YummyRestaurant.Application.Features.Messages.Queries.GetMessageById;
using YummyRestaurant.Application.Features.Messages.Queries.GetMessageList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateMessageDto> _createValidator;
    private readonly IValidator<UpdateMessageDto> _updateValidator;

    public MessagesController(IMediator mediator, IValidator<CreateMessageDto> createValidator, IValidator<UpdateMessageDto> updateValidator)
    {
        _mediator = mediator;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _mediator.Send(new GetMessageQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var value = await _mediator.Send(new GetMessageByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMessageDto createMessageDto)
    {
        var validationResult = await _createValidator.ValidateAsync(createMessageDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new CreateMessageCommand(createMessageDto));
        return Ok("Message successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveMessageCommand(id));
        return Ok("Message successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMessageDto updateMessageDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(updateMessageDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new UpdateMessageCommand(updateMessageDto));
        return Ok("Message successfully updated");
    }
}
