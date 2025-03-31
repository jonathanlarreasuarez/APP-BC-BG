# Proyecto .NET 8

## Descripción
Este proyecto desarrollado en .NET 8 implementa un sistema de manejo de productos. Su objetivo principal es proporcionar una API para la gestión de productos, incluyendo operaciones de creación, actualización, eliminación y consulta.

## Requisitos
Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

- [.NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server] 

## Instalación
Sigue estos pasos para configurar y ejecutar el proyecto:

1. Clonar el repositorio:
   ```bash
   git clone https://jonathanlarreasuarez/APP-BC-BG.git
   cd proyecto
   ```
2. Restaurar las dependencias:
   ```bash
   dotnet restore
   ```
3. Configurar la base de datos en `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=MiBaseDeDatos;User Id=usuario;Password=contraseña;"
     }
   }
   ```
4. Ejecutar el script de base de datos ubicado en la carpeta `Scripts/` en el gestor de base de datos correspondiente.
5. Compilar y ejecutar:
   ```bash
   dotnet run
   ```

## Uso
Esta API permite gestionar productos con las siguientes operaciones:
- Obtener la lista de productos.
- Agregar nuevos productos.
- Editar productos existentes.
- Eliminar productos.

## API Endpoints
### Productos
- `GET /api/productos` - Obtiene una lista de productos.
- `GET /api/productos/{id}` - Obtiene los detalles de un producto específico.
- `POST /api/productos` - Crea un nuevo producto.
- `PUT /api/productos/{id}` - Actualiza un producto existente.
- `DELETE /api/productos/{id}` - Elimina un producto.

Para más detalles, consulta la documentación de la API.
