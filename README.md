# 🛍️ Product Management System API

> A modern, minimal ASP.NET Core 10 REST API for managing products, categories, suppliers, and customers using Entity Framework Core and SQL Server.

[![.NET Version](https://img.shields.io/badge/.NET-10-blue?style=flat-square&logo=.net)](https://dotnet.microsoft.com/)
[![Language](https://img.shields.io/badge/Language-C%23-purple?style=flat-square&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)](LICENSE)
[![GitHub](https://img.shields.io/badge/GitHub-Repo-black?style=flat-square&logo=github)](https://github.com/KuraiKutsuki/Patanao_BSIT-3A_Minimal_API)

---

## 📑 Table of Contents

- [✨ Overview](#-overview)
- [📂 Project Structure](#-project-structure)
- [⚙️ Prerequisites](#️-prerequisites)
- [🚀 Installation & Setup](#-installation--setup)
- [🗄️ Database Configuration](#️-database-configuration)
- [📡 API Endpoints](#-api-endpoints)
- [📊 Models](#-models)
- [🛠️ Technologies](#️-technologies)
- [💻 Development](#-development)
- [👨‍💻 Created By](#-created-by)

## ✨ Overview

The **Product Management System API** is a robust, minimal API demonstration project built with **ASP.NET Core 10**. It provides a comprehensive REST API for managing:

| Category | Purpose |
|----------|---------|
| 📦 **Products** | Product information with pricing and stock management |
| 🏷️ **Categories** | Product categories and classifications |
| 🚚 **Suppliers** | Supplier information for products |
| 👥 **Customers** | Customer data management |

✅ **Features:**
- Entity Framework Core with SQL Server integration
- CORS configuration for cross-origin requests
- Swagger/OpenAPI documentation
- RESTful API design
- Data validation and error handling

## 📂 Project Structure

```
ProductAPIDemo/
├── 📁 Controllers/
│   ├── ProductController.cs           # Product endpoints
│   ├── CategoryController.cs           # Category endpoints
│   ├── SupplierController.cs           # Supplier endpoints
│   ├── CustomerController.cs           # Customer endpoints
│   └── WeatherForecastController.cs    # Sample controller
├── 📁 Models/
│   ├── Product.cs                      # Product entity
│   ├── Category.cs                     # Category entity
│   ├── Supplier.cs                     # Supplier entity
│   └── Customer.cs                     # Customer entity
├── 📁 Data/
│   └── ApplicationDBContext.cs         # EF Core DbContext
├── 📁 Migrations/
│   └── [Database migration files]      # EF Core migrations
├── 🔧 Program.cs                       # Application configuration
├── ⚙️ appsettings.json                 # Configuration settings
├── 🔧 appsettings.Development.json     # Development settings
└── 📄 ProductAPIDemo.http              # HTTP test file
```

## ⚙️ Prerequisites

| Requirement | Version |
|-------------|---------|
| **.NET SDK** | 10.0 or later |
| **SQL Server** | Express or Full Edition |
| **IDE** | Visual Studio 2026 or compatible |

## 🚀 Installation & Setup

### Step 1️⃣ - Clone the Repository
```bash
git clone https://github.com/KuraiKutsuki/Patanao_BSIT-3A_Minimal_API.git
cd ProductAPIDemo
```

### Step 2️⃣ - Install Dependencies
```bash
dotnet restore
```

### Step 3️⃣ - Configure Database Connection
Update the `appsettings.json` file with your SQL Server connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=ProductDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### Step 4️⃣ - Apply Database Migrations
```bash
dotnet ef database update
```

### Step 5️⃣ - Run the Application
```bash
dotnet run
```

The API will be available at `https://localhost:7xxx` 🎉

## 🗄️ Database Configuration

### 📌 Connection String Details

| Property | Value |
|----------|-------|
| **Server** | LAPTOP-KM40AQV7\SQLEXPRESS |
| **Database** | ProductDB |
| **Authentication** | Windows Authentication (Trusted Connection) |

### 🔐 Update Connection String
Edit `appsettings.json` to change the connection:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ProductDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 📦 Database Context
The `ApplicationDBContext` manages all database operations with DbSets for:
- ✅ Products
- ✅ Categories
- ✅ Suppliers
- ✅ Customers

## 📡 API Endpoints

### 📦 Products
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/product` | Get all products |
| `GET` | `/api/product/{id}` | Get a specific product |
| `POST` | `/api/product` | Create a new product |
| `PUT` | `/api/product/{id}` | Update a product |
| `DELETE` | `/api/product/{id}` | Delete a product |

### 🏷️ Categories
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/category` | Get all categories |
| `GET` | `/api/category/{id}` | Get a specific category |
| `POST` | `/api/category` | Create a new category |
| `PUT` | `/api/category/{id}` | Update a category |
| `DELETE` | `/api/category/{id}` | Delete a category |

### 🚚 Suppliers
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/supplier` | Get all suppliers |
| `GET` | `/api/supplier/{id}` | Get a specific supplier |
| `POST` | `/api/supplier` | Create a new supplier |
| `PUT` | `/api/supplier/{id}` | Update a supplier |
| `DELETE` | `/api/supplier/{id}` | Delete a supplier |

### 👥 Customers
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/customer` | Get all customers |
| `GET` | `/api/customer/{id}` | Get a specific customer |
| `POST` | `/api/customer` | Create a new customer |
| `PUT` | `/api/customer/{id}` | Update a customer |
| `DELETE` | `/api/customer/{id}` | Delete a customer |

## 📊 Models

### 📦 Product
```csharp
public class Product
{
    public int ProductID { get; set; }                    // Primary Key
    public string Name { get; set; }                      // Product Name
    public string Description { get; set; }               // Description
    public decimal Price { get; set; }                    // Price (Range: 1 - 1,000,000)
    public int Stock { get; set; }                        // Stock (Range: 0 - 10,000)
    public int CategoryID { get; set; }                   // Foreign Key
    public Category? Category { get; set; }               // Navigation Property
    public int SupplierID { get; set; }                   // Foreign Key
    public Supplier? Supplier { get; set; }               // Navigation Property
}
```

### 🏷️ Category
```csharp
public class Category
{
    public int CategoryID { get; set; }                   // Primary Key
    public string Name { get; set; }                      // Category Name
    public string Description { get; set; }               // Description
    public ICollection<Product> Products { get; set; }    // Navigation Property
}
```

### 🚚 Supplier
```csharp
public class Supplier
{
    // Properties defined in Supplier.cs
}
```

### 👥 Customer
```csharp
public class Customer
{
    // Properties defined in Customer.cs
}
```

## Configuration Features

### 🔐 CORS Configuration
The application is configured with "AllowAll" policy for cross-origin requests:
- ✅ Allows any origin
- ✅ Allows any HTTP method
- ✅ Allows any header

### 📚 Swagger/OpenAPI
| Environment | Status |
|-------------|--------|
| **Development** | ✅ Swagger UI at `/swagger/ui` |
| **Production** | ❌ OpenAPI endpoints disabled |

### 🔒 HTTPS Redirection
- ✅ HTTPS redirection enabled for all requests

## 🛠️ Technologies

| Technology | Purpose |
|-----------|---------|
| **ASP.NET Core 10** | Web Framework |
| **Entity Framework Core** | ORM |
| **SQL Server** | Database |
| **Swagger/OpenAPI** | API Documentation |
| **C#** | Programming Language |

## 💻 Development

### 🧪 Testing the API
Use one of these tools to test the API:
- 📊 **Swagger UI** (built-in)
- 📮 **Postman**
- 🐛 **Insomnia**
- 📄 **ProductAPIDemo.http** file in Visual Studio

### 📦 Creating Database Migrations
```bash
# Create a new migration
dotnet ef migrations add MigrationName

# Apply migrations to database
dotnet ef database update
```

## 👨‍💻 Created By

| Field | Details |
|-------|---------|
| **Developer** | Asthan Eilexer J. Patanao |
| **Section** | BSIT-3A |
| **Project** | Product Management System API |
