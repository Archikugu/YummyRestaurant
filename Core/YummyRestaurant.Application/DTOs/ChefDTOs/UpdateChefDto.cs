namespace YummyRestaurant.Application.DTOs.ChefDTOs;

public class UpdateChefDto
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public bool IsActive { get; set; }
}

