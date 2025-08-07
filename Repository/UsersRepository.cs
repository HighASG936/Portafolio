using Portafolio.Apis;
using Portafolio.Models;
using System.Text.Json;

namespace Portafolio.Repository
{
    public class UsersRepository(HttpClient httpClient) : IRepository<User>
    {
        private readonly HttpClient _httpClient = httpClient;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<IEnumerable<User>> Get()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{Uris.Users}/users/");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<User>>(json, _jsonOptions) ?? [];
            }
            return [];
        }

        public async Task<User?> GetById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{Uris.Users}/users/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<User>(json, _jsonOptions) ?? default;
            }
            return default;
        }
    }
}
