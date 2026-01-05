using MediatR;

namespace YummyRestaurant.Application.Features.PhotoGalleries.Commands.RemovePhotoGallery;

public class RemovePhotoGalleryCommand : IRequest
{
    public int Id { get; set; }

    public RemovePhotoGalleryCommand(int id)
    {
        Id = id;
    }
}
