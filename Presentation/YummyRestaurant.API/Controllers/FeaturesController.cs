using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.FeatureDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController : ControllerBase
{
    private readonly IGenericService<Feature> _featureService;
    private readonly IMapper _mapper;

    public FeaturesController(IGenericService<Feature> featureService, IMapper mapper)
    {
        _featureService = featureService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _featureService.GetAllAsync();
        var dtos = _mapper.Map<List<ResultFeatureDto>>(values);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await _featureService.GetByIdAsync(id);
        var dto = _mapper.Map<GetByIdFeatureDto>(value);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
    {
        var feature = _mapper.Map<Feature>(createFeatureDto);
        await _featureService.AddAsync(feature);
        return Ok("Feature successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var value = await _featureService.GetByIdAsync(id);
        await _featureService.RemoveAsync(value);
        return Ok("Feature successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
    {
        var feature = _mapper.Map<Feature>(updateFeatureDto);
        await _featureService.UpdateAsync(feature);
        return Ok("Feature successfully updated");
    }
}
