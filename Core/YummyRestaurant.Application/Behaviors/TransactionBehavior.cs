using MediatR;
using YummyRestaurant.Application.Interfaces;

namespace YummyRestaurant.Application.Behaviors;

public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ITransactionService _transactionService;

    public TransactionBehavior(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Only wrap Commands in Transaction
        if (typeof(TRequest).Name.EndsWith("Command"))
        {
            try
            {
                await _transactionService.BeginTransactionAsync(cancellationToken);
                var response = await next();
                await _transactionService.CommitTransactionAsync(cancellationToken);
                return response;
            }
            catch
            {
                await _transactionService.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }

        return await next();
    }
}
