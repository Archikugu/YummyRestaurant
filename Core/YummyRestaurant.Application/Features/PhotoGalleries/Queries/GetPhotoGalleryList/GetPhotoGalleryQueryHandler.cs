using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.PhotoGalleries.Queries.GetPhotoGalleryList;

public class GetPhotoGalleryQueryHandler : IRequestHandler<GetPhotoGalleryQuery, List<ResultPhotoGalleryDto>>
{
    private readonly IGenericRepository<PhotoGallery> _repository;
    private readonly IMapper _mapper;

    public GetPhotoGalleryQueryHandler(IGenericRepository<PhotoGallery> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultPhotoGalleryDto>> Handle(GetPhotoGalleryQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultPhotoGalleryDto>>(values);
    }
}
