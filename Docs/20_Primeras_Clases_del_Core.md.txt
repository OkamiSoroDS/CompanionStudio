# Companion Studio - Primeras Clases del Core

## 1. Introducción

Este documento define las primeras clases que serán creadas dentro del Core de Companion Studio.

El objetivo es construir una base simple, limpia y escalable.

La primera prioridad será crear el sistema de identidad, ya que representa el núcleo del proyecto.

---

# 2. Principio de Diseño

Cada clase debe tener una responsabilidad específica.

Regla:


Una clase = Una responsabilidad principal


Evitar:

- Clases demasiado grandes.
- Mezclar interfaz con lógica.
- Dependencias innecesarias.

---

# 3. Estructura Inicial del Core

Primera versión:


Core

├── Identity

│ ├── IdentityModel.cs

│ ├── IdentityManager.cs

│ └── IdentityValidator.cs

├── Storage

│ └── JsonStorage.cs

└── Configuration

└── AppSettings.cs

---

# 4. Clase IdentityModel

Archivo:


IdentityModel.cs


Responsabilidad:

Representar una identidad dentro del sistema.

No guarda archivos.
No controla interfaces.

Solo representa datos.

---

## Datos principales

Debe contener:


Id

Name

Version

CreatedDate

Status


Ejemplo conceptual:


Identity

ID:
CS-000001

Nombre:
Nueva Identidad

Versión:
1.0

Estado:
Activo


---

# 5. Clase IdentityManager

Archivo:


IdentityManager.cs


Responsabilidad:

Administrar identidades.

Funciones principales:


CreateIdentity()

SaveIdentity()

LoadIdentity()

UpdateIdentity()


---

## CreateIdentity()

Debe:

- Crear una nueva identidad.
- Generar identificador.
- Asignar fecha.
- Crear estado inicial.

Resultado:


Nueva identidad creada


---

## SaveIdentity()

Debe:

- Recibir una identidad.
- Convertir datos a JSON.
- Guardar archivo.

Ejemplo:


IdentityModel

↓

JSON

↓

Archivo


---

## LoadIdentity()

Debe:

- Leer archivo.
- Convertir JSON.
- Crear objeto IdentityModel.

Ejemplo:


Archivo

↓

JSON

↓

IdentityModel


---

# 6. Clase IdentityValidator

Archivo:


IdentityValidator.cs


Responsabilidad:

Comprobar que una identidad sea válida.

Validaciones:

- Tiene ID.
- Tiene nombre.
- Tiene versión.
- Tiene fecha.

---

# 7. Clase JsonStorage

Archivo:


JsonStorage.cs


Responsabilidad:

Manejar almacenamiento básico.

Funciones:


Save()

Load()

Exists()


---

## Save()

Entrada:


Objeto


Salida:


Archivo JSON


---

## Load()

Entrada:


Archivo JSON


Salida:


Objeto


---

# 8. Clase AppSettings

Archivo:


AppSettings.cs


Responsabilidad:

Guardar configuraciones generales.

Datos iniciales:


Language

DataPath

ActiveIdentity

Version


---

# 9. Relación entre Clases

Flujo inicial:


Usuario

↓

IdentityManager

↓

IdentityValidator

↓

JsonStorage

↓

Archivo JSON


---

# 10. Primera Prueba del Core

La primera prueba será:

Crear una identidad.

Proceso:


Iniciar programa

↓

Crear identidad

↓

Guardar archivo

↓

Cerrar programa

↓

Abrir archivo

↓

Leer identidad


Resultado esperado:

La información debe mantenerse.

---

# 11. Primera Estructura de Datos

Ejemplo de archivo generado:


Data

└── Identities

└── NuevaIdentidad

    └── identity.json

Contenido:

```json
{
  "Id": "CS-000001",
  "Name": "Nueva Identidad",
  "Version": "1.0",
  "Status": "Active"
}
12. Primera Meta de Programación

Al finalizar la primera etapa debemos tener:

✅ Proyecto Core creado.

✅ IdentityModel funcionando.

✅ IdentityManager funcionando.

✅ Guardado JSON funcionando.

✅ Lectura JSON funcionando.

13. Código Futuro

Después de completar estas clases se agregarán:

MemoryManager

PersonalityManager

SecurityManager

AI Runtime
14. Estado Actual

Versión:

0.1.0 Diseño

Preparado:

Arquitectura.
Carpetas.
Clases iniciales.
Flujo de datos.

Siguiente paso:

Crear la solución de Visual Studio y comenzar la implementación del Core.


---

Con este documento ya tenemos prácticamente el **primer sprint de programación definido**.

Cuando Visual Studio termine, nuestro primer objetivo será pequeño pero importante:

**Crear una identidad, guardarla en un archivo y volver a cargarla.**

Ese será el primer "latido" de Companion Studio funcionando.