using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.CategoryDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IGenericService<Category> _categoryService;
    private readonly IMapper _mapper;

    public CategoriesController(IGenericService<Category> categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _categoryService.GetAllAsync();
        var dtos = _mapper.Map<List<ResultCategoryDto>>(values);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await _categoryService.GetByIdAsync(id);
        var dto = _mapper.Map<GetByIdCategoryDto>(value);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
    {
        var category = _mapper.Map<Category>(createCategoryDto);
        await _categoryService.AddAsync(category);
        return Ok("Category successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var value = await _categoryService.GetByIdAsync(id);
        await _categoryService.RemoveAsync(value);
        return Ok("Category successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
    {
        var category = _mapper.Map<Category>(updateCategoryDto);
        await _categoryService.UpdateAsync(category);
        return Ok("Category successfully updated");
    }
}
