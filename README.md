To Run this:

Clone this repository on your machine on Visual Studio

Create a local instance of a DB on SQL
Within VS:
Go to userinfo\userinfo\appsettings.json and add connection string to app settings.json. It will look something like this:

  "ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-3M6G1RU\\MSSQLSERVER01;Database=users;User Id=admin;Password=pass1;TrustServerCertificate=true;MultipleActiveResultSets=true;"
  },


To add a migration to your db 

Run add-migration 1stmigration
run add-database

Now run the app
