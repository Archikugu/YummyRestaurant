namespace YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;

public class ResultPhotoGalleryDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string ImageUrl { get; set; }
}

