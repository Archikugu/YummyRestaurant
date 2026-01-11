using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using YummyRestaurant.Application.Interfaces;

namespace YummyRestaurant.Application.Behaviors;

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IDistributedCache _cache;
    private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;

    public CachingBehavior(IDistributedCache cache, ILogger<CachingBehavior<TRequest, TResponse>> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is ICacheableQuery cacheableQuery)
        {
            var cacheKey = cacheableQuery.CacheKey;
            var cachedResponse = await _cache.GetAsync(cacheKey, cancellationToken);

            if (cachedResponse != null)
            {
                _logger.LogInformation($"[Cache Hit] {cacheKey}");
                var responseString = Encoding.UTF8.GetString(cachedResponse);
                return JsonSerializer.Deserialize<TResponse>(responseString)!;
            }

            _logger.LogInformation($"[Cache Miss] {cacheKey}");
            var response = await next();

            var options = new DistributedCacheEntryOptions
            {
                SlidingExpiration = cacheableQuery.SlidingExpiration ?? TimeSpan.FromMinutes(10)
            };

            var serializedResponse = JsonSerializer.Serialize(response);
            await _cache.SetAsync(cacheKey, Encoding.UTF8.GetBytes(serializedResponse), options, cancellationToken);

            return response;
        }

        return await next();
    }
}
