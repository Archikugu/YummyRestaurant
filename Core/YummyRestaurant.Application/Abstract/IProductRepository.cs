using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Abstract;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetProductsWithCategoryAsync();
    Task<Product?> GetProductByIdWithCategoryAsync(int id);
}
