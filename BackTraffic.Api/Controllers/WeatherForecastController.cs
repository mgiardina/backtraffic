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
using System.Web.Http.Routing;

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
        [Route("GetIncidents")]
        public async Task<string> GetAsync()
        {
            var request = new HttpClient();
            var response = await request.GetAsync("http://www.mapquestapi.com/traffic/v2/incidents?key=RXsJGiT4Bxvr6vHtcwTCdcFMbrUGhGq3&boundingBox=39.95,-105.25,39.52,-104.71&filters=construction,incidents,event,congestion");
            var customerJsonString  =await response.Content.ReadAsStringAsync();
           // var cust = JsonConvert.DeserializeObject<Response>(customerJsonString);
            return customerJsonString;
        }

        [HttpGet]
        [Route("GetIncidentsWithParams")]
        public async Task<string> GetWithParamsAsync(string boundingBox)
        {
            var request = new HttpClient();
            var response = await request.GetAsync($"http://www.mapquestapi.com/traffic/v2/incidents?key=RXsJGiT4Bxvr6vHtcwTCdcFMbrUGhGq3&boundingBox={ boundingBox }&filters=construction,incidents,event,congestion");
            var customerJsonString = await response.Content.ReadAsStringAsync();
            // var cust = JsonConvert.DeserializeObject<Response>(customerJsonString);
            return customerJsonString;
        }
    }
}
