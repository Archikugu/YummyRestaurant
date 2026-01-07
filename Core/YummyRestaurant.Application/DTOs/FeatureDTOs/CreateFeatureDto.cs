namespace YummyRestaurant.Application.DTOs.FeatureDTOs;

public class CreateFeatureDto
{
    public required string Title { get; set; }
    public required string SubTitle { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required string VideoUrl { get; set; }
    public bool IsActive { get; set; }
}


