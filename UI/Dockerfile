FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY ConsoleEcomm.sln ./
COPY Domain/Domain.csproj ./Domain/
COPY DataAccess/DataAccess.csproj ./DataAccess/
COPY UI/UI.csproj ./UI/

RUN dotnet restore

COPY . . 
RUN dotnet publish UI/UI.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/runtime:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "UI.dll"]
