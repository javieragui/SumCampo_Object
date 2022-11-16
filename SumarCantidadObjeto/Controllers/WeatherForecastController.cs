using Microsoft.AspNetCore.Mvc;

namespace SumarCantidadObjeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private List<WeatherForecast> _forecasts = new List<WeatherForecast>();
        private List<WeatherForecast> Sumado = new List<WeatherForecast>();
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _forecasts.Add( new WeatherForecast
            {
                Referencia = 123,
                Cantidad = 5,
                Summary = "Primero"
            });
            _forecasts.Add(new WeatherForecast
            {
                Referencia = 123,
                Cantidad = 3,
                Summary = "Segundo"
            });
            _forecasts.Add(new WeatherForecast
            {
                Referencia = 456,
                Cantidad = 4,
                Summary = "Tercero"
            });
            _forecasts.Add(new WeatherForecast
            {
                Referencia = 678,
                Cantidad = 10,
                Summary = "Cuarto"
            });
            _forecasts.Add(new WeatherForecast
            {
                Referencia = 123,
                Cantidad = 4,
                Summary = "Quinto"
            });
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            foreach (var fore in _forecasts)
            {
                var obj = Sumado.FirstOrDefault(x => x.Referencia == fore.Referencia);
                if(obj != null)
                {
                    obj.Cantidad += fore.Cantidad;
                }
                else
                {
                    Sumado.Add(new WeatherForecast
                    {
                        Referencia = fore.Referencia,
                        Cantidad = fore.Cantidad,
                        Summary = fore.Summary
                    });
                }
            }
            return Ok(Sumado);
        }
    }
}