# 🎓 Grade Management System

**ASP.NET Core** application developed in **C#**, designed to efficiently manage student grades with advanced features including secure access control, detailed grade tracking, configurable parameters, and comprehensive reporting.

---

## 🚀 Project Highlights

- **Clean, modular architecture** using layered design for maintainability and scalability.
- Implements **role-based access control** ensuring secure and authorized operations.
- Full support for CRUD operations on students and grades.
- Built-in **grade calculations** and class average computations.
- **Custom exception handling** with meaningful error messages and logging.
- **Externalized configuration** for grading and password policies.
- Designed to handle large-scale data with **high performance** and reliability.

---

## 🧩 Key Features

- ✅ Add, update, delete and retrieve student records.
- 📝 Insert, update and validate student grades.
- 📊 Calculate final grades and class averages.
- 🔐 Password protection & validation for grade access.
- ⚠️ Detailed error handling using custom middleware.
- 🌐 RESTful API endpoints for integration with frontend or external systems.
- 🔎 Logging and monitoring using built-in ASP.NET Core tools.

---

## 🛠️ Technologies Used

- **ASP.NET Core**
- **C#**
- **Dependency Injection (DI)**
- **IOptions Configuration**

---

## 🔌 API Example

### `GET /api/students/{id}/grades`

**Request:**
```http
Authorization: Bearer <token>
```

**Response:**
```json
{
  "studentId": "123456789",
  "grades": [90, 85, 72],
  "average": 82.3
}
```

---

## ⚙️ Configuration Sample (`appsettings.json`)

```json
{
  "GradeManager": {
    "MinGrade": 0,
    "MaxGrade": 100,
    "PassGrade": 60
  },
  "PasswordManager": {
    "MinLength": 6,
    "RequireDigit": true,
    "RequireUppercase": true
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GradeDb;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

---

## 🧪 Getting Started

```bash
git clone https://github.com/your-username/grade-management-system.git

# Configure your appsettings.json:
# Add your connection string and grade/password configuration as shown above.

dotnet restore
dotnet build
dotnet ef database update
dotnet run
```

## 👨‍💻 Author

Developed by miryamizadka.

---
