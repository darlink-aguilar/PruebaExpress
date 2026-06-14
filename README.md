**Prueba Técnica API REST**

El sistema simula una prueba técnica backend para la gestión de Empresas y Máquinas, conectándose a una base de datos relacional en SQL Server. El objetivo principal de este proyecto fue implementar un **MVP (Producto Mínimo Viable)** rápido, seguro y eficiente, aplicando buenas prácticas de desarrollo en un enfoque ágil.

**Arquitectura del Proyecto**

Este proyecto utiliza una **Arquitectura de Capas Simplificada**. La lógica de la aplicación se organiza de la siguiente manera:

* **Capas de Controladores (Controllers):** Actúa como el punto de entrada de la aplicación. Gestiona las peticiones HTTP (`GET`, `POST`, `PUT`, `DELETE`), valida las solicitudes y devuelve las respuestas con los códigos de estado HTTP correspondientes (`200 OK`, `201 Created`, `204 NoContent`, `404 NotFound`).
* **Capa de Modelos/Acceso a Datos (Data Context):** Implementa el enfoque *Database-First* mapeando directamente las tablas existentes en SQL Server mediante `DbContext` y entidades con anotaciones de datos (`DataAnnotations`).
* **Capa de Transferencia (DTOs):** Utiliza Objetos de Transferencia de Datos (`Data Transfer Objects`) para aislar las entidades de la base de datos de la capa de presentación. Esto optimiza el consumo del API y protege la integridad de los datos.

**Tecnologías Utilizadas**

* **Backend:** C# con .NET 8.0
* **ORM:** Entity Framework Core (SQL Server & Tools)
* **Base de Datos:** SQL Server (Transact-SQL)
* **Documentación:** Swagger / OpenAPI
