using Microsoft.EntityFrameworkCore;
using SeasonPass.Module.Common.Models;
using SeasonPass.Module.Postgres.Data;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.SkiResorts.Data;

internal class SkiResortsModelBuilder : IDbContextModelBuilder
{
    public void Update(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SkiResort>(entity => {
            entity.OwnsOne(e => e.Elevation);
            entity.OwnsOne(e => e.Operation);
            entity.OwnsOne(e => e.TicketPrices);
            entity.OwnsOne(e => e.SlopeInfo);
            entity.OwnsOne(e => e.Infrastructure);
        });
    }
}
