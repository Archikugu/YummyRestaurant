using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Domain.Entities;

public class Feature : BaseEntity
{
    public required string Title { get; set; }
    public required string SubTitle { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; } 
    public required string VideoUrl { get; set; }
}
