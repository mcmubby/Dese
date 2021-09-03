using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace httprequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private string collectionName = "IntegrationTest";
        private string organizationId = "612a3a914acf115e685df8e3";

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Data _data;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Data data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet]
        //public async Task<IEnumerable<WeatherForecast>> Get()
        public async Task Get()
        {
            // var rng = new Random();
            // var re = await _data.GetData();
            // return re;
            // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            // {
            //     Date = DateTime.Now.AddDays(index),
            //     TemperatureC = rng.Next(-20, 55),
            //     Summary = Summaries[rng.Next(Summaries.Length)]
            // })
            // .ToArray();

            //var dbData = new PostTestData{Id = 1, VisitCount = 1};
            //await _data.PostData(collectionName,organizationId,dbData);
            var response = await _data.ReadData(collectionName,organizationId);
            Console.Write("");
        }
    }
}
