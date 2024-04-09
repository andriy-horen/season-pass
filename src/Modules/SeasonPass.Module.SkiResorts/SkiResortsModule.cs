using Autofac;
using SeasonPass.Core.Command;
using SeasonPass.Core.Query;
using SeasonPass.Module.Postgres.Data;
using SeasonPass.Module.SkiResorts.Data;
using AutofacModule = Autofac.Module;

namespace SeasonPass.Module.SkiResorts;

public class SkiResortsModule : AutofacModule
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = typeof(SkiResortsModule).Assembly;

        builder.RegisterType<SkiResortsModelBuilder>().As<IDbContextModelBuilder>().SingleInstance();

        builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IQueryHandler<,>));
        builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandler<,>));
    }
}
