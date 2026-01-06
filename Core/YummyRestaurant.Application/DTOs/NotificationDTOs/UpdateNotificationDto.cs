namespace YummyRestaurant.Application.DTOs.NotificationDTOs;

public class UpdateNotificationDto
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
    public required string Icon { get; set; }
    public bool IsRead { get; set; }
}
