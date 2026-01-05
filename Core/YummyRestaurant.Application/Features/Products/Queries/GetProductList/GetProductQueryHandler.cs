using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.ProductDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Products.Queries.GetProductList;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ResultProductDto>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetProductsWithCategoryAsync();
        return _mapper.Map<List<ResultProductDto>>(values);
    }
}
