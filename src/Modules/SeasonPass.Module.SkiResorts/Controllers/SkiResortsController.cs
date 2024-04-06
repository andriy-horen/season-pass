using Microsoft.AspNetCore.Mvc;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.Controllers;

[ApiController]
[Route("[controller]")]
public class SkiResortsController : ControllerBase
{
    [HttpGet(Name = "GetSkiResorts")]
    public async Task<IList<SkiResort>> Get(CancellationToken cancellationToken)
    {
        return [];
    }
}
