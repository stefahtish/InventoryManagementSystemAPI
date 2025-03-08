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
            "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=InventoryDB;Trusted_Connection=True;" //change Server value accordingly.
          }
  b. Apply migrations to create the database. Run bellow command on your IDE Terminal
          dotnet ef database update
4. Run the Application
   The API will be available at https://localhost:7134.
6. Access Swagger UI for API Documentation
   https://localhost:7134/swagger/index.html
   
**Authentication Endpoints**
1. Register a New User:
    Send a POST request to /api/auth/register with a username and password.
2. Login and Get JWT Token:
    Send a POST request to /api/auth/login with the same credentials.
    Copy the token from the response.
3. Access Secured Endpoints:
    Include the token in the Authorization header of your requests to access secured endpoints.
   For product management endpoints refer to the swagger API Documentation.

**Architectural Decisions**
1. Clean Architecture:
    The project follows a clean architecture approach with clear separation of concerns:
    Presentation Layer: Controllers and API endpoints.
    Application Layer: Business logic and services.
    Domain Layer: Entities and interfaces.
    Infrastructure Layer: Data access and repositories
  
2. Repository Pattern:
    The repository pattern is used to abstract data access logic, making the code more maintainable and testable.

3. Dependency Injection:
    Dependency Injection (DI) is used throughout the application to promote loose coupling and testability.

4. JWT Authentication:
    JWT-based authentication is implemented for securing API endpoints.


 **Areas for improvement if given more time**
 1. Unit testing framework full implementetion
 2. For production environments, avoid storing sensitive information like connection strings in appsettings.json. Instead, use environment variables or a secret manager.

   

   
