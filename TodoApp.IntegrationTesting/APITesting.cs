
namespace TodoApp.IntegrationTesting
{
    public class APITesting : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public APITesting(WebApplicationFactory<Program> factory)
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }
        [Fact]
        public async Task GetHealth_WhenCalled_ReturnOk()
        {
            var response = await _client.GetAsync(ApiRoutes.Healthy);
            var stringResult = await response.Content.ReadAsStringAsync();
            Assert.Equal("Healthy", stringResult);
        }
    }
}