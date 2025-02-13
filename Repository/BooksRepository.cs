using Portafolio.Apis;
using Portafolio.Models;
using System.Text.Json;

namespace Portafolio.Repository
{
    public class BooksRepository(HttpClient httpClient) : IRepository<Book>
    {
        private readonly HttpClient _httpClient = httpClient;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<IEnumerable<Book>> Get()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(Uris.Books);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Book>>(json, _jsonOptions) ?? [];
            }
            return [];
        }

        public async Task<Book?> GetById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{Uris.Devices}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Book>(json, _jsonOptions) ?? default;
            }
            return default;
        }
    }
}