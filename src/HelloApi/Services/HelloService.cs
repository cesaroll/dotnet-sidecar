using System;
using System.Net.Http;
using HelloApi.Entities;

namespace HelloApi.Services
{
    public class HelloService
    {
        private const string URL = "http://localhost:8180/Hello";
        
        public HelloMessage RetrieveHelloMessage()
        {
            var client = new HttpClient();

            var response = client.GetAsync(URL).Result;

            if (response.IsSuccessStatusCode)
            {
                return new HelloMessage()
                {
                    Message = response.Content.ReadAsStringAsync().Result
                };
            }

            return new HelloMessage()
            {
                Message = $"Error Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}"
            };
        }
    }
}