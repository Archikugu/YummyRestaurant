namespace YummyRestaurant.Application.DTOs.ContactDTOs;

public class UpdateContactDto
{
    public int Id { get; set; }
    public required string Location { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string OpeningHours { get; set; }
    public required string MapUrl { get; set; }
}

