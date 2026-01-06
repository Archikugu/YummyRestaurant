namespace YummyRestaurant.Application.DTOs.CategoryDTOs;

public class ResultCategoryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool IsActive { get; set; }
}

