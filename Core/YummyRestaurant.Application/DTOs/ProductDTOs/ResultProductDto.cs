namespace YummyRestaurant.Application.DTOs.ProductDTOs;

public class ResultProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryName { get; set; }
    public int CategoryId { get; set; }
    public bool IsActive { get; set; }
}
