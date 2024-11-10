
using businessDictionary.Components.Pages.Dictionary;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using businessDictionary.Components;

namespace businessDictionary.services
{
   
    public class BusinessDictionaryService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;
        private string _token;

        public BusinessDictionaryService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        private async Task EnsureTokenAsync()
        {
            if (string.IsNullOrEmpty(_token))
            {
                _token = await _authService.GetTokenAsync();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            }
        }

        public async Task<DictionaryResponse> GetBusinessDictionaryAsync()
        {
            await EnsureTokenAsync();
                var res  = await _httpClient.GetFromJsonAsync<DictionaryResponse>("businessdictionary");
            return res;
        }
        public async Task<List<Label>> GetBusinessLabel()
        {
            await EnsureTokenAsync();
            var res = await _httpClient.GetFromJsonAsync<List<Label>>("businessdictionary/label");
            return res;
        }

        public async Task<Tags> GetBusinessTags()
        {
            await EnsureTokenAsync();
            var res = await _httpClient.GetFromJsonAsync<Tags>("businessdictionary/tag");
            return res;
        }

    }
 



}
