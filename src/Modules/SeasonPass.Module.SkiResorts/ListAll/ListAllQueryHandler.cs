using SeasonPass.Core.Query;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.ListAll;

public class ListAllQueryHandler : IQueryHandler<ListAllQuery, IList<SkiResort>>
{
    public Task<IList<SkiResort>> Handle(ListAllQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
