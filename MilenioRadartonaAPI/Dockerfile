FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MilenioRadartonaAPI/MilenioRadartonaAPI.csproj", "MilenioRadartonaAPI/"]
RUN dotnet restore "MilenioRadartonaAPI/MilenioRadartonaAPI.csproj"
COPY . .
WORKDIR "/src/MilenioRadartonaAPI"
RUN dotnet build "MilenioRadartonaAPI.csproj" -c Release -o /app/build

FROM build AS publish
COPY ./.aws/credentials ./root/.aws/credentials
RUN dotnet publish "MilenioRadartonaAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MilenioRadartonaAPI.dll"]