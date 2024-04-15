using SeasonPass.Core.Query;
using SeasonPass.Module.Common.Models;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.SkiResortList;

public record class SkiResortListQuery(long Reference, int PageSize, string? SearchQuery, string? CountryCode)
    : IQuery<IPagedResponse<SkiResort>> { }
