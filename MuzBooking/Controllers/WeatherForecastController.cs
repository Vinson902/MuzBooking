using Microsoft.AspNetCore.Mvc;
using MuzBooking.Entities;

namespace MuzBooking.Controllers
{
    [ApiController]
    [Route("[services/booking]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ServiceObject> Get()
        {
            return null;
        }
    }
}