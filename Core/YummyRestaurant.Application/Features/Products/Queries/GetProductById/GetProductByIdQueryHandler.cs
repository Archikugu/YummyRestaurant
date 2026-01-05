using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.ProductDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetByIdProductDto>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetByIdProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetProductByIdWithCategoryAsync(request.Id);
        return _mapper.Map<GetByIdProductDto>(value);
    }
}
