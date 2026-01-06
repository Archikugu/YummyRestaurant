namespace YummyRestaurant.Application.DTOs.NotificationDTOs;

public class ResultNotificationDto
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
    public required string Icon { get; set; }
    public DateTime Date { get; set; }
    public bool IsRead { get; set; }
}
