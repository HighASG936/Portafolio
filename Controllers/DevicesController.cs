using CursoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

public class DevicesController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IActionResult> Index()
    {
        string apiUrl = "https://devicesinventory-production.up.railway.app/api/Device";
        List<Device> items = [];

        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            items = JsonSerializer.Deserialize<List<Device>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        return View(items);
    }
}