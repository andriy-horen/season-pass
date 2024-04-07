namespace SeasonPass.Module.SkiResorts.Models;

public class LiftLocation
{
    public required int LiftLocationId { get; set; }

    public required string Name { get; set; }

    public required decimal Latitude { get; set; }

    public required decimal Longitude { get; set; }
}