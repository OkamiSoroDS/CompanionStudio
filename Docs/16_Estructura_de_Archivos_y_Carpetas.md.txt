# Companion Studio - Estructura de Archivos y Carpetas

## 1. Introducción

Este documento define la estructura física de archivos y carpetas utilizada por Companion Studio.

El objetivo es mantener una organización clara que permita:

- Separar código y datos.
- Facilitar respaldos.
- Permitir migración entre dispositivos.
- Mantener compatibilidad futura.

---

# 2. Estructura Principal del Proyecto

Durante el desarrollo:


CompanionStudio

├── Core

├── AI

├── Apps

├── Tests

├── Tools

├── Docs

└── Data


---

# 3. Carpeta Data

La carpeta Data almacenará la información creada por el usuario.

Estructura:


Data

├── Identities

├── Memories

├── Settings

├── Backups

└── Logs


---

# 4. Carpeta Identities

Contendrá todas las identidades creadas.

Ejemplo:


Data

└── Identities

├── Lilith

├── Assistant01

└── CustomIdentity

Cada identidad tendrá sus propios archivos.

---

# 5. Estructura Interna de una Identidad

Ejemplo:


Lilith

├── identity.json

├── personality.json

├── memory.json

├── settings.json

└── metadata.json


Descripción:

## identity.json

Información principal de identidad.

## personality.json

Configuración de comportamiento.

## memory.json

Recuerdos almacenados.

## settings.json

Configuraciones específicas.

## metadata.json

Información técnica.

---

# 6. Carpeta AI

Contendrá elementos relacionados con inteligencia artificial.

Estructura:


AI

├── Models

├── Runtime

└── Config


---

# 7. Carpeta Models

Almacenará modelos locales.

Ejemplo:


AI

└── Models

├── Modelo_A

├── Modelo_B

└── Modelo_C

Los modelos estarán separados de las identidades.

---

# 8. Carpeta Runtime

Contendrá los motores necesarios para ejecutar modelos.

Ejemplo:


Runtime

├── Engine

├── Drivers

└── Config


---

# 9. Carpeta Settings

Configuraciones generales del programa.

Ejemplo:


Settings

├── appsettings.json

├── user_preferences.json

└── system_config.json


---

# 10. Carpeta Backups

Almacenará copias de seguridad.

Tipos:


Backups

├── Full

├── Identity

└── Configuration


---

# 11. Carpeta Logs

Registro de actividad del sistema.

Ejemplo:


Logs

├── system.log

├── errors.log

└── activity.log


---

# 12. Separación entre Código y Datos

Regla principal:

El código del programa nunca debe mezclarse con los datos del usuario.

Ejemplo correcto:


CompanionStudio

├── Código

└── Data
└── Identidades


Ejemplo incorrecto:


Core

└── Lilith


---

# 13. Instalación del Usuario

Una instalación final podría verse así:


Companion Studio

├── Program

├── Data

├── Models

├── Backups

└── Logs


---

# 14. Portabilidad

El diseño debe permitir:

- Copiar una identidad.
- Mover datos a otra PC.
- Restaurar respaldos.
- Actualizar el programa sin perder información.

---

# 15. Seguridad de Archivos

Los datos importantes pueden incluir:

- Validación de integridad.
- Versiones.
- Copias de seguridad.
- Cifrado opcional.

---

# 16. Objetivo Final

Crear una estructura organizada donde Companion Studio pueda crecer durante años manteniendo separados:

- Código.
- Identidades.
- Memorias.
- Modelos.
- Configuraciones.
- Respaldos.

Con este documento ya definimos dónde vive cada cosa.

La arquitectura ahora queda todavía más clara:

CompanionStudio
│
├── Código
│   ├── Core
│   ├── AI
│   └── Apps
│
├── Datos
│   ├── Identidades
│   ├── Memorias
│   └── Configuración
│
└── Documentación