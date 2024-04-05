using Autofac;
using SeasonPass.Core.Command;
using SeasonPass.Core.Query;

namespace SeasonPass.Api;

public class ApiModule : Module
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