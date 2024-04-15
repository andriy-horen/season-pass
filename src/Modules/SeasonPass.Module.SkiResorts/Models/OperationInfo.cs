namespace SeasonPass.Module.SkiResorts.Models;

public class OperationInfo
{
    public TimeOnly? OpenHour { get; set; }

    public TimeOnly? CloseHour { get; set; }

    public string? SeasonDuration { get; set; }
}
