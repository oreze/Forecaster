# Forecaster
Simple app that allows user to check weather. Work in progress.

[Live development instance (may not work, after releasing alpha will be replaced with main branch)](https://fore-caster.herokuapp.com/ "ForeCaster")

## Table of content
[About](#about)\
[Technologies](#technologies)\
[Installation](#installation)\
[Future plans](#future-plans)

# About

App made as "proof of concept" before something more serious. Based on openweather api, allows user to enter location and get current weather. I treat this app as "testing place" where i can try using technologies i currently learn.

# Technologies

### Used in project:

* .NET 5.0.202
* Bootstrap 5
* NPM 7.4.0
* Node.js 15.6.0
* Html
* SCSS
* Javascript (may be Typescript in future)
* Docker (containerize app for deploying purposes)
### NuGet packages
* Newtonsoft.Json 13.0.1
* Serilog 2.10.0
* Serilog.Sinks.Console 4.0.0-dev-00839

# Installation

### Prerequisites:
* .NET 5.0.202 SDK
* .NET Runtime 5.0.5
* ASP.NET Core Runtime 5.0.5
* NodeJS 15.6.0
* NPM 7.4.0

### Installation process
1. Clone repository into new file\
   ```git clone https://github.com/oreze/Forecaster.git```
2. **OPTIONAL** checkout to development branch\
   ```git checkout development```
3. Run NPM install all dependencies\
   ```npm install```
4. Install all packages from NuGet\
   [Current list of used packages](#nuget-packages)
5. Add OpenWeather api key to dotnet secrets as "Api:OpenWeather:ApiKey"
6. Use this command to run\
   ```dotnet run```

### Future plans
To be honest, i have no special plans at the moment. I want to finish basic feature (checking current weather), write some tests, add long term forecast, add some geolocation, maybe use PostgreSQL to store statistic data about weather (Entity Framework Core). If i would had some idea i\`ll place it here.

---
**Feel free to contact me if you have any questions, ideas or concerns about project/documentation.**
