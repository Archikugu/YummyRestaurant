using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.ContactDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IGenericService<Contact> _contactService;
    private readonly IMapper _mapper;

    public ContactsController(IGenericService<Contact> contactService, IMapper mapper)
    {
        _contactService = contactService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _contactService.GetAllAsync();
        var dtos = _mapper.Map<List<ResultContactDto>>(values);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await _contactService.GetByIdAsync(id);
        var dto = _mapper.Map<GetByIdContactDto>(value);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateContactDto createContactDto)
    {
        var contact = _mapper.Map<Contact>(createContactDto);
        await _contactService.AddAsync(contact);
        return Ok("Contact successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var value = await _contactService.GetByIdAsync(id);
        await _contactService.RemoveAsync(value);
        return Ok("Contact successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
    {
        var contact = _mapper.Map<Contact>(updateContactDto);
        await _contactService.UpdateAsync(contact);
        return Ok("Contact successfully updated");
    }
}
