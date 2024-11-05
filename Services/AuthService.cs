using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InvestApi.Models;

namespace InvestApi.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5084/api/auth/register", request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<RegisterResponse>();
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5084/api/auth/login", request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }
    }
}
