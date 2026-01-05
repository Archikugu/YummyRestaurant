using MediatR;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;

namespace YummyRestaurant.Application.Features.PhotoGalleries.Commands.CreatePhotoGallery;

public class CreatePhotoGalleryCommand : IRequest
{
    public CreatePhotoGalleryDto CreatePhotoGalleryDto { get; set; }

    public CreatePhotoGalleryCommand(CreatePhotoGalleryDto createPhotoGalleryDto)
    {
        CreatePhotoGalleryDto = createPhotoGalleryDto;
    }
}
