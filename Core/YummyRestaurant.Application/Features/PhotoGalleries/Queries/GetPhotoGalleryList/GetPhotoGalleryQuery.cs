using MediatR;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;

namespace YummyRestaurant.Application.Features.PhotoGalleries.Queries.GetPhotoGalleryList;

public class GetPhotoGalleryQuery : IRequest<List<ResultPhotoGalleryDto>>
{
}
