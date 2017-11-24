using System.Net.Http;
using System.Threading.Tasks;
using api.Dto;
using Newtonsoft.Json;
using Xunit;

namespace tests
{
    public class GetByNumber : ApiControllerTestBase
    {
        private readonly HttpClient _client;

        public GetByNumber()
        {
            _client = base.GetClient();
        }

        [Theory]
        [InlineData("trivia")]
        public async Task ReturnsTextForSomeNumber(string controllerName)
        {
            // Makes a call to the api.
            var response = await _client.GetAsync($"/api/{controllerName}/45");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TriviaResponse>(stringResponse);

            // Asserts that the number returned is what we want.
            Assert.Equal(45, result.Number);

            // Assrts that the text is not empty.
            Assert.NotEmpty(result.Text);
        }
    }
}