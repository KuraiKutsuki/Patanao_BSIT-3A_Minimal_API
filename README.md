# Product Management System API

A minimal ASP.NET Core 10 REST API for managing products, categories, suppliers, and customers using Entity Framework Core and SQL Server.

## 📋 Table of Contents
- [Overview](#overview)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Installation & Setup](#installation--setup)
- [Database Configuration](#database-configuration)
- [API Endpoints](#api-endpoints)
- [Models](#models)
- [Technologies](#technologies)

## Overview

The **Product Management System API** is a minimal API demonstration project built with ASP.NET Core 10. It provides a complete REST API for managing:
- **Products** - Product information with pricing and stock management
- **Categories** - Product categories and classifications
- **Suppliers** - Supplier information for products
- **Customers** - Customer data management

The API uses Entity Framework Core with SQL Server for data persistence and includes CORS configuration for cross-origin requests.

## Project Structure

```
ProductAPIDemo/
├── Controllers/
│   ├── ProductController.cs
│   ├── CategoryController.cs
│   ├── SupplierController.cs
│   ├── CustomerController.cs
│   └── WeatherForecastController.cs
├── Models/
│   ├── Product.cs
│   ├── Category.cs
│   ├── Supplier.cs
│   └── Customer.cs
├── Data/
│   └── ApplicationDBContext.cs
├── Migrations/
│   └── [Database migration files]
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
└── ProductAPIDemo.http
```

## Prerequisites

- .NET 10 SDK or later
- SQL Server (Express or full version)
- Visual Studio 2026 (or any compatible IDE)

## Installation & Setup

1. **Clone the repository**
```
git clone https://github.com/KuraiKutsuki/Patanao_BSIT-3A_Minimal_API.git
cd ProductAPIDemo
```

2. **Install dependencies**
```
dotnet restore
```

3. **Configure the database connection**

   Update the `appsettings.json` file with your SQL Server connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=ProductDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

4. **Apply migrations**
```
dotnet ef database update
```

5. **Run the application**
```
dotnet run
```

The API will be available at `https://localhost:7xxx` (port depends on your configuration).

## Database Configuration

### Connection String
The application uses SQL Server with the following default configuration:
- **Server**: LAPTOP-KM40AQV7\SQLEXPRESS
- **Database**: ProductDB
- **Authentication**: Windows Authentication (Trusted Connection)

Edit `appsettings.json` to change the connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ProductDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Database Context
The `ApplicationDBContext` class manages all database operations and includes DbSets for:
- Products
- Categories
- Suppliers
- Customers

## API Endpoints

### Products
- `GET /api/product` - Get all products
- `POST /api/product` - Create a new product
- `PUT /api/product/{id}` - Update a product
- `DELETE /api/product/{id}` - Delete a product
- `GET /api/product/{id}` - Get a specific product

### Categories
- `GET /api/category` - Get all categories
- `POST /api/category` - Create a new category
- `PUT /api/category/{id}` - Update a category
- `DELETE /api/category/{id}` - Delete a category

### Suppliers
- `GET /api/supplier` - Get all suppliers
- `POST /api/supplier` - Create a new supplier
- `PUT /api/supplier/{id}` - Update a supplier
- `DELETE /api/supplier/{id}` - Delete a supplier

### Customers
- `GET /api/customer` - Get all customers
- `POST /api/customer` - Create a new customer
- `PUT /api/customer/{id}` - Update a customer
- `DELETE /api/customer/{id}` - Delete a customer

## Models

### Product
```csharp
public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }        // Range: 1 - 1,000,000
    public int Stock { get; set; }            // Range: 0 - 10,000
    public int CategoryID { get; set; }
    public Category? Category { get; set; }
    public int SupplierID { get; set; }
    public Supplier? Supplier { get; set; }
}
```

### Category
```csharp
public class Category
{
    public int CategoryID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; }
}
```

### Supplier
```csharp
public class Supplier
{
    // Properties defined in Supplier.cs
}
```

### Customer
```csharp
public class Customer
{
    // Properties defined in Customer.cs
}
```

## Configuration Features

### CORS
The application is configured to allow cross-origin requests with the "AllowAll" policy:
- Allows any origin
- Allows any HTTP method
- Allows any header

### Swagger/OpenAPI
- **Development**: Swagger UI is available at `/swagger/ui`
- **Production**: OpenAPI endpoints are disabled

### HTTPS Redirection
HTTPS redirection is enabled for all requests.

## Technologies

- **Framework**: ASP.NET Core 10
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **API Documentation**: Swagger/OpenAPI
- **Language**: C#

## Development

### Testing the API
Use the provided `ProductAPIDemo.http` file to test endpoints in Visual Studio or use tools like:
- Swagger UI (built-in)
- Postman
- Insomnia

### Database Migrations
To create a new migration:
```
dotnet ef migrations add MigrationName
dotnet ef database update
```

## License

This project is part of the BSIT-3A coursework.

## Support

For issues or questions, please visit the [GitHub Repository](https://github.com/KuraiKutsuki/Patanao_BSIT-3A_Minimal_API).
