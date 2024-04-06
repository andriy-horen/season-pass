namespace SeasonPass.Core.Query;

public interface IQueryDispatcher
{
    Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellation) where TQuery : IQuery<TResult>;
}