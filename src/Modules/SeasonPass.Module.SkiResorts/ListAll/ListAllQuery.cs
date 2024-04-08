using SeasonPass.Core.Query;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.ListAll;

public class ListAllQuery: IQuery<IList<SkiResort>>
{
    public string? CountryCode { get; set; }

    public string? SearchQuery { get; set;}
}
