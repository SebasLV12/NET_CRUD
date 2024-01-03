
# Proyecto CRUD de Facultades y Carreras
Este proyecto es una aplicación CRUD (Crear, Leer, Actualizar, Eliminar) desarrollada en ASP .NET FRAMEWORK que gestiona información sobre facultades y carreras en una institución educativa.

Tecnologías Utilizadas
ASP.NET MVC
Entity Framework (Code First)
C#

Configuración del Proyecto
Clonar el Repositorio:

bash
Copy code
git clone https://github.com/SebasLV12/Prayaga_CRUD/

Configurar la Base de Datos:

    -- Crear tabla 'facultad'
    CREATE TABLE facultad (
        id INT PRIMARY KEY,
        nombre_facultad VARCHAR(255),
        codigo_facultad VARCHAR(50),
        creado_tmstp TIMESTAMP,
        actualizado_tmstp TIMESTAMP,
        eliminado BIT,
    );
    
    -- Crear tabla 'carrera'
    CREATE TABLE carrera (
        id INT PRIMARY KEY,
        facultad INT,
        nombre_carrera VARCHAR(255),
        codigo_carrera VARCHAR(50),
        creado_tmstp TIMESTAMP,
        actualizado_tmstp TIMESTAMP,
        FOREIGN KEY (facultad) REFERENCES facultad(id),
      eliminado BIT,
    );
Asegúrese de tener una instancia de SQL Server disponible.
Modifique la cadena de conexión en Web.config para apuntar a su base de datos.
Ejecutar la Aplicación:

Abra el proyecto en Visual Studio.
Asegúrese de tener todas las dependencias instaladas.
Ejecute la aplicación.
Endpoints Disponibles:

## Facultades:

- Obtener todas las facultades: GET /Facultad/Index
- Obtener detalles de una facultad: GET /Facultad/Details/{id}
- Crear una nueva facultad: POST /Facultad/Create
- Editar una facultad existente: POST /Facultad/Edit/{id}
- Eliminar (lógicamente) una facultad: POST /Facultad/Delete/{id}
- Obtener facultades eliminadas: GET /Facultad/GetDeleted

## Carreras:

- Obtener todas las carreras: GET /Carreras/Index
- Obtener detalles de una carrera: GET /Carreras/Details/{id}
- Crear una nueva carrera: POST /Carreras/Create
- Editar una carrera existente: POST /Carreras/Edit/{id}
- Eliminar (lógicamente) una carrera: POST /Carreras/Delete/{id}
