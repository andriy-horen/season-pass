namespace SeasonPass.Module.Common.Models;

public class Country
{
    public long CountryId { get; set; }
    
    public required string IsoName { get; set; }

    public required string Name { get; set; }
    
    public required string Alpha2Code { get; set; }
    
    public required string Alpha3Code { get; set; }

    public required int NumericCode { get; set; }
}
