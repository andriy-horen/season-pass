namespace SeasonPass.Module.SkiResorts.Models;

public record Elevation
{
    public required int BaseElevation { get; init; }
    
    public required int TopElevation { get; init; }
}
