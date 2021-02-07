using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HelloApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {   
        private readonly ILogger<WeatherForecastController> _logger;
        
        public HelloController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public String Get()
        {
            return "Hello from Hello Api";
        }

        [HttpGet]
        [Route("FromSidecar")]
        public string GetFromSidecar()
        {
            var service = new HelloService();
            return service.RetrieveHelloMessage().Message;
        }
    }
}