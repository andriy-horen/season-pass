using Microsoft.AspNetCore.Mvc;
using SeasonPass.Core.Query;
using SeasonPass.Module.SkiResorts.ListAll;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.Controllers;

[ApiController]
[Route("[controller]")]
public class SkiResortsController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;

    public SkiResortsController(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet(Name = "GetSkiResorts")]
    public async Task<IList<SkiResort>> Get(CancellationToken cancellationToken)
    {
        return await _queryDispatcher.Dispatch(new ListAllQuery(), cancellationToken);
    }
}
