using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Domain.Entities;

public class Contact : BaseEntity
{
    public required string Location { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string OpeningHours { get; set; }
    public required string MapUrl { get; set; }
}
