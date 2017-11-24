using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using api.Dto;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class TriviaController : Controller
    {
        [HttpGet("{number}")]
        public async Task<TriviaResponse> GetAsync(int number) 
        {
            // Call numbersapi.com and return results.
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://numbersapi.com/" + number + "?json");
            var triviaResult = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TriviaResponse>(triviaResult);
        }
    }
}
