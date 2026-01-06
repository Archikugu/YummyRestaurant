namespace YummyRestaurant.Application.DTOs.ChefDTOs;

public class ResultChefDto
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName.ToUpper()}";
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public bool IsActive { get; set; }
}

