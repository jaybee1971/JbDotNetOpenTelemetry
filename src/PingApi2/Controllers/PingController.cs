using Microsoft.AspNetCore.Mvc;
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

        using var source = new ActivitySource("ExampleTracer");

        // A span
        using var activity = source.StartActivity("In Ping API 2 using GET method");
        activity?.SetTag("InfoPingApi2Received", infoFromContext);
        return Ok();
    }
}
