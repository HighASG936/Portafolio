using Portafolio.Apis;
using Portafolio.Models;
using System.Text.Json;

namespace Portafolio.Repository
{
    public class DevicesRepository(HttpClient httpClient) : IRepository<Device>
    {
        private readonly HttpClient _httpClient = httpClient;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<IEnumerable<Device>> Get()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(Uris.Devices);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Device>>(json, _jsonOptions) ?? [];
            }
            return [];
        }

        public async Task<Device?> GetById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{Uris.Devices}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Device>(json, _jsonOptions) ?? default;
            }
            return default;
        }
    }
}