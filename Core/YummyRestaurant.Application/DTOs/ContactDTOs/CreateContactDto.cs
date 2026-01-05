namespace YummyRestaurant.Application.DTOs.ContactDTOs;

public class CreateContactDto
{
    public string Location { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string OpeningHours { get; set; }
    public string MapUrl { get; set; }
}
