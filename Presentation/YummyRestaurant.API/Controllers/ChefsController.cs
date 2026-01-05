using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.ChefDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChefsController : ControllerBase
{
    private readonly IGenericService<Chef> _chefService;
    private readonly IMapper _mapper;

    public ChefsController(IGenericService<Chef> chefService, IMapper mapper)
    {
        _chefService = chefService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _chefService.GetAllAsync();
        var dtos = _mapper.Map<List<ResultChefDto>>(values);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await _chefService.GetByIdAsync(id);
        var dto = _mapper.Map<GetByIdChefDto>(value);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateChefDto createChefDto)
    {
        var chef = _mapper.Map<Chef>(createChefDto);
        await _chefService.AddAsync(chef);
        return Ok("Chef successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var value = await _chefService.GetByIdAsync(id);
        await _chefService.RemoveAsync(value);
        return Ok("Chef successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateChefDto updateChefDto)
    {
        var chef = _mapper.Map<Chef>(updateChefDto);
        await _chefService.UpdateAsync(chef);
        return Ok("Chef successfully updated");
    }
}
