namespace YummyRestaurant.Application.DTOs.ProductDTOs;

public class GetByIdProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public required string ImageUrl { get; set; }
    public required string CategoryName { get; set; }
    public int CategoryId { get; set; }
    public bool IsActive { get; set; }
}

