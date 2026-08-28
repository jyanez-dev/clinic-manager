# ClinicManager — Backend

## Descripción

ClinicManager es una aplicación para la gestión de un consultorio médico.

Actualmente, el proyecto contiene el backend desarrollado con **C# y ASP.NET Core Web API**, utilizando **PostgreSQL** como sistema gestor de base de datos.

## Tecnologías

* C#
* ASP.NET Core Web API
* .NET 10
* Entity Framework Core
* PostgreSQL 18.6
* Npgsql
* pgAdmin 4
* Swagger / OpenAPI
* Git

## Requisitos

El siguiente software es necesario para preparar el entorno de desarrollo:

* PostgreSQL 18.6
* pgAdmin 4
* .NET SDK 10
* Visual Studio
* Git

## Instalación y Configuración

### 1. Obtener el código fuente

Clonar el repositorio o actualizar una copia existente:

```bash
git pull
```

### 2. Crear la base de datos

Crear una base de datos en PostgreSQL/pgAdmin con la siguiente configuración:

* **Base de datos:** `ClinicManagerDB`
* **Propietario:** `postgres`
* **Puerto:** `5432`

Antes de ejecutar el esquema, verificar que el Query Tool esté conectado a `ClinicManagerDB`.

### 3. Crear la estructura de la base de datos

El proyecto contiene los siguientes script:

```text
C:\Projects\ClinicManager\database\scripts\ClinicManagerSchemaPostgreSQL.sql
C:\Projects\ClinicManager\database\scripts\triggers.sql
```

Abrir estos archivo utilizando el Query Tool de pgAdmin conectado a `ClinicManagerDB` y ejecutar los scripts completos.

El esquema crea:

* 14 tablas
* Columnas Identity
* Claves primarias
* Claves foráneas
* Restricciones únicas
* Función `set_edit_date()`
* Triggers para actualizar `edit_date`
* Valores predeterminados para `create_date`

### 4. Cargar los datos iniciales

Ejecutar:

```text
C:\Projects\ClinicManager\database\scripts\Initial Inserts Pg.sql
```

Este script contiene los datos iniciales necesarios para el funcionamiento de la aplicación, incluyendo:

* Roles
* Tipos de documento
* Estados de citas
* Tipos de registros
* Usuario administrador
* Especialidades
* Posiciones

### 5. Configurar la conexión

La Web API utiliza una cadena de conexión PostgreSQL similar a:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=ClinicManagerDB;Username=postgres;Password=..."
}
```

**No almacenar contraseñas reales en el repositorio.**

Para entornos de desarrollo se recomienda utilizar User Secrets o variables de entorno.

### 6. Restaurar los paquetes

Desde la terminal de Visual Studio, dentro de la carpeta del proyecto:

```bash
dotnet restore
```

Si es necesario, instalar el paquete para la convención de nombres:

```bash
dotnet add package EFCore.NamingConventions
```

Instalar `Npgsql.EntityFrameworkCore.PostgreSQL` utilizando la **Package Manager Console**:

```powershell
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
```

O instalarlo utilizando la **Terminal**:

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

### 7. Compilar el proyecto

```bash
dotnet build
```

El proyecto debe finalizar correctamente mostrando:

```text
Build succeeded.
```

### 8. Ejecutar la API

```bash
dotnet run
```

La consola mostrará las URL en las que la API está escuchando.

### 9. Probar Swagger

Abrir la dirección HTTPS indicada por `dotnet run` y agregar:

```text
/swagger
```

Por ejemplo:

```text
https://localhost:7283/swagger
```

Desde Swagger se pueden ejecutar y verificar los endpoints de la Web API.

## Base de datos y fechas

Los campos `create_date` utilizan:

```sql
DEFAULT CURRENT_TIMESTAMP
```

Los campos `edit_date` se actualizan automáticamente mediante triggers cuando se modifica un registro.

La aplicación utiliza `timestamp without time zone` para los campos de fecha y hora definidos en PostgreSQL.

## Estado actual del Backend

El backend fue adaptado para trabajar con PostgreSQL y su funcionalidad fue verificada en dos equipos.

Se verificaron los siguientes puntos:

* Código fuente actualizado mediante Git.
* Instalación de PostgreSQL 18.6.
* Creación de `ClinicManagerDB`.
* Restauración del schema.
* Creación de las 14 tablas.
* Primary Keys y Foreign Keys.
* Unique Constraints.
* Función y triggers.
* Datos iniciales.
* Configuración de Entity Framework Core y Npgsql.
* Conexión de la Web API con PostgreSQL.
* Compilación de la aplicación.
* Ejecución de la API.
* Consulta de datos mediante un endpoint GET.
* Respuesta JSON correcta.

La migración del entorno de desarrollo a la laptop se completó satisfactoriamente.

## Próximos pasos

* Probar los endpoints utilizando Postman.
* Documentar las pruebas realizadas con Postman.
* Continuar posteriormente con el desarrollo del frontend.
* Mantener sincronizados el código fuente, schema y datos iniciales en el repositorio.
