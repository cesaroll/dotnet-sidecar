using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HelloApi.Entities;
using Microsoft.Extensions.Logging;

namespace HelloApi.Services
{
    public class HelloService
    {
        private const string URL = "http://localhost:8180/Hello";
        
        private readonly ILogger<HelloService> _logger;

        public HelloService(ILogger<HelloService> logger)
        {
            _logger = logger;
        }

        public async Task<HelloMessage> RetrieveHelloMessage()
        {
            var client = new HttpClient();

            var response = client.GetAsync(URL).Result;

            if (!response.IsSuccessStatusCode)
            {
                return new HelloMessage()
                {
                    Message = $"Error Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}"
                };
            }
                
            _logger.LogInformation(response.Content.ReadAsStringAsync().Result);
                
            var helloMessage = await response.Content.ReadFromJsonAsync<HelloMessage>();
                
            _logger.LogInformation(helloMessage?.Message);

            return helloMessage;

        }
    }
}