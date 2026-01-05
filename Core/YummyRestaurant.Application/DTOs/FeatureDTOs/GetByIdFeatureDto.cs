namespace YummyRestaurant.Application.DTOs.FeatureDTOs;

public class GetByIdFeatureDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
