using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Domain.Entities;

public class PhotoGallery : BaseEntity
{
    public required string Title { get; set; }
    public required string ImageUrl { get; set; }
}
