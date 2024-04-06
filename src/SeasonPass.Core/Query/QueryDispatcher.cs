using System.Collections.Concurrent;

namespace SeasonPass.Core.Query;

public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private static readonly ConcurrentDictionary<Type, QueryHandlerBase> _queryHandlers = new();

    public Task<TResult> Dispatch<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
    {
        var queryType = query.GetType();
        var handler = (QueryHandlerWrapper<TResult>)_queryHandlers.GetOrAdd(queryType, static queryType =>
        {
            var wrapperType = typeof(QueryHandlerWrapper<,>).MakeGenericType(queryType, typeof(TResult));
            var wrapper = Activator.CreateInstance(wrapperType) ?? throw new InvalidOperationException($"Could not create wrapper type for {queryType}");

            return (QueryHandlerBase)wrapper;
        });

        return handler.Handle(query, _serviceProvider, cancellationToken);
    }
}