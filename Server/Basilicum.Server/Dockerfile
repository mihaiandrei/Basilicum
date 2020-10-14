FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1709

COPY bin/Release/netcoreapp3.1/publish app/
WORKDIR /app
ENTRYPOINT ["dotnet", "Basilicum.Server.dll"]