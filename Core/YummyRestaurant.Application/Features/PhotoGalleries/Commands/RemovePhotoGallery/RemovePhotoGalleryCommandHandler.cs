using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.PhotoGalleries.Commands.RemovePhotoGallery;

public class RemovePhotoGalleryCommandHandler : IRequestHandler<RemovePhotoGalleryCommand>
{
    private readonly IGenericRepository<PhotoGallery> _repository;

    public RemovePhotoGalleryCommandHandler(IGenericRepository<PhotoGallery> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemovePhotoGalleryCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value != null)
        {
            _repository.Remove(value);
        }
    }
}
