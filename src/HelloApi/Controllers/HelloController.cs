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
        private readonly ILogger<HelloController> _logger;
        private readonly HelloService _helloService;
        
        public HelloController(ILogger<HelloController> logger, HelloService helloService)
        {
            _logger = logger;
            _helloService = helloService;
        }

        [HttpGet]
        public String Get()
        {
            return "Hello from Hello Api";
        }

        [HttpGet]
        [Route("FromSidecar")]
        public async Task<IActionResult> GetFromSidecar()
        {
            return Ok(await _helloService.RetrieveHelloMessage());
        }
    }
}