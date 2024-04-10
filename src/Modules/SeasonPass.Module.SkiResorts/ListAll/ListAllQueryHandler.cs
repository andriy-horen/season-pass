using Microsoft.EntityFrameworkCore;
using SeasonPass.Core.Query;
using SeasonPass.Module.Common.Models;
using SeasonPass.Module.Postgres.Data;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.ListAll;

public class ListAllQueryHandler : IQueryHandler<ListAllQuery, IPagedResponse<SkiResort>>
{
    private readonly SeasonPassDbContext _dbContext;

    public ListAllQueryHandler(SeasonPassDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IPagedResponse<SkiResort>> Handle(ListAllQuery query, CancellationToken ct)
    {
        var records = await _dbContext.Set<SkiResort>().AsNoTracking()
            .Include(sr => sr.Country)
            .Where(sr => sr.Id > query.Reference)
            .Where(sr => EF.Functions.ILike(sr.Name, $"%{query.SearchQuery}%"))
            .Where(sr => query.CountryCode == null || sr.Country.Alpha2Code == query.CountryCode.ToUpper())
            .OrderBy(sr => sr.Id)
            .Take(query.PageSize + 1)
            .ToListAsync(ct);

        return new PagedResponse<SkiResort>(records, query.PageSize);
    }
}
