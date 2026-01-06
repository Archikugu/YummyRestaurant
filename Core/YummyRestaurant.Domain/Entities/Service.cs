using YummyRestaurant.Domain.Common;
namespace YummyRestaurant.Domain.Entities;
public class Service : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string IconUrl { get; set; }
}
