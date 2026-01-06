using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Domain.Entities;

public class Booking : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName.ToUpper()}";
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime ReservationDate { get; set; }
    public required string ReservationTime { get; set; }
    public byte PersonCount { get; set; }
    public required string Message { get; set; }
}
