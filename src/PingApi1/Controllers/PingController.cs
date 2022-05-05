using Microsoft.AspNetCore.Mvc;
using OpenTelemetry;
using System.Diagnostics;

namespace PingApi1.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        using var source = new ActivitySource("ExampleTracer");

        // A span
        using var activity = source.StartActivity("Call to Ping API 2");

        Baggage.SetBaggage("ExampleItem", "Baggage information to pass through span");

        // 'Ping' API 2
        using var client = new HttpClient();
        _ = await client.GetAsync("http://localhost:5192/ping");

        // Another span
        using var activityTwo = source.StartActivity("Arbitrary 10ms delay");
        await Task.Delay(10);

        return Ok();
    }
}
