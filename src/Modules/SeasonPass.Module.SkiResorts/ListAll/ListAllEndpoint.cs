using FastEndpoints;
using Microsoft.AspNetCore.Http;
using SeasonPass.Core.Query;
using SeasonPass.Module.Common.Models;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.ListAll;

public class ListAllRequest : IPagedRequest
{
    [QueryParam]
    public string? Country { get; set; }

    [QueryParam]
    public string? SearchQuery { get; set; }

    [QueryParam]
    public long Reference { get; set; }
    
    [QueryParam]
    public int PageSize { get; set; }
}

public class ListAllEndpoint(IQueryDispatcher queryDispatcher): Endpoint<ListAllRequest>
{
    private readonly IQueryDispatcher _queryDispatcher = queryDispatcher;

    public override void Configure()
    {
        Get("resorts");
        AllowAnonymous();
        Description(d => d
            .Accepts<ListAllRequest>()
            .Produces<IList<SkiResort>>(200, "application/json+custom"));
    }

    public override async Task HandleAsync(ListAllRequest req, CancellationToken ct)
    {
        var query = new ListAllQuery(req.Reference, req.PageSize, req.SearchQuery, req.Country);
        var data = await _queryDispatcher.Dispatch(query, ct);
        
        await SendAsync(data);
    }
}
