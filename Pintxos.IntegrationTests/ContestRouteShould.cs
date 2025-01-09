using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Pintxos.IntegrationTests
{
    public class ContestRouteShould : IClassFixture<TestFixture>
    {
        private readonly HttpClient _client;

        public ContestRouteShould(TestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task ChallengeAnonymousUser()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/Contest");

            // Act: request the Contests route
            var response = await _client.SendAsync(request);

            // Assert: the user is sent to the login page
            Assert.Equal(
                "http:/localhost:8888/Account/Login?ReturnUrl=%2FContest",
                response.Headers.Location.ToString()
            );

            
        }
    }
}