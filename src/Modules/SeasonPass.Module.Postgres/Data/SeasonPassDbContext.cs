using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace SeasonPass.Module.Postgres.Data;

public class SeasonPassDbContext: DbContext
{
    private readonly IConnectionStringProvider _connectionStringProvider;
    private readonly IList<IDbContextModelBuilder> _modelBuilders;

    public SeasonPassDbContext(IConnectionStringProvider connectionStringProvider, IList<IDbContextModelBuilder> modelBuilders)
    {
        _connectionStringProvider = connectionStringProvider;
        _modelBuilders = modelBuilders;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _connectionStringProvider.GetConnectionString();
        
        optionsBuilder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var customBuilder in _modelBuilders)
        {
            customBuilder.Update(modelBuilder);
        }
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
