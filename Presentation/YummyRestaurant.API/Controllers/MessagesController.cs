using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.MessageDTOs;
using YummyRestaurant.Application.Features.Messages.Commands.CreateMessage;
using YummyRestaurant.Application.Features.Messages.Commands.RemoveMessage;
using YummyRestaurant.Application.Features.Messages.Commands.UpdateMessage;
using YummyRestaurant.Application.Features.Messages.Queries.GetMessageById;
using YummyRestaurant.Application.Features.Messages.Queries.GetMessageList;
using YummyRestaurant.Application.Features.Messages.Queries.GetMessageByStatus;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController(IMediator _mediator, IValidator<CreateMessageDto> _createValidator, IValidator<UpdateMessageDto> _updateValidator) : ControllerBase
{

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

    [HttpGet("filter/{isRead}")]
    public async Task<IActionResult> GetByStatus(bool isRead)
    {
        var values = await _mediator.Send(new GetMessageByStatusQuery(isRead));
        return Ok(values);
    }

    [HttpGet("MessageStatusRead/{id}")]
    public async Task<IActionResult> MessageStatusRead(int id)
    {
        await _mediator.Send(new YummyRestaurant.Application.Features.Messages.Commands.MessageReview.MessageReviewCommand(id));
        return Ok("Message marked as read");
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
