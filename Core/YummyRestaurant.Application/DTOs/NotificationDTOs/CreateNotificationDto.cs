namespace YummyRestaurant.Application.DTOs.NotificationDTOs;

public class CreateNotificationDto
{
    public required string Description { get; set; }
    public required string Type { get; set; }
    public required string Icon { get; set; }
}
