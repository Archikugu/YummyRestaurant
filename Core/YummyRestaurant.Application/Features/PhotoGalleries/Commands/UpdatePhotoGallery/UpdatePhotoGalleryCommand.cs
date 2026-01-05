using MediatR;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;

namespace YummyRestaurant.Application.Features.PhotoGalleries.Commands.UpdatePhotoGallery;

public class UpdatePhotoGalleryCommand : IRequest
{
    public UpdatePhotoGalleryDto UpdatePhotoGalleryDto { get; set; }

    public UpdatePhotoGalleryCommand(UpdatePhotoGalleryDto updatePhotoGalleryDto)
    {
        UpdatePhotoGalleryDto = updatePhotoGalleryDto;
    }
}
