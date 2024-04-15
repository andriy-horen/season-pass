using SeasonPass.Core.Models;

namespace SeasonPass.Module.SkiResorts.Models;

public class LiftLocation : EntityBase
{
    public required string Name { get; set; }

    public required decimal Latitude { get; set; }

    public required decimal Longitude { get; set; }
}
