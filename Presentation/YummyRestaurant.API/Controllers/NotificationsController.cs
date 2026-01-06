using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.NotificationDTOs;
using YummyRestaurant.Application.Features.Notifications.Commands.CreateNotification;
using YummyRestaurant.Application.Features.Notifications.Commands.RemoveNotification;
using YummyRestaurant.Application.Features.Notifications.Commands.UpdateNotification;
using YummyRestaurant.Application.Features.Notifications.Queries.GetNotificationById;
using YummyRestaurant.Application.Features.Notifications.Queries.GetNotificationByStatus;
using YummyRestaurant.Application.Features.Notifications.Queries.GetNotificationList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationsController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _mediator.Send(new GetNotificationQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var value = await _mediator.Send(new GetNotificationByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNotificationDto createNotificationDto)
    {
        await _mediator.Send(new CreateNotificationCommand(createNotificationDto));
        return Ok("Notification successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveNotificationCommand(id));
        return Ok("Notification successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateNotificationDto updateNotificationDto)
    {
        await _mediator.Send(new UpdateNotificationCommand(updateNotificationDto));
        return Ok("Notification successfully updated");
    }

    [HttpGet("filter/{isRead}")]
    public async Task<IActionResult> GetByStatus([FromRoute] bool isRead)
    {
        var values = await _mediator.Send(new GetNotificationByStatusQuery(isRead));
        return Ok(values);
    }
}
