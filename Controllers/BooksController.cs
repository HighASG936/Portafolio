using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace Inventory.Controllers
{
    public class BooksController(HttpClient httpClient) : Controller
    {
        private readonly HttpClient _httpClient = httpClient;
        private static readonly JsonSerializerOptions _jsonOptions = new() 
        { 
            PropertyNameCaseInsensitive = true 
        };

        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://apilibrary-production.up.railway.app/api/Book";
            List<Book> items = [];

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                items = JsonSerializer.Deserialize<List<Book>>(json, _jsonOptions) ?? [];
            }

            return View(items);
        }
    }
}
