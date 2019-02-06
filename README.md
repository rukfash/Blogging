# Blogging
Environment
- ASP.NET Core 2.0
- Microsoft SQL Server Express 2016

Steps to run

1. Create database "Blogging" in SQL Express
2. Run script "Blogging.sql" - located in project root folder
3. Adjust connection string in appsettings.json, defaults: Server=(localdb)\\mssqllocaldb;Initial Catalog=Blogging;
4. Navigate to project folder over command prompt and fun "dotnet run" or open with Visual Studio and start
5. App should be running "http://localhost:65313/" or "http://localhost:65312/" if run from Visual Studio

Code was designed to allow unit tests to be written, but none were done as there was lack of time to make them. App uses interfaces and services for data manipulation which allows for easy unit testing integration.
