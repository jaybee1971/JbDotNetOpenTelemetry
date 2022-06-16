FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 9001
ENV ASPNETCORE_URLS=http://+:9001
ENV OTEL_RESOURCE_ATTRIBUTES=service.name=Weather.Api
ENV OTEL_RESOURCE_ATTRIBUTES=service.namespace=otel_poc

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /build
COPY src/JbWebApi .
RUN dotnet restore  

RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "JbWebApi.dll"]
