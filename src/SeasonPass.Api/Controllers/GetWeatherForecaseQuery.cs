using SeasonPass.Core.Query;

namespace SeasonPass.Api.Controllers
{
    public class GetWeatherForecaseQuery(int count) : IQuery<IEnumerable<WeatherForecast>>
    {
        public int Count { get; } = count;
    }
}
