using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.PhotoGalleries.Commands.UpdatePhotoGallery;

public class UpdatePhotoGalleryCommandHandler : IRequestHandler<UpdatePhotoGalleryCommand>
{
    private readonly IGenericRepository<PhotoGallery> _repository;
    private readonly IMapper _mapper;

    public UpdatePhotoGalleryCommandHandler(IGenericRepository<PhotoGallery> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdatePhotoGalleryCommand request, CancellationToken cancellationToken)
    {
        var photoGallery = _mapper.Map<PhotoGallery>(request.UpdatePhotoGalleryDto);
        _repository.Update(photoGallery);
        await Task.CompletedTask;
    }
}
