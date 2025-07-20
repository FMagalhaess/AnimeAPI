FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["AnimeAPI.API/AnimeAPI.API.csproj", "AnimeAPI.API/"]
COPY ["AnimeAPI.Application/AnimeAPI.Application.csproj", "AnimeAPI.Application/"]
COPY ["AnimeAPI.Domain/AnimeAPI.Domain.csproj", "AnimeAPI.Domain/"]
COPY ["AnimeAPI.Infrastructure/AnimeAPI.Infrastructure.csproj", "AnimeAPI.Infrastructure/"]

COPY ["AnimeAPI.sln", "."]

RUN dotnet restore "AnimeAPI.API/AnimeAPI.API.csproj"

COPY . .

WORKDIR /src/AnimeAPI.API

RUN dotnet publish "AnimeAPI.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

EXPOSE 80

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AnimeAPI.API.dll"]