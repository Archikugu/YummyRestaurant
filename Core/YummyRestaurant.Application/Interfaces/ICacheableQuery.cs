namespace YummyRestaurant.Application.Interfaces;

public interface ICacheableQuery
{
    string CacheKey { get; }
    TimeSpan? SlidingExpiration { get; }
}
