    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Text.Json;

namespace businessDictionary.services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetTokenAsync()
        {
            var loginRequest = new
            {
                username = "admin@datablue.com",
                password = "123456@a",
                deviceServiceId = "web"
            };

            var response = await _httpClient.PostAsJsonAsync("api/v1.0/users-auth/sign-in", loginRequest);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                if (result.TryGetProperty("token", out var tokenProperty))
                {
                    return tokenProperty.GetString();
                }
            }

            return null;
        }
    }

}
