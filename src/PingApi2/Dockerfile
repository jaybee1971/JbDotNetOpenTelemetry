FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 5192
ENV ASPNETCORE_URLS=http://+:7001
ENV OTEL_RESOURCE_ATTRIBUTES=service.name=otel_poc_app2
ENV OTEL_RESOURCE_ATTRIBUTES=service.namespace=otel_poc

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /build
COPY src/PingApi2 .
RUN dotnet restore  

RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "PingApi2.dll"]
