using Microsoft.EntityFrameworkCore;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Persistence.Context;

public class YummyRestaurantContext(DbContextOptions<YummyRestaurantContext> options) : DbContext(options)
{

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<PhotoGallery> PhotoGalleries { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<RestaurantEvent> RestaurantEvents { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<About> Abouts { get; set; }
}
