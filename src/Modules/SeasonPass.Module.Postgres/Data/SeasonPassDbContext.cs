using Microsoft.EntityFrameworkCore;
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
        
        optionsBuilder.UseNpgsql(connectionString);
    }
}
