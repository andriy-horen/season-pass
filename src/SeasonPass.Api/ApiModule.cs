using Autofac;
using SeasonPass.Core.Command;
using SeasonPass.Core.Query;
using AutofacModule = Autofac.Module;

namespace SeasonPass.Api;

public class ApiModule : AutofacModule
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().SingleInstance();
        builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>().SingleInstance();
    }
}
