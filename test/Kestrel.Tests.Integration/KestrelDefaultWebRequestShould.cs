using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Kestrel.Tests.Integration
{
    public class KestrelDefaultWebRequestShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public KestrelDefaultWebRequestShould()
        {
            // Arrange
            var builder = new WebHostBuilder()
                .UseStartup<Startup>();
            _server = new TestServer(builder);
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnHelloWorldWhenSuccessful()
        {
            // Act
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Hello World!", responseString);
        }       
    }
}
