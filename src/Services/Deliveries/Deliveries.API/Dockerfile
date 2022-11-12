#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Deliveries/Deliveries.API/Deliveries.API.csproj", "Services/Deliveries/Deliveries.API/"]
RUN dotnet restore "Services/Deliveries/Deliveries.API/Deliveries.API.csproj"
COPY . .
WORKDIR "/src/Services/Deliveries/Deliveries.API"
RUN dotnet build "Deliveries.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Deliveries.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Deliveries.API.dll"]
