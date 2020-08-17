#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/MrPizza.API/MrPizza.Api.csproj", "src/MrPizza.API/"]
COPY ["src/MrPizza.Domain/MrPizza.Domain.csproj", "src/MrPizza.Domain/"]
COPY ["src/MrPizza.Domain.Infra/MrPizza.Domain.Infra.csproj", "src/MrPizza.Domain.Infra/"]
RUN dotnet restore "src/MrPizza.API/MrPizza.Api.csproj"
COPY . .
WORKDIR "/src/src/MrPizza.API"
RUN dotnet build "MrPizza.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MrPizza.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MrPizza.Api.dll"]
