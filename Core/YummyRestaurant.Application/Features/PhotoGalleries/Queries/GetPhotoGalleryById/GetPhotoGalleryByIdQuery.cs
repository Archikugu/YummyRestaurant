using MediatR;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;

namespace YummyRestaurant.Application.Features.PhotoGalleries.Queries.GetPhotoGalleryById;

public class GetPhotoGalleryByIdQuery : IRequest<GetByIdPhotoGalleryDto>
{
    public int Id { get; set; }

    public GetPhotoGalleryByIdQuery(int id)
    {
        Id = id;
    }
}
