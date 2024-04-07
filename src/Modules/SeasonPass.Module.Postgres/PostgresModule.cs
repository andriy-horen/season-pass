using Autofac;
using SeasonPass.Core.Data;
using SeasonPass.Module.Postgres.Data;
using AutofacModule = Autofac.Module;

namespace SeasonPass.Module.Postgres;

public class PostgresModule: AutofacModule
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ConnectionStringProvider>().As<IConnectionStringProvider>().SingleInstance();
    }
}
