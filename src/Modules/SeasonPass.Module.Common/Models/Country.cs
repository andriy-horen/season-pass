using System.ComponentModel.DataAnnotations.Schema;

namespace SeasonPass.Module.Common.Models;

public class Country
{
    public long CountryId { get; set; }
    
    public required string IsoName { get; set; }

    public required string Name { get; set; }

    [Column("alpha2_code")]
    public required string Alpha2Code { get; set; }

    [Column("alpha3_code")]
    public required string Alpha3Code { get; set; }

    public required int NumericCode { get; set; }
}
