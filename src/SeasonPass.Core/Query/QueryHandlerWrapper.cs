using Microsoft.Extensions.DependencyInjection;

namespace SeasonPass.Core.Query;

public abstract class QueryHandlerBase
{
    public abstract Task<object?> Handle(object query, IServiceProvider serviceProvider, CancellationToken cancellationToken);
}

public abstract class QueryHandlerWrapper<TResult>: QueryHandlerBase
{
    public abstract Task<TResult> Handle(IQuery<TResult> query, IServiceProvider serviceProvider, CancellationToken cancellationToken);
}

public class QueryHandlerWrapper<TQuery, TResult>: QueryHandlerWrapper<TResult> where TQuery : IQuery<TResult>
{
    public override Task<TResult> Handle(IQuery<TResult> query, IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>().Handle((TQuery)query, cancellationToken);
    }

    public override async Task<object?> Handle(object query, IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return await Handle((IQuery<TResult>)query, serviceProvider, cancellationToken).ConfigureAwait(false);
    }
}
