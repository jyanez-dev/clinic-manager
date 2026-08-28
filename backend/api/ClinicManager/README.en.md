# ClinicManager — Backend

## Description

ClinicManager is an application for managing a medical clinic.

The project currently contains the backend developed with **C# and ASP.NET Core Web API**, using **PostgreSQL** as the database management system.

## Technologies

* C#
* ASP.NET Core Web API
* .NET 10
* Entity Framework Core
* PostgreSQL 18.6
* Npgsql
* pgAdmin 4
* Swagger / OpenAPI
* Git

## Requirements

The following software is required to prepare the development environment:

* PostgreSQL 18.6
* pgAdmin 4
* .NET SDK 10
* Visual Studio
* Git

## Installation and Configuration

### 1. Get the Source Code

Clone the repository or update an existing copy:

```bash
git pull
```

### 2. Create the Database

Create a database in PostgreSQL/pgAdmin with the following configuration:

* **Database:** `ClinicManagerDB`
* **Owner:** `postgres`
* **Port:** `5432`

Before executing the schema, verify that the Query Tool is connected to `ClinicManagerDB`.

### 3. Create the Database Structure

The project contains the following scripts:

```text
C:\Projects\ClinicManager\database\scripts\ClinicManagerSchemaPostgreSQL.sql
C:\Projects\ClinicManager\database\scripts\triggers.sql
```

Open this file using the pgAdmin Query Tool connected to `ClinicManagerDB` and execute the complete script.

The schema creates:

* 14 tables
* Identity columns
* Primary Keys
* Foreign Keys
* Unique Constraints
* `set_edit_date()` function
* Triggers for updating `edit_date`
* Default values for `create_date`

### 4. Load the Initial Data

Execute:

```text
C:\Projects\ClinicManager\database\scripts\Initial Inserts Pg.sql
```

These scripts contain the initial data and database objects required by the application, including:

* Roles
* Document types
* Appointment statuses
* Record types
* Administrator user
* Specialties
* Positions

### 5. Configure the Connection

The Web API uses a PostgreSQL connection string similar to:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=ClinicManagerDB;Username=postgres;Password=..."
}
```

**Do not store real passwords in the repository.**

For development environments, User Secrets or environment variables are recommended.

### 6. Restore the Packages

From the Visual Studio terminal, inside the project folder:

```bash
dotnet restore
```

If necessary, install the naming convention package:

```bash
dotnet add package EFCore.NamingConventions
```

Install `Npgsql.EntityFrameworkCore.PostgreSQL` using the **Package Manager Console**:

```powershell
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
```

Or install it using the **Terminal**:

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

### 7. Build the Project

```bash
dotnet build
```

The project should complete successfully with:

```text
Build succeeded.
```

### 8. Run the API

```bash
dotnet run
```

The console will display the URLs where the API is listening.

### 9. Test Swagger

Open the HTTPS address indicated by `dotnet run` and add:

```text
/swagger
```

For example:

```text
https://localhost:7283/swagger
```

The Web API endpoints can be executed and verified through Swagger.

## Database and Dates

The `create_date` fields use:

```sql
DEFAULT CURRENT_TIMESTAMP
```

The `edit_date` fields are automatically updated through triggers when a record is modified.

The application uses `timestamp without time zone` for the date and time fields defined in PostgreSQL.

## Current Backend Status

The backend was adapted to work with PostgreSQL and its functionality was verified on two machines.

The following items were verified:

* Source code updated through Git.
* PostgreSQL 18.6 installation.
* Creation of `ClinicManagerDB`.
* Schema restoration.
* Creation of all 14 tables.
* Primary Keys and Foreign Keys.
* Unique Constraints.
* Function and triggers.
* Initial data.
* Entity Framework Core and Npgsql configuration.
* Web API connection to PostgreSQL.
* Application build.
* API execution.
* Data retrieval through a GET endpoint.
* Correct JSON response.

The development environment migration to the laptop was completed successfully.

## Next Steps

* Test the endpoints using Postman.
* Document the tests performed with Postman.
* Continue later with frontend development.
* Keep the source code, schema, and initial data synchronized in the repository.
