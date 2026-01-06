using YummyRestaurant.Domain.Common;
namespace YummyRestaurant.Domain.Entities;

public class Testimonial : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName.ToUpper()}";
    public required string Title { get; set; }
    public required string Comment { get; set; }
    public required string ImageUrl { get; set; }
}
