using FastEndpoints;
using SeasonPass.Core.Query;

namespace SeasonPass.Module.SkiResorts.ListAll;

public class ListAllRequest
{
    [QueryParam]
    public string? Country { get; set; }

    [QueryParam]
    public string? SearchQuery { get; set; }
}

public class ListAllEndpoint(IQueryDispatcher queryDispatcher): Endpoint<ListAllRequest>
{
    private readonly IQueryDispatcher _queryDispatcher = queryDispatcher;

    public override void Configure()
    {
        Get("resorts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ListAllRequest req, CancellationToken ct)
    {
        var data = await _queryDispatcher.Dispatch(new ListAllQuery(req.SearchQuery, req.Country), ct);
        
        await SendAsync(data);
    }
}
