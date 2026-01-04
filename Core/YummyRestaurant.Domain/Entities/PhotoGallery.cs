using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Domain.Entities;

public class PhotoGallery : BaseEntity
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
}
