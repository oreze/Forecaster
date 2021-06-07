# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else, install npm packages and build
COPY . .
RUN apt-get update && apt-get install -y python3 curl git nano build-essential openssl libssl-dev && curl -fsSL https://deb.nodesource.com/setup_15.x | bash - && apt-get install -y nodejs && npm install && dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "Forecaster.dll"]
# Allow Heroku to choose port
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Forecaster.dll