# CajaMorelia
# API Clientes - Evaluación Técnica

Este proyecto es una API REST construida en **.NET 6+** con arquitectura **hexagonal**, que permite la gestión de la entidad `Cliente`. Incluye funcionalidades CRUD, validación de API Key mediante middleware, y separación por capas usando buenas prácticas de Clean Architecture.

---

## 🧱 Tecnologías utilizadas

- .NET 8
- Entity Framework Core (SQLite)
- Arquitectura Hexagonal (Ports & Adapters)
- Swagger / OpenAPI
- Inyección de dependencias (DI)
- Middleware personalizado (API Key)

---

## 📂 Estructura del proyecto

```plaintext
src/
├── Api/                    → Controladores, Middleware y Program.cs
├── Application/           → Servicios de aplicación (casos de uso), DTOs
├── Domain/                → Entidades y contratos (interfaces)
├── Infrastructure/        → Repositorios, DbContext, EF Core, Adapters
