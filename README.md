# TaskFlowManager (.NET 9)

TaskFlowManager is a clean, modular task management system built using **ASP.NET Core 9**, **GraphQL**, and **RESTful APIs**. It enables efficient tracking and management of **departments**, **users**, **projects**, and **tasks**, with robust validation, global exception handling, and rich data querying support.

---

## 🚀 Features

- ✅ Full CRUD operations for:
  - Departments
  - Users
  - Projects
  - Tasks
- 🔀 Dual API support:
  - REST (with unified `RestResponse<T>`)
  - GraphQL (via HotChocolate)
- 🔐 Validation with custom rule sets
- ⚠️ Centralized exception handling middleware
- 🧭 API versioning support
- 🌐 Swagger documentation (enabled in Development)
- 📦 AutoMapper for DTO ↔ Entity mapping
- 🧬 MySQL (via Pomelo) with EF Core 9
- 🧩 Modular service/repository registration
- 📅 Timezone aware (Asia/Dhaka)
- 🗂️ Clean and scalable architecture

---

## 🛠️ Tech Stack

- **.NET 9.0**
- **ASP.NET Core Web API**
- **HotChocolate GraphQL**
- **Entity Framework Core (Pomelo for MySQL)**
- **AutoMapper**
- **Swagger/OpenAPI**
- **API Versioning**
- **Custom Validation + Exception Middleware**

---

## 📁 Project Structure

- `Controllers/` – REST endpoints per entity
- `Resolvers/` – GraphQL queries and mutations
- `Services/` – Business logic layer with validation
- `Repositories/` – Data access abstractions
- `Models/` – Entity definitions (EF Core)
- `Dto/Request`, `Dto/Response` – Structured request/response DTOs
- `Infrastructure/Dto` – Generic wrappers like `RestResponse<T>`
- `Middlewares/` – Global exception handling
- `Validators/` – Custom field-level validation logic
- `DependencyInjection/` – Clean registration for DI

---

## 🔗 REST API Endpoints

Base URL: `http://localhost:8080/api/v1`

| Resource   | Method | Endpoint              |
|------------|--------|-----------------------|
| Departments| GET    | /departments          |
|            | GET    | /departments/{id}     |
|            | POST   | /departments          |
|            | PUT    | /departments/{id}     |
|            | DELETE | /departments/{id}     |
| Projects   | GET    | /projects             |
|            | GET    | /projects/{id}        |
|            | POST   | /projects             |
|            | PUT    | /projects/{id}        |
|            | DELETE | /projects/{id}        |
| Tasks      | GET    | /tasks                |
|            | GET    | /tasks/{id}           |
|            | POST   | /tasks                |
|            | PUT    | /tasks/{id}           |
|            | DELETE | /tasks/{id}           |
| Users      | GET    | /users                |
|            | GET    | /users/{id}           |
|            | POST   | /users                |
|            | PUT    | /users/{id}           |
|            | DELETE | /users/{id}           |

---

## 📡 GraphQL API

- URL: `http://localhost:8080/api/v1/graphql`
- Playground UI available via HotChocolate if enabled.
- Supports full CRUD operations with:
  - `getDepartments`, `getProjects`, `getTasks`, `getUsers`
  - `createX`, `updateX`, `deleteX` mutations

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- [MySQL Server 8+](https://www.mysql.com/)
- (Optional) [GraphQL Voyager](https://github.com/APIs-guru/graphql-voyager) or Playground

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/mdmosfikurrahman/Task-Flow-Manager.git
   cd Task-Flow-Manager
   ```

2. Update the database connection in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "TaskFlowManagerDb": "server=localhost;port=3306;user=root;password=root;database=TaskFlowManager"
   }
   ```

3. Run the project:
   ```bash
   dotnet run --launch-profile "Task-Flow-Manager"
   ```

4. Access:
   - REST Docs: [http://localhost:8080/swagger](http://localhost:8080/swagger)
   - GraphQL: [http://localhost:8080/api/v1/graphql](http://localhost:8080/api/v1/graphql)

---

## 📌 Notes

- Uses MySQL as backend, via Pomelo EF Core provider
- Uses AutoMapper with convention-based mapping
- Custom middlewares and validators ensure clean architecture
- Timezone: `Asia/Dhaka`

---

## 📄 License

This project is licensed under the MIT License.

---

> Built with ❤️ by Mosfik for robust enterprise-ready task flow management.
