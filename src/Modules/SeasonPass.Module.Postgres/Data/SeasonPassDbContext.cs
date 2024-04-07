using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace SeasonPass.Module.Postgres.Data;

internal class SeasonPassDbContext: DbContext
{
    private readonly IConfiguration _configuration;

    public SeasonPassDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = GetConnectionString();
        
        optionsBuilder.UseNpgsql(connectionString);
    }

    // TODO: move this to some sort of connection string provider
    private string GetConnectionString()
    {
        var connectionStringNoPassword = _configuration.GetConnectionString("SeasonPassDb");
        var dbPassword = _configuration["Postgres:Password"] ?? throw new InvalidOperationException("Postgres database password is missing; You can set it by running command: dotnet user-secrets set \"Postgres:Password\" \"<password>\" --project src/SeasonPass.Api");
        var builder = new NpgsqlConnectionStringBuilder(connectionStringNoPassword);
        builder.Password = dbPassword;

        return builder.ConnectionString;
    }
}
