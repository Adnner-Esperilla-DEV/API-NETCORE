# 🚀 Guía para Ejecutar la API ESPERILLA en .NET Core

Este documento describe los pasos necesarios para configurar y ejecutar la API ESPERILLA en un entorno local.

---

## 📌 Requisitos Previos

- Tener instalado **.NET SDK** compatible con el proyecto.
- Un gestor de base de datos SQL Server.
- Visual Studio o Visual Studio Code.

---

## ⚙️ Configuración de la Base de Datos

1. **Actualizar las rutas de conexión** en los siguientes archivos:
   - `ESPERILLA.Gateways.SqlServer/DataContext/ContextFactory.cs`
   - `appsettings.json`
   Asegúrate de configurar correctamente la cadena de conexión a la base de datos SQL Server.

---

## 🚀 Ejecución de la API

### 1️⃣ Establecer el Proyecto de Base de Datos

1. En el explorador de soluciones, **haz clic derecho** sobre el proyecto `ESPERILLA.Gateways.SqlServer`.
2. Selecciona **"Establecer como proyecto de inicio"**.
3. Abre la **Consola del Administrador de Paquetes** en Visual Studio.
4. Ejecuta el siguiente comando para actualizar la base de datos:
   ```powershell
   update-database
### 2️⃣Establecer el Proyecto de API

1. En el explorador de soluciones, **haz clic derecho** sobre el proyecto `ESPERILLA.WebApi`.
2. Selecciona **"Establecer como proyecto de inicio"**.
3. Ejecutar el Proyecto

