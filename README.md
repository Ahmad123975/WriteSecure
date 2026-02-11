# Secure .NET 8 Web Application (API + Blazor)

This repository contains a full-stack .NET 8 application built with a secure Web API backend and a Blazor frontend.  

The solution is structured in a way that both the API and the frontend run as separate projects inside the same solution, following clean architecture and separation of concerns.

The backend handles authentication, authorization, and data access, while the Blazor project works as the client-side UI consuming the API.

---

## Solution Structure

The repository includes:

- Web API Project (Backend)
- Blazor Project (Frontend UI)
- Shared database (SQL Server)

Both projects run independently but work together as a single application.

---

## Backend (Web API)

The API is built using .NET 8 Web API and focuses on security and proper architecture.

### Main Features

- User Registration and Login
- JWT Authentication
- Role-Based Authorization (Admin, Manager, User)
- Password hashing using BCrypt
- HTTP-only secure cookie for JWT storage
- Custom middleware for centralized request handling
- Entity Framework Core with SQL Server

### Security Implementation

- Passwords are hashed using BCrypt (no plaintext storage)
- JWT tokens include user claims and roles
- Token validation (issuer, audience, expiry, signing key)
- HTTP-only and Secure cookie configuration
- Protected endpoints using `[Authorize]` attribute

---

## Frontend (Blazor)

The Blazor project acts as the frontend client.

- Communicates with the API using HTTP requests
- Handles login and registration forms
- Consumes protected endpoints
- Implements frontend validation
- Displays role-based content depending on user permissions

The frontend and backend run separately but are part of the same solution.

---

## Technologies Used

- .NET 8
- ASP.NET Core Web API
- Blazor
- Entity Framework Core
- SQL Server
- JWT Bearer Authentication
---

## How to Run

1. Run the Web API project.
2. Run the Blazor project.
3. Make sure the API base URL is correctly configured inside the Blazor project.
4. Ensure the database connection string is properly set in appsettings.json.

---

## Purpose of the Project

This project was built to practice and demonstrate:

- Secure authentication and authorization
- Role-based access control
- Clean project structure
- Backend and frontend integration using .NET
- Industry-standard security practices

The goal was to understand how a real-world secure application is structured and implemented.
