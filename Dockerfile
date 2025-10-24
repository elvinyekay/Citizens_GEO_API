FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Citizen_Geo_API.csproj", "./"]
RUN dotnet restore "Citizen_Geo_API.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Citizen_Geo_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Citizen_Geo_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Citizen_Geo_API.dll"]