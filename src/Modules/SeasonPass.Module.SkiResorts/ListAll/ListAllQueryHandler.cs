using Microsoft.EntityFrameworkCore;
using SeasonPass.Core.Query;
using SeasonPass.Module.Postgres.Data;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.ListAll;

public class ListAllQueryHandler : IQueryHandler<ListAllQuery, IList<SkiResort>>
{
    private readonly SeasonPassDbContext _dbContext;

    public ListAllQueryHandler(SeasonPassDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IList<SkiResort>> Handle(ListAllQuery query, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<SkiResort>().Take(100).ToListAsync(cancellationToken);
    }
}
