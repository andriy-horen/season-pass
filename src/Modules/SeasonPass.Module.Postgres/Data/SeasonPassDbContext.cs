using Microsoft.EntityFrameworkCore;
using SeasonPass.Core.Data;

namespace SeasonPass.Module.Postgres.Data;

internal class SeasonPassDbContext: DbContext
{
    private readonly IConnectionStringProvider _connectionStringProvider;

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
