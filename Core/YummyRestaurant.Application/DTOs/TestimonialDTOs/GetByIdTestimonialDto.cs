namespace YummyRestaurant.Application.DTOs.TestimonialDTOs;

public class GetByIdTestimonialDto
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Title { get; set; }
    public required string Comment { get; set; }
    public required string ImageUrl { get; set; }
}

