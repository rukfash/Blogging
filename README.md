# Blogging
Environment
- ASP.NET Core 2.0
- Microsoft SQL Server Express 2016

Steps to run

Option 1
1. Create database "Blogging" in SQL Express
2. Run script "Blogging.sql" - located in project root folder
3. Adjust connection string in appsettings.json, defaults: Server=(localdb)\\mssqllocaldb;Initial Catalog=Blogging;
4. Navigate to project folder over command prompt
5. Run command "dotnet run"
6. App should be running at "http://localhost:65313/" - change in launchSettings.json if needed

Option 2
1. Open .csproj in Visual Studio 
2. Run with Visual Studio
3. App should be running at "http://localhost:65312/"

Code was designed to allow unit tests to be written, but none were done as there was lack of time to make them. App uses interfaces and services for data manipulation which allows for easy unit testing integration.
