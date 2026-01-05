using AutoMapper;
using MediatR;
using YummyRestaurant.Application.DTOs.CategoryDTOs;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetByIdCategoryDto>
{
    private readonly IGenericRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(IGenericRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetByIdCategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<GetByIdCategoryDto>(value);
    }
}
