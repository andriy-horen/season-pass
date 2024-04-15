using System.ComponentModel.DataAnnotations.Schema;
using SeasonPass.Core.Models;

namespace SeasonPass.Module.Common.Models;

public class Country : EntityBase
{
    // TODO: probably redundant property
    [NotMapped]
    public required string IsoName { get; set; }

    public required string Name { get; set; }

    [Column("alpha2_code")]
    public required string Alpha2Code { get; set; }

    // TODO: probably redundant property
    [NotMapped]
    [Column("alpha3_code")]
    public required string Alpha3Code { get; set; }

    // TODO: probably redundant property
    [NotMapped]
    public required int NumericCode { get; set; }
}
