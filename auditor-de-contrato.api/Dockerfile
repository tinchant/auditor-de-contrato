#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["auditor-de-contrato.api/auditor-de-contrato.api.csproj", "auditor-de-contrato.api/"]
COPY ["auditor-de-contrato.domain/auditor-de-contrato.domain.csproj", "auditor-de-contrato.domain/"]
COPY ["auditor-de-contrato.infra/auditor-de-contrato.infra.csproj", "auditor-de-contrato.infra/"]
RUN dotnet restore "auditor-de-contrato.api/auditor-de-contrato.api.csproj"
COPY . .
WORKDIR "/src/auditor-de-contrato.api"
RUN dotnet build "auditor-de-contrato.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "auditor-de-contrato.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "auditor-de-contrato.api.dll"]
