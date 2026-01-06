using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.RestaurantEventDTOs;
using YummyRestaurant.Application.Features.RestaurantEvents.Commands.CreateRestaurantEvent;
using YummyRestaurant.Application.Features.RestaurantEvents.Commands.RemoveRestaurantEvent;
using YummyRestaurant.Application.Features.RestaurantEvents.Commands.UpdateRestaurantEvent;
using YummyRestaurant.Application.Features.RestaurantEvents.Queries.GetRestaurantEventById;
using YummyRestaurant.Application.Features.RestaurantEvents.Queries.GetRestaurantEventList;

namespace YummyRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantEventsController(IMediator _mediator, IValidator<CreateRestaurantEventDto> _createValidator, IValidator<UpdateRestaurantEventDto> _updateValidator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _mediator.Send(new GetRestaurantEventQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _mediator.Send(new GetRestaurantEventByIdQuery(id));
            if (values == null) return NotFound();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRestaurantEventDto createRestaurantEventDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createRestaurantEventDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var command = new CreateRestaurantEventCommand
            {
                Title = createRestaurantEventDto.Title,
                Description = createRestaurantEventDto.Description,
                Price = createRestaurantEventDto.Price,
                ImageUrl = createRestaurantEventDto.ImageUrl,
                VideoUrl = createRestaurantEventDto.VideoUrl
            };
            await _mediator.Send(command);
            return Ok("Etkinlik başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRestaurantEventDto updateRestaurantEventDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateRestaurantEventDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var command = new UpdateRestaurantEventCommand
            {
                Id = updateRestaurantEventDto.Id,
                Title = updateRestaurantEventDto.Title,
                Description = updateRestaurantEventDto.Description,
                Price = updateRestaurantEventDto.Price,
                ImageUrl = updateRestaurantEventDto.ImageUrl,
                VideoUrl = updateRestaurantEventDto.VideoUrl,
                IsActive = updateRestaurantEventDto.IsActive
            };
            await _mediator.Send(command);
            return Ok("Etkinlik başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveRestaurantEventCommand(id));
            return Ok("Etkinlik başarıyla silindi.");
        }
    }
}
