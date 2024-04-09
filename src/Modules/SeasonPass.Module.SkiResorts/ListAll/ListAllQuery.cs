using SeasonPass.Core.Query;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.ListAll;

public record class ListAllQuery(string? SearchQuery = null, string? CountryCode = null) : IQuery<IList<SkiResort>>
{
}
