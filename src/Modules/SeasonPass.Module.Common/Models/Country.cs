using System.ComponentModel.DataAnnotations.Schema;
using SeasonPass.Core.Models;

namespace SeasonPass.Module.Common.Models;

public class Country : EntityBase
{
    public required string Name { get; set; }

    [Column("alpha2_code")]
    public required string Alpha2Code { get; set; }
}
