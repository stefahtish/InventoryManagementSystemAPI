# InventoryManagementSystemAPI
**Setup Instructions**

**Prerequisites**
.NET 8 SDK
SQL Server or SQL Server LocalDB
Visual Studio 2022 or Visual Studio Code

**Steps to Run the Project**
1. Clone the Repository
2. Set Up the Database:
  a.  Update the connection string in appsettings.json:
          "ConnectionStrings": {
            "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=InventoryDB;Trusted_Connection=True;" //change Server value
          }
  b. Apply migrations to create the database. Run bellow command on your IDE Terminal
          dotnet ef database update
4. Run the Application
   The API will be available at https://localhost:7134.
6. Access Swagger UI for API Documentation
   https://localhost:7134/swagger/index.html

   

   
