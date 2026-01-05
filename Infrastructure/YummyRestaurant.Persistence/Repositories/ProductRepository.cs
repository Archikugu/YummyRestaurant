using Microsoft.EntityFrameworkCore;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;
using YummyRestaurant.Persistence.Context;

namespace YummyRestaurant.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly YummyRestaurantContext _context;

    public ProductRepository(YummyRestaurantContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsWithCategoryAsync()
    {
        return await _context.Products.Include(x => x.Category).ToListAsync();
    }

    public async Task<Product> GetProductByIdWithCategoryAsync(int id)
    {
        return await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
    }
}
