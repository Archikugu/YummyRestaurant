using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Domain.Entities;

public class Contact : BaseEntity
{
    public string Location { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string OpeningHours { get; set; }
    public string MapUrl { get; set; }
}
