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

    public async Task<IList<SkiResort>> Handle(ListAllQuery query, CancellationToken ct)
    {
        return await _dbContext.Set<SkiResort>()
            .Include(sr => sr.Country)
            .Where(sr => EF.Functions.ILike(sr.Name, $"%{query.SearchQuery}%") && (query.CountryCode == null || sr.Country.Alpha2Code == query.CountryCode.ToUpper()))
            .ToListAsync(ct);
    }
}
