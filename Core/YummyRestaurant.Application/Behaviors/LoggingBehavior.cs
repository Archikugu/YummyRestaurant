using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace YummyRestaurant.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var requestGuid = Guid.NewGuid().ToString();

        var requestData = JsonSerializer.Serialize(request);
        _logger.LogInformation($"[START] {requestGuid}; Request: {requestName}; Data: {requestData}");

        var response = await next();

        _logger.LogInformation($"[END] {requestGuid}; Request: {requestName}");

        return response;
    }
}
