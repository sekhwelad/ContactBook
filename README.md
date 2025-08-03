# Address Book API

A robust and modular **Address Book Web API** built with:

- ASP.NET Core 8
- Clean Architecture
- Domain-Driven Design (DDD)
- CQRS with MediatR
- Hybrid Data Access: Entity Framework Core + Dapper
- Swagger (OpenAPI) for API documentation

---

## Architectural Overview

This project follows the **Clean Architecture** and **DDD**. Each layer has a clear responsibility:

**AddressBook.sln**

  - **AddressBook.Api** → API layer (Controllers, Middleware, OpenApi, Extensions)
  - **AddressBook.Application** → Application layer (Commands, Queries, Middleware, Abstractions, Exceptions)
  - **AddressBook.Domain** → Domain models and business logic
  - **AddressBook.Infrastructure** → Data access (EF Core, Dapper, SQL, Services)

## Features

- Create Profile
- Get Paginated Profiles
- Upload Profile Picture
- Delete Profile (To Do)
- Swagger UI

## Future Improvements

- Migrate file uploads to AWS S3
- Add Role based Authorization
- Introduce caching with Redis
- Add Unit , Architecture and Integration Tests
- Implement Logging with Serilog or Datadog

## Getting Started

**To Run the APP
<pre> Go tp Package Manager Console <br>Add-Migration Migration-Name<br> Update-Database </pre>


## Author
**Delight Sekhwela**<br>
Senior Fullstack Developer
  
