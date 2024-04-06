using AutofacModule = Autofac.Module;
using SeasonPass.Core.Command;
using SeasonPass.Core.Query;
using Autofac;

namespace SeasonPass.Api;

public class ApiModule : AutofacModule
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = typeof(Program).Assembly;

        builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().SingleInstance();
        builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>().SingleInstance();

        builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IQueryHandler<,>));
        builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandler<,>));
    }
}