FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "NetCore.Docker.dll"]