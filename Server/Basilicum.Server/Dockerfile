FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Basilicum.Server/Basilicum.Server.csproj Basilicum.Server/
RUN dotnet restore Basilicum.Server/Basilicum.Server.csproj
COPY . .
WORKDIR /src/Basilicum.Server
RUN dotnet build Basilicum.Server.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Basilicum.Server.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Basilicum.Server.dll"]
