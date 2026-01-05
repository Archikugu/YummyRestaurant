namespace YummyRestaurant.Application.DTOs.BookingDTOs;

public class UpdateBookingDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime ReservationDate { get; set; }
    public string ReservationTime { get; set; }
    public byte PersonCount { get; set; }
    public string Message { get; set; }
}
