using Reinforced.Typings.Ast.TypeNames;
using Reinforced.Typings.Fluent;
using SeasonPass.Module.Common.Models;
using SeasonPass.Module.SkiResorts.Models;
using SeasonPass.Module.SkiResorts.SkiResortList;

namespace SeasonPass.Module.Typings;

public static class TypingsConfiguration
{
    public static void Configure(ConfigurationBuilder builder)
    {
        builder.Global(c =>
        {
            c.CamelCaseForMethods();
            c.CamelCaseForProperties();
            c.UseModules();
            c.AutoOptionalProperties();
        });

        builder
            .Substitute(typeof(DateOnly), new RtSimpleTypeName("Date"))
            .Substitute(typeof(DateTime), new RtSimpleTypeName("Date"))
            .Substitute(typeof(TimeOnly), new RtSimpleTypeName("Date"));

        builder.ConfigureCommonModule();
        builder.ConfigureSkiResortsModule();
    }

    public static void ConfigureCommonModule(this ConfigurationBuilder builder)
    {
        builder.ExportAsInterfaces(
            [typeof(Country), typeof(PagedResponse<>)],
            conf => conf.WithPublicProperties().AutoI(false).ExportTo("common-module.ts")
        );
    }

    public static void ConfigureSkiResortsModule(this ConfigurationBuilder builder)
    {
        builder.ExportAsInterfaces(
            [
                typeof(Elevation),
                typeof(LiftInfrastructure),
                typeof(LiftLocation),
                typeof(OperationInfo),
                typeof(SlopeInfo),
                typeof(TicketPrices),
                typeof(SkiResort),
                typeof(SkiResortListRequest)
            ],
            conf => conf.WithPublicProperties().AutoI(false).ExportTo("ski-resort-module.ts")
        );
    }
}
