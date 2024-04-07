namespace SeasonPass.Module.SkiResorts.Models;


public class SkiResort
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public float? Rating { get; set; }

    public string? Website { get; set; }

    public string? LogoUrl { get; set; }

    public Elevation? Elevation { get; set; }

    public OperationInfo? OperationInfo { get; set; }

    public TicketPrices? TicketPrices { get; set; }

    public SlopeInfo? SlopeInfo { get; set; }

    public LiftInfrastructure? LiftInfrastructure { get; set; }
}
