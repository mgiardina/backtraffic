using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BackTraffic.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrafficServiceController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TrafficServiceController> _logger;

        public TrafficServiceController(ILogger<TrafficServiceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> GetAsync()
        {
            var request = new HttpClient();
            var response = await request.GetAsync("https://www.mapquestapi.com/traffic/v2/incidents?&outFormat=json&boundingBox=34.158977272273354%2C-118.01273345947266%2C33.945638452963024%2C-118.47415924072267&filters=construction%2Cincidents%2Cevent%2Ccongestion&key=RXsJGiT4Bxvr6vHtcwTCdcFMbrUGhGq3");
            var customerJsonString  =await response.Content.ReadAsStringAsync();
           // var cust = JsonConvert.DeserializeObject<Response>(customerJsonString);
            return customerJsonString;
        }
    }
}
