# Librería Sparrow

Sistema de gestión y venta en línea para una librería, reescrito como práctica de arquitectura backend en C#.

> Segunda versión de un proyecto universitario original en Flask + MongoDB, reconstruido con foco en buenas prácticas: separación en capas, base de datos relacional y manejo seguro de configuración.

## Stack

- **Backend**: ASP.NET Core Web API (.NET 10)
- **Base de datos**: SQL Server + Entity Framework Core
- **Frontend**: React
- **Arquitectura**: Controllers → Services → Repositories

## Estado del proyecto

🚧 En construcción — este README se irá actualizando a medida que avance cada etapa.

- [ ] Modelado de entidades y migraciones
- [ ] Endpoints CRUD (libros, clientes, pedidos, proveedores)
- [ ] Autenticación para el panel de administración
- [ ] Frontend en React
- [ ] Despliegue

## Cómo correrlo localmente

```bash
cd LibreriaSparrow.Api
dotnet restore
dotnet ef database update
dotnet run
```

Necesitas configurar tu cadena de conexión con `dotnet user-secrets` (ver sección de configuración más abajo, o el historial del desarrollo del proyecto).

## Diagrama de entidades

_(agregar captura del ERD aquí)_
