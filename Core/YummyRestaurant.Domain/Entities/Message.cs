using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Domain.Entities;

public class Message : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName.ToUpper()}";
    public string Email { get; set; }
    public string Subject { get; set; }
    public string MessageContent { get; set; }
    public bool IsRead { get; set; } = false;
}
