using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Domain.Entities;

public class Notification : BaseEntity
{
    public required string Description { get; set; }
    public required string Type { get; set; } // info, warning, success, etc.
    public required string Icon { get; set; } // feather icon name
    public DateTime Date { get; set; }
    public bool IsRead { get; set; }
}
