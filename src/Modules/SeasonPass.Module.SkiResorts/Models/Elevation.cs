namespace SeasonPass.Module.SkiResorts.Models;

public record Elevation
{
    public required int Base { get; init; }

    public required int Top { get; init; }
}
