namespace YummyRestaurant.Application.DTOs.MessageDTOs;

public class CreateMessageDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Subject { get; set; }
    public required string MessageContent { get; set; }
    public bool IsRead { get; set; }
}

