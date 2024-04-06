using Microsoft.Extensions.DependencyInjection;

namespace SeasonPass.Core.Query;

public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellation) where TQuery : IQuery<TResult>
    {
        var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();

        return handler.Handle(query, cancellation);
    }
}