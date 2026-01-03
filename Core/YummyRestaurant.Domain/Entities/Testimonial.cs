using YummyRestaurant.Domain.Common;
namespace YummyRestaurant.Domain.Entities;

public class Testimonial : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName.ToUpper()}";
    public string Title { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
}
