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
        using var activitySource = new ActivitySource("Ping.API.1");

        // A span
        using var Api1Activity = activitySource.StartActivity("Call to Ping API 2");
        Api1Activity?.SetTag("api.Info", "some info here about the API call");

        Baggage.SetBaggage("ExampleItem", "Baggage information to pass through span");

        // 'Ping' API 2
        using var client = new HttpClient();
        _ = await client.GetAsync("http://ping-api-2:7001/ping");

        // Another span
        using var activityTwo = activitySource.StartActivity("Arbitrary 10ms delay");
        await Task.Delay(10);

        return Ok();
    }
}
