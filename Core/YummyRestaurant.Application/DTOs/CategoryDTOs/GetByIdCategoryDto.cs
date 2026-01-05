namespace YummyRestaurant.Application.DTOs.CategoryDTOs;

public class GetByIdCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
