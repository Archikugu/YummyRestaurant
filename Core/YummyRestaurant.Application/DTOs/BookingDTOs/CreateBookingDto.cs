namespace YummyRestaurant.Application.DTOs.BookingDTOs;

public class CreateBookingDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime ReservationDate { get; set; }
    public required string ReservationTime { get; set; }
    public byte PersonCount { get; set; }
    public required string Message { get; set; }
}

