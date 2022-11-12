#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Transport/Transport.API/Transport.API.csproj", "Services/Transport/Transport.API/"]
RUN dotnet restore "Services/Transport/Transport.API/Transport.API.csproj"
COPY . .
WORKDIR "/src/Services/Transport/Transport.API"
RUN dotnet build "Transport.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transport.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transport.API.dll"]