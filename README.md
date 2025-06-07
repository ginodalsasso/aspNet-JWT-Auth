# Auth API (.NET Core)

## Overview

This is the **authentication and authorization API**, built with ASP.NET Core and Entity Framework Core.  
It handles **user registration**, **secure login**, **JWT generation**, **refresh token handling**, and **logout** without relying on external identity providers.

This service is meant to be consumed by a frontend such as a React or Next.js application.


## Features

- **User Registration & Login**  
  With hashed passwords using `PasswordHasher<T>`, stored securely in the database.

- **JWT Authentication**  
  Issue and validate access tokens for stateless API security.

- **Refresh Token Handling**  
  Issue and manage refresh tokens for maintaining sessions without storing server-side session data.

- **Logout Endpoint**  
  Revokes refresh tokens upon user logout.

- **Model Validation**  
  Server-side DTO validation with error feedback for frontend consumption.


## Technologies Used

- **Backend**: ASP.NET Core 8 Web API  
- **ORM**: Entity Framework Core  
- **Database**: SQL Server
- **Security**: JWT + Refresh Tokens  
- **Validation**: Data Annotations  
- **Dependency Injection**: Built-in .NET Core DI  
- **Tools**: Scalar for API testing


## Objectives

- Deepen understanding of **how authentication works with ASP.NET Core Web API**.
- Learn how to **organize and structure a clean, scalable API**, using a clear separation of concerns with DTOs, services, controllers, and entities.