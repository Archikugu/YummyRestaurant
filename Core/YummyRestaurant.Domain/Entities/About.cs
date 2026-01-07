using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Domain.Entities;

public class About : BaseEntity
{
    public string ImageUrl { get; set; } = string.Empty;
    public string Highlight1 { get; set; } = string.Empty;
    public string Highlight2 { get; set; } = string.Empty;
    public string Highlight3 { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Description2 { get; set; } = string.Empty;
    public string ImageUrl2 { get; set; } = string.Empty;
    public string VideoUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}
