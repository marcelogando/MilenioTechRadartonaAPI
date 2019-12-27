FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV HTTP_PROXY="http://d841170:sp13l_B3rg10@10.10.190.25:3128"
ENV HTTPS_PROXY="http://d841170:sp13l_B3rg10@10.10.190.25:3128"
ENV NO_PROXY="localhost,127.0.0.1,::1"

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
ENV HTTP_PROXY="http://d841170:sp13l_B3rg10@10.10.190.25:3128"
ENV HTTPS_PROXY="http://d841170:sp13l_B3rg10@10.10.190.25:3128"
ENV NO_PROXY="localhost,127.0.0.1,::1"
WORKDIR /src
COPY ["MilenioRadartonaAPI/MilenioRadartonaAPI.csproj", "MilenioRadartonaAPI/"]
RUN dotnet restore "MilenioRadartonaAPI/MilenioRadartonaAPI.csproj"
COPY . .
WORKDIR "/src/MilenioRadartonaAPI"
RUN dotnet build "MilenioRadartonaAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MilenioRadartonaAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MilenioRadartonaAPI.dll"]
