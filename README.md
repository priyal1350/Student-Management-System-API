# 📚 Student Management System API

## 📌 Project Overview

This is a **RESTful API** built using **ASP.NET Core Web API** for managing student records.
The project follows a **layered architecture** and includes **JWT authentication**, **exception handling**, and **API documentation using Swagger**.

---

## 🛠️ Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* Swagger (API Documentation)
* Built-in Logging

---

## 🏗️ Project Architecture

The project follows a clean layered architecture:

* **Controllers** → Handle HTTP requests
* **Services** → Business logic
* **Repositories** → Data access layer
* **Models** → Database entities
* **DTOs** → Data transfer objects
* **Middleware** → Global exception handling

---

## 🔐 Authentication (JWT)

* JWT token is generated using `/api/Auth/login`
* Secured endpoints require token in header

### 📥 Header Format:

Authorization: Bearer <your_token>

---

## 📌 API Endpoints

### 🔑 Auth

* **POST** `/api/auth/login` → Generate JWT Token

---

### 🎓 Student APIs

* **GET** `/api/student` → Get all students
* **GET** `/api/student/{id}` → Get student by ID
* **POST** `/api/student` → Add new student
* **PUT** `/api/student/{id}` → Update student
* **DELETE** `/api/student/{id}` → Delete student

---

## 🧾 Sample Request (POST Student)

```json
{
  "name": "Priyal",
  "email": "priyal@gmail.com",
  "age": 23,
  "course": "MCA"
}
```

---

## ⚠️ Important Notes

* Do NOT send `Id` while creating a new student (auto-generated)
* JWT authentication is required for secured APIs
* Swagger is used for API documentation
* Postman is used for testing secured endpoints with JWT

---

## 📊 Swagger Documentation

Run the project and open:

http://localhost:5200/swagger

---

## 🧪 Testing

* Swagger → API structure & basic testing
* Postman → JWT secured API testing

---

## 🛡️ Exception Handling

Global exception handling is implemented using middleware to handle runtime errors gracefully.

---

## 📈 Logging

Basic logging is implemented using ASP.NET Core built-in logging.

---

## 👨‍💻 Author

Priyal Jain

---

## 🎯 Conclusion

This project demonstrates:

* Clean architecture
* Secure API development using JWT
* Proper error handling
* RESTful API design principles
