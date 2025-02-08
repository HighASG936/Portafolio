FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Inventory.csproj", "./"]
RUN dotnet restore "./Inventory.csproj"
COPY . .
RUN dotnet publish "./Inventory.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
CMD ["dotnet", "Inventory.dll"]
