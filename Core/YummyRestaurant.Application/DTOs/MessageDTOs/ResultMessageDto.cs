namespace YummyRestaurant.Application.DTOs.MessageDTOs;

public class ResultMessageDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName.ToUpper()}";
    public string Email { get; set; }
    public string Subject { get; set; }
    public string MessageContent { get; set; }
    public bool IsRead { get; set; }
}
