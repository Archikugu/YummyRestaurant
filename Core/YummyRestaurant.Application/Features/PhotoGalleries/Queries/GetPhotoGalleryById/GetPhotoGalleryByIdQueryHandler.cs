using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.PhotoGalleries.Queries.GetPhotoGalleryById;

public class GetPhotoGalleryByIdQueryHandler : IRequestHandler<GetPhotoGalleryByIdQuery, GetByIdPhotoGalleryDto>
{
    private readonly IGenericRepository<PhotoGallery> _repository;
    private readonly IMapper _mapper;

    public GetPhotoGalleryByIdQueryHandler(IGenericRepository<PhotoGallery> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetByIdPhotoGalleryDto> Handle(GetPhotoGalleryByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<GetByIdPhotoGalleryDto>(value);
    }
}
