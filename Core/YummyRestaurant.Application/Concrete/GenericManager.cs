using System.Linq.Expressions;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Common;

namespace YummyRestaurant.Application.Concrete;

public class GenericManager<T> : IGenericService<T> where T : BaseEntity
{
    private readonly IGenericRepository<T> _repository;

    public GenericManager(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _repository.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await _repository.AddRangeAsync(entities);
        return entities;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _repository.AnyAsync(expression);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task RemoveAsync(T entity)
    {
        _repository.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        _repository.RemoveRange(entities);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(T entity)
    {
        _repository.Update(entity);
        await Task.CompletedTask;
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _repository.Where(expression);
    }
}
