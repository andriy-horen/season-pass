using SeasonPass.Module.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeasonPass.Module.SkiResorts.Models;

public class SkiResort
{
    public required long SkiResortId { get; set; }

    public required string Name { get; set; }
    
    public float? Rating { get; set; }

    public string? Website { get; set; }

    public string? LogoUrl { get; set; }

    public string? ExternalUrl { get; set; }

    public Elevation? Elevation { get; set; }
    
    public SlopeInfo? SlopeInfo { get; set; }

    public LiftInfrastructure? Infrastructure { get; set; }
    
    public OperationInfo? Operation { get; set; }

    public TicketPrices? TicketPrices { get; set; }

    public required Country Country { get; set; }

    [ForeignKey("country2_id")]
    public Country? Country2 { get; set; }

    public IList<LiftLocation>? Lifts { get; set; }
}
