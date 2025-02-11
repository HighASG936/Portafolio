FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Portafolio.csproj", "./"]
RUN dotnet restore "./Portafolio.csproj"
COPY . .
RUN dotnet publish "./Portafolio.csproj" -c Release -o /app/publish

WORKDIR /app
VOLUME /app/wwwroot/images

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
CMD ["dotnet", "Portafolio.dll"]
