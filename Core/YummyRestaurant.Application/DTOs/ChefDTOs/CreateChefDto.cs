namespace YummyRestaurant.Application.DTOs.ChefDTOs;

public class CreateChefDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
}

