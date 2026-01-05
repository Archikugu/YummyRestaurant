using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.PhotoGalleries.Commands.CreatePhotoGallery;

public class CreatePhotoGalleryCommandHandler : IRequestHandler<CreatePhotoGalleryCommand>
{
    private readonly IGenericRepository<PhotoGallery> _repository;
    private readonly IMapper _mapper;

    public CreatePhotoGalleryCommandHandler(IGenericRepository<PhotoGallery> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreatePhotoGalleryCommand request, CancellationToken cancellationToken)
    {
        var photoGallery = _mapper.Map<PhotoGallery>(request.CreatePhotoGalleryDto);
        await _repository.AddAsync(photoGallery);
    }
}
