# SunFix MVC Application

This project is a simple ASP.NET Core MVC application, designed for managing quotes, parts, and related entities for a solar panel layout system. It provides a web interface for CRUD (Create, Read, Update, Delete) operations on various entities including parts, quotes, projects, and users.

## Prerequisites

To run this application, you need:

1. **.NET 6.0 SDK or higher**: Ensure that .NET 6.0 or a compatible version is installed. You can download it from [here](https://dotnet.microsoft.com/download).

2. **SQL Server**: The application is configured to use SQL Server as the database. You can use SQL Server Express or any other edition of SQL Server, either locally or hosted. If you prefer a different database, you will need to adjust the connection string and Entity Framework Core configuration.

3. **Visual Studio 2022** or **Visual Studio Code** (or any IDE of your choice that supports .NET projects).

4. **Entity Framework Core Tools**: Install Entity Framework Core tools to manage database migrations. You can do this via the command line with:
   ```bash
   dotnet tool install --global dotnet-ef
   ```

## Setup Instructions

### 1. Clone the Repository

Clone the repository to your local machine:

```bash
git clone <repository-url>
cd SunFix
```

### 2. Configure the Database Connection

In the `appsettings.json` file, located in the root of the project, you’ll find the connection string under `"ConnectionStrings"`.

Update the `DefaultConnection` with your SQL Server configuration:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

- Replace `YOUR_SERVER_NAME` with the name of your SQL Server instance (e.g., `localhost` for local development).
- Replace `YOUR_DATABASE_NAME` with the name of your database.
- Set `Trusted_Connection=True` if you’re using Windows Authentication. For SQL Server Authentication, replace it with `User Id=YOUR_USERNAME;Password=YOUR_PASSWORD`.

### 3. Set Up the Database

After configuring your connection string, open a terminal in the project directory and run the following commands to apply migrations and set up the database schema:

```bash
dotnet ef database update
```

This command will create the database and all necessary tables as defined in the application’s Entity Framework models.

### 4. Run the Application

To start the application, use the following command:

```bash
dotnet run
```

The application will be hosted locally, typically at `http://localhost:5000` or `https://localhost:5001`.

Alternatively, you can run it through Visual Studio by pressing `F5` or selecting "Start Debugging."

### 5. Access the Application

Once the application is running, open a web browser and navigate to `http://localhost:5000` (or the URL shown in your terminal/IDE). You will see the home page of the MVC application.

### Project Structure

- **Controllers**: Contains the MVC controllers that handle requests and manage application logic.
- **Models**: Defines the data models for the application entities, including `Part`, `Quote`, `Project`, `User`, etc.
- **Views**: Holds the Razor views for each entity, such as `Part`, `Quote`, etc. Each entity has its own folder within the `Views` directory for organization.
- **Data**: (Assuming you have an `ApplicationDbContext` here) This folder includes the Entity Framework Core `DbContext` for managing database interactions.

### Key Features

- **CRUD Operations**: The application provides basic CRUD operations for managing parts, quotes, projects, and other related entities.
- **Entity Relationships**: The application handles relationships between entities like `Part`, `Quote`, and `Project` through Entity Framework Core, with navigational properties to easily manage related data.
- **MVC Architecture**: The project is built with the Model-View-Controller (MVC) pattern, making it easy to extend and maintain.
- **SQL Server Support**: Configured to use SQL Server by default, but can be reconfigured to support other relational databases if needed.

### Common Commands

Here are a few useful commands for managing the project:

- **Add a New Migration**: If you make changes to the models, run this command to create a new migration:
  ```bash
  dotnet ef migrations add MigrationName
  ```
  
- **Update the Database**: Apply the latest migrations to the database:
  ```bash
  dotnet ef database update
  ```

- **Run the Application**: Start the application locally:
  ```bash
  dotnet run
  ```

### Troubleshooting

- **Database Connection Errors**: Ensure your connection string in `appsettings.json` is correct and that SQL Server is running.
- **Entity Framework Issues**: Make sure that `dotnet-ef` tools are installed globally by running `dotnet tool install --global dotnet-ef`.
