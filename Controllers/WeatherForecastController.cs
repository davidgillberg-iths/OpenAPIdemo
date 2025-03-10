using Microsoft.AspNetCore.Mvc;

namespace OpenAPIdemo.Controllers
{
    /// <summary>
    /// Hanterar väderprognoser.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Skapar en ny instans av <see cref="WeatherForecastController"/>.
        /// </summary>
        /// <param name="logger">Logger för att hantera loggning.</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Hämtar en lista med väderprognoser för de kommande dagarna.
        /// </summary>
        /// <returns>En lista med <see cref="WeatherForecast"/>-objekt.</returns>
        /// <response code="200">Returnerar en lista med väderprognoser.</response>
        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
