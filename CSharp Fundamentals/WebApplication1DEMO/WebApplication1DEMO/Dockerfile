#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["WebApplication1DEMO/WebApplication1DEMO.csproj", "WebApplication1DEMO/"]
RUN dotnet restore "WebApplication1DEMO/WebApplication1DEMO.csproj"
COPY . .
WORKDIR "/src/WebApplication1DEMO"
RUN dotnet build "WebApplication1DEMO.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication1DEMO.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication1DEMO.dll"]