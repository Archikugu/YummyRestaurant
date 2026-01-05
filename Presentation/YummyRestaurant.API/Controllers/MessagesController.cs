using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.MessageDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IGenericService<Message> _messageService;
    private readonly IMapper _mapper;

    public MessagesController(IGenericService<Message> messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _messageService.GetAllAsync();
        var dtos = _mapper.Map<List<ResultMessageDto>>(values);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await _messageService.GetByIdAsync(id);
        var dto = _mapper.Map<GetByIdMessageDto>(value);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMessageDto createMessageDto)
    {
        var message = _mapper.Map<Message>(createMessageDto);
        await _messageService.AddAsync(message);
        return Ok("Message successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var value = await _messageService.GetByIdAsync(id);
        await _messageService.RemoveAsync(value);
        return Ok("Message successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateMessageDto updateMessageDto)
    {
        var message = _mapper.Map<Message>(updateMessageDto);
        await _messageService.UpdateAsync(message);
        return Ok("Message successfully updated");
    }
}
