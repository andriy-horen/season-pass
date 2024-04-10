using SeasonPass.Core.Query;
using SeasonPass.Module.Common.Models;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.ListAll;

public record class ListAllQuery(long Reference, int PageSize, string? SearchQuery, string? CountryCode) : IQuery<IPagedResponse<SkiResort>>
{
}
