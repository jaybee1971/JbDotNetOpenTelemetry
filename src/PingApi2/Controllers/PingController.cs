using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using OpenTelemetry;
using System.Diagnostics;

namespace PingApi2.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var infoFromContext = Baggage.GetBaggage("ExampleItem");

        using var activitySource = new ActivitySource("Ping.API.2");

        // A span
        using var Api2Activity = activitySource.StartActivity("In Ping API 2 using GET method");
        Api2Activity?.SetTag("api.Info", "some info here about the API call");
        Api2Activity?.SetTag("api.Baggage", infoFromContext);
        return Ok();
    }
}
