using AutoMapper;
using MediatR;
using YummyRestaurant.Application.DTOs.CategoryDTOs;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Categories.Queries.GetCategoryList;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<ResultCategoryDto>>
{
    private readonly IGenericRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(IGenericRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultCategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultCategoryDto>>(values);
    }
}
