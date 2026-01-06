namespace YummyRestaurant.Application.DTOs.RestaurantEventDTOs
{
    public class ResultRestaurantEventDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
