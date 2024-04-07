using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SeasonPass.Core.Data;
using SeasonPass.Module.SkiResorts.Models;

namespace SeasonPass.Module.Postgres.Data;

internal class SeasonPassDbContext: DbContext
{
    private readonly IConnectionStringProvider _connectionStringProvider;

    public DbSet<SkiResort> SkiResorts { get; set; }

    public SeasonPassDbContext(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _connectionStringProvider.GetConnectionString();
        
        optionsBuilder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SkiResort>(entity => {
            entity.OwnsOne(e => e.Elevation);
            entity.OwnsOne(e => e.Operation);
            entity.OwnsOne(e => e.TicketPrices);
            entity.OwnsOne(e => e.SlopeInfo);
            entity.OwnsOne(e => e.Infrastructure);
        });
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        /** 
         * By default EF Core uses the DbSet<TEntity> property name as the table name
         * This changes behavior to use the type name instead
         */
        configurationBuilder.Conventions.Remove(typeof(TableNameFromDbSetConvention));
    }
}
