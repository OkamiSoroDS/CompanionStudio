# Companion Studio - Modelo de Datos

## 1. Introducción

Este documento define la estructura de datos utilizada por Companion Studio.

El objetivo es establecer cómo se almacenará la información de:

- Identidades.
- Personalidades.
- Memorias.
- Configuraciones.
- Metadatos del sistema.

El modelo debe ser flexible, fácil de migrar y compatible con futuras versiones.

---

# 2. Principios del Modelo de Datos

El sistema seguirá estos principios:

## Separación de componentes

Cada elemento tendrá su propio espacio de almacenamiento.

Ejemplo:


Identity
|
├── Identidad
├── Personalidad
├── Memoria
└── Configuración


---

## Persistencia

Los datos deben sobrevivir a:

- Cierre de la aplicación.
- Actualización del programa.
- Cambio de modelo de IA.
- Migración de dispositivo.

---

## Legibilidad

Los formatos iniciales deben poder ser revisados por humanos.

Formatos principales:

- JSON.
- Markdown.
- Archivos de configuración.

---

# 3. Estructura General de una Identidad

Cada identidad tendrá una carpeta propia.

Ejemplo:


Identities

└── Lilith

├── identity.json
├── personality.json
├── memory.json
├── settings.json
└── metadata.json

---

# 4. Archivo de Identidad

Archivo:


identity.json


Contiene la información principal.

Ejemplo:

```json
{
  "id": "CS-ID-000001",
  "name": "Nombre",
  "version": "1.0",
  "created": "fecha",
  "purpose": "",
  "status": "active"
}

Campos:

ID único.
Nombre.
Versión.
Fecha de creación.
Propósito.
Estado.
5. Archivo de Personalidad

Archivo:

personality.json

Contiene la forma de interacción.

Ejemplo:

{
  "communication_style": "claro",
  "tone": "amigable",
  "formality": 50,
  "creativity": 70,
  "humor": 40
}

Campos:

Estilo de comunicación.
Tono.
Formalidad.
Creatividad.
Humor.
6. Archivo de Memoria

Archivo:

memory.json

Contiene recuerdos organizados.

Ejemplo:

{
  "memories": [
    {
      "id": "MEM-001",
      "type": "preference",
      "importance": "high",
      "content": "",
      "date": ""
    }
  ]
}

Cada memoria tendrá:

Identificador.
Tipo.
Importancia.
Contenido.
Fecha.
7. Archivo de Configuración

Archivo:

settings.json

Contiene opciones del sistema.

Ejemplo:

{
  "language": "es",
  "model": "",
  "local_mode": true,
  "backup_enabled": true
}

Incluye:

Idioma.
Modelo seleccionado.
Modo local.
Respaldos.
8. Archivo de Metadatos

Archivo:

metadata.json

Información técnica.

Ejemplo:

{
  "creator": "",
  "created_with": "Companion Studio",
  "schema_version": "1.0"
}

Contiene:

Creador.
Versión del sistema.
Compatibilidad.
9. Tipos de Memoria

Las memorias estarán clasificadas.

Temporal

Información de una sesión.

Corto plazo

Información útil durante un periodo.

Largo plazo

Información persistente.

Núcleo

Información esencial definida por el usuario.

10. Relaciones entre Datos

Modelo:

Identity
    |
    |
    ├── Personality
    |
    ├── Memory
    |
    ├── Settings
    |
    └── Metadata

La identidad funciona como punto central.

11. Versionado de Datos

Cada estructura tendrá una versión.

Ejemplo:

schema_version:

1.0

Esto permitirá actualizar formatos en el futuro sin perder información.

12. Seguridad del Modelo

Los datos importantes podrán incluir:

Hash de integridad.
Copias de seguridad.
Validación de estructura.
13. Evolución Futura

Posibles mejoras:

Base de datos SQLite.
Búsqueda semántica.
Memoria vectorial.
Compresión de recuerdos.
Cifrado.
14. Objetivo Final

Crear una estructura de datos sólida que permita que las identidades de Companion Studio sean:

Portables.
Editables.
Seguras.
Independientes del modelo de IA.
Preparadas para crecer.

---

Con esto ya tenemos un puente entre la idea y la programación.

Hasta ahora tenemos:


01 Vision
02 Arquitectura
03 Identidad
04 Memoria
05 Personalidad
06 Seguridad
07 Roadmap
08 Especificación Técnica
09 Modelo de Datos


El siguiente documento que tendría mucho sentido crear sería:

**`10_Estructura_del_Core.md`**

Ahí vamos a diseñar exactamente qué clases y módulos crearemos en C# cuando abramos Visual Studio:
- `IdentityManager`
- `MemoryManager`
- `PersonalityManager`
- `SecurityManager`
- cómo se conectarán entre ellos.

Ese documento ya será casi el plano del primer código de Companion Studio.