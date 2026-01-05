namespace YummyRestaurant.Application.DTOs.MessageDTOs;

public class CreateMessageDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string MessageContent { get; set; }
    public bool IsRead { get; set; }
}
