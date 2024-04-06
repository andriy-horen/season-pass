using Microsoft.AspNetCore.Mvc;
using SeasonPass.Core.Query;

namespace SeasonPass.Api.Controllers
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }


    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IQueryDispatcher _queryDispatcher;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IQueryDispatcher queryDispatcher)
        {
            _logger = logger;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get(CancellationToken cancellationToken)
        {
            return await _queryDispatcher.Dispatch(new GetWeatherForecaseQuery(5), cancellationToken);
        }
    }
}
