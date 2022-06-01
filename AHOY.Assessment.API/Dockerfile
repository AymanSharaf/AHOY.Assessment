#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AHOY.Assessment.API/AHOY.Assessment.API.csproj", "AHOY.Assessment.API/"]
RUN dotnet restore "AHOY.Assessment.API/AHOY.Assessment.API.csproj"
COPY . .
WORKDIR "/src/AHOY.Assessment.API"
RUN dotnet build "AHOY.Assessment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AHOY.Assessment.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AHOY.Assessment.API.dll"]