namespace SeasonPass.Core.Query;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation);
}