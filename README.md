# ProductManagementApp

A full-stack ASP.NET Core web application for managing products, users, and categories with JWT authentication and role-based access control.

## Features

- **Product Management**
  - Create, Read, Update, Delete (CRUD) operations
  - Category association
  - Price validation
- **User System**
  - Registration & Authentication with JWT
  - Role-based access (Admin/User)
  - Password hashing
- **Category Management**
  - CRUD operations for product categories
- **Security**
  - JWT token authentication
  - Role-based authorization
  - CSRF protection
- **UI Features**
  - Responsive Razor Pages
  - Client & server-side validation
  - Interactive forms
  - Error handling

---

## Technologies

- **Backend**: ASP.NET Core 8, Entity Framework Core
- **Frontend**: Razor Pages, HTML5, CSS3
- **Database**: SQLite
- **Authentication**: JWT Bearer Tokens
- **Testing**: xUnit, Moq
- **Tools**: LINQ, Dependency Injection

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- IDE (Visual Studio 2022+ or VS Code)
- Web browser

### Step 1: Clone the Repository

```bash
git clone https://github.com/AntonioHincapie/ProductManagementApp.git
cd ProductManagementApp
```

### Step 2: Install dependencies

```bash
dotnet restore
```

### Step 3: Add configuration

Update `appsettigns.json` in the project root to your correct setup.

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=Products.db"
  },
  "Jwt": {
    "SecretKey": "your-256-bit-secret-key-here",
    "Issuer": "ProductManagementApp",
    "Audience": "AppUsers",
    "ExpiryInMinutes": 60
  }
}
```

### Step 4: Database setup

```bash
dotnet ef database update
```

### Step 5: Run the application

```bash
dotnet run
```

The app will be accessible at the following URL:

- Login: [http://localhost:5000](http://localhost:5000)

### Optional: Run unit tests

```bash
dotnet tests
```

---

## Scripts

### Important Scripts

| Command          | Description                              |
| ---------------- | ---------------------------------------- |
| `dotnet clean`   | Cleans the output of the previous build. |
| `dotnet build`   | Builds the project and its dependencies. |
| `dotnet restore` | Installs the tools that are listed.      |

---

## API Endpoints

### **Backend API (http://localhost:5000)**

| Method | Endpoint                 | Description              |
| ------ | ------------------------ | ------------------------ |
| GET    | `/api/Product`           | Get all products.        |
| GET    | `/api/Product/{id}`      | Get product by Id.       |
| POST   | `/api/Product`           | Create a product.        |
| PUT    | `/api/Product/{id}`      | Update a product.        |
| DELETE | `/api/Product/{id}`      | Delete a product.        |
| GET    | `/api/Category`          | Get all categories.      |
| GET    | `/api/Category/{id}`     | Get category by Id.      |
| POST   | `/api/Category`          | Create a category.       |
| PUT    | `/api/Category/{id}`     | Update a category.       |
| DELETE | `/api/Category/{id}`     | Delete a category.       |
| POST   | `/api/User/register`     | Register a new User.     |
| POST   | `/api/User/authenticate` | Create a tokento a user. |
| GET    | `/api/User`              | Get all the users        |
| GET    | `/api/User/{id}`         | Get a user by Id.        |
| PUT    | `/api/User/{id}`         | Update a user.           |
| DELETE | `/api/User/{id}`         | Delete a user.           |
| POST   | `/api/Auth/login`        | Login endpoint.          |
| DELETE | `/api/Auth/logout`       | Logout endpoint.         |

---

## Troubleshooting

### Common Issues

1. **Port conflicts:**

   - Make sure port `5000` are not in use by other applications or check the logs to see what port is listening.

---

## License

This project is licensed under the [MIT](./LICENSE) License. See the LICENSE file for details.

---

## Author

## 👤 **Marco Antonio Hincapié Montes**

- GitHub: [@AntonioHincapie](https://github.com/AntonioHincapie)

- LinkedIn: [LinkedIn](https://www.linkedin.com/in/antoniohincapie/)
