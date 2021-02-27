FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build

WORKDIR /src
COPY . .

WORKDIR /src/EventManagement.Api
RUN dotnet restore EventManagement.Api.csproj
RUN dotnet publish EventManagement.Api.csproj -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /src
COPY --from=build /src/EventManagement.Api/out ./
ENTRYPOINT ["dotnet", "EventManagement.Api.dll"]
EXPOSE 80
EXPOSE 5000
EXPOSE 5001
