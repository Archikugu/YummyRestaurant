using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Domain.Entities;

public class Booking : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime ReservationDate { get; set; }
    public string ReservationTime { get; set; }
    public byte PersonCount { get; set; }
    public string Message { get; set; }
}
