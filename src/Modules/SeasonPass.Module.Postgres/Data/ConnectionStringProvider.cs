using Microsoft.Extensions.Configuration;
using Npgsql;

namespace SeasonPass.Module.Postgres.Data;

public interface IConnectionStringProvider
{
    string GetConnectionString();
}

public class ConnectionStringProvider(IConfiguration configuration) : IConnectionStringProvider
{
    private readonly IConfiguration _configuration = configuration;

    public string GetConnectionString()
    {
        var connectionString = _configuration.GetConnectionString("SeasonPassDb");
        var dbPassword =
            _configuration["Postgres:Password"]
            ?? throw new InvalidOperationException(
                "Postgres database password is missing; You can set it by running command: dotnet user-secrets set \"Postgres:Password\" \"<password>\" --project src/SeasonPass.Api"
            );

        var builder = new NpgsqlConnectionStringBuilder(connectionString);
        builder.Password = dbPassword;

        return builder.ConnectionString;
    }
}
