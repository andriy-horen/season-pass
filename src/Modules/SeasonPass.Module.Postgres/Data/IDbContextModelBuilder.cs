using Microsoft.EntityFrameworkCore;

namespace SeasonPass.Module.Postgres.Data;

public interface IDbContextModelBuilder
{
    void Update(ModelBuilder modelBuilder);
}
