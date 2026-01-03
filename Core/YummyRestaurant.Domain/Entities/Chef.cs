using YummyRestaurant.Domain.Common;
namespace YummyRestaurant.Domain.Entities;

public class Chef : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName.ToUpper()}";
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
