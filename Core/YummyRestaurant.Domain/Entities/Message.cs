using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Domain.Entities;

public class Message : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Subject { get; set; }
    public required string MessageContent { get; set; }
    public bool IsRead { get; set; }
}
