using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JbWebApi;

namespace JbWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly HttpClient _apiClient;
    public List<WeatherForecast> WeatherForecasts { get; set; } = new List<WeatherForecast>();
    public IndexModel(HttpClient apiClient, ILogger<IndexModel> logger)
    {
        _logger = logger;
        _apiClient = apiClient;
        _apiClient.BaseAddress = new Uri("Https://localhost:7233");
    }

    public async Task OnGetAsync()
    {
        var response = await _apiClient.GetAsync($"WeatherForecast");
        if (response.IsSuccessStatusCode)
        {
            WeatherForecasts = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>()
                ?? new List<WeatherForecast>();
        }
    }
}
