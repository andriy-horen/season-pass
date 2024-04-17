using FastEndpoints;
using Microsoft.AspNetCore.Http;
using SeasonPass.Core.Query;
using SeasonPass.Module.Common.Models;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.SkiResortList;

public class SkiResortListRequest : IPagedRequest
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

public class SkiResortListEndpoint(IQueryDispatcher queryDispatcher) : Endpoint<SkiResortListRequest>
{
    private readonly IQueryDispatcher _queryDispatcher = queryDispatcher;

    public override void Configure()
    {
        Get("resorts");
        AllowAnonymous();
        Description(d => d.Accepts<SkiResortListRequest>().Produces<IList<SkiResort>>(200));
    }

    public override async Task HandleAsync(SkiResortListRequest req, CancellationToken ct)
    {
        var query = new SkiResortListQuery(req.Reference, req.PageSize, req.SearchQuery, req.Country);
        var data = await _queryDispatcher.Dispatch(query, ct);

        await SendAsync(data);
    }
}
