# JbDotNetOpenTelemetry
PoC for OpenTelemetry using DotNet

# OTEL
Otel collector
Jaeger exporter
AppD exporter

# Services
Dotnet standard example weather API
On execution calls basic dotnet ping endpoint (PingApi1)
PingApi1 then calls PingApi2
Traces triggered during calls to illustrate trace spans

# Running the demo
Requires Docker

````bash
$ sh start.sh
````

# Web App
Build and run the web app seperately to illustrate triggering the APIs from a UI
This adds basic RUM telemetry to the traces, capturing user browser info
https://localhost:7274/

