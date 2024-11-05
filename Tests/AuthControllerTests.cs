using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using FluentAssertions;
using Xunit;
using InvestApi; 
using System.Net; // Para HttpStatusCode
using System.Text; // Para Encoding
using System.Net.Http.Headers; // Para MediaTypeHeaderValue

namespace InvestApi.Tests
{
    public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AuthControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Register_Returns_Created_When_Valid()
        {
            // Arrange
            var requestContent = new StringContent(
                JsonConvert.SerializeObject(new { login = "test_user", password = "test_password" }),
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await _client.PostAsync("/api/auth/register", requestContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Login_Returns_Token_When_Valid()
        {
            // Arrange
            var requestContent = new StringContent(
                JsonConvert.SerializeObject(new { login = "test_user", password = "test_password" }),
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await _client.PostAsync("/api/auth/login", requestContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoginResponse>(jsonResponse);
            result.Should().NotBeNull();
            result.Token.Should().NotBeNullOrEmpty();
        }

        private class LoginResponse
        {
            public string Token { get; set; }
        }
    }
}
