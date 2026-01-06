namespace YummyRestaurant.Application.DTOs.MessageDTOs;

public class GetByIdMessageDto
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName.ToUpper()}";
    public required string Email { get; set; }
    public required string Subject { get; set; }
    public required string MessageContent { get; set; }
    public bool IsRead { get; set; }
}

