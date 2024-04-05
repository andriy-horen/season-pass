using SeasonPass.Core.Query;

namespace SeasonPass.Api.Controllers
{
    public class GetWeatherForecaseQueryHandler : IQueryHandler<GetWeatherForecaseQuery, IEnumerable<WeatherForecast>>
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        public Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecaseQuery query, CancellationToken cancellation)
        {
            var forecasts = Enumerable.Range(1, query.Count).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });

            return Task.FromResult(forecasts);
        }
    }
}
