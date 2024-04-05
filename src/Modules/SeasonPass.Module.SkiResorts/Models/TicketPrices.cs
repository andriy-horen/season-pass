namespace SeasonPass.Module.SkiResorts.Models;

// TODO: rewrite to be an array of ticket price e.g. { value = 60.5, currency = "EUR", type = TicketType.Adult }
public class TicketPrices
{
    public string? Adults { get; set; }

    public string? Youth { get; set; }

    public string? Children { get; set; }
}
