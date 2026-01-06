namespace YummyRestaurant.Application.DTOs.ServiceDTOs;

public class GetByIdServiceDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string IconUrl { get; set; }
}

