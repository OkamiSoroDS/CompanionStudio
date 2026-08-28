# Companion Studio - Estructura Inicial del Código

## 1. Introducción

Este documento define la estructura inicial del código fuente de Companion Studio.

El objetivo es establecer una organización clara antes de iniciar la programación, evitando mezclar responsabilidades y facilitando el crecimiento futuro del proyecto.

---

# 2. Solución Principal

La solución de Visual Studio tendrá como nombre:


CompanionStudio


La estructura inicial será:


CompanionStudio

├── CompanionStudio.sln

├── Core

├── AI

├── Apps

├── Tests

└── Tools


---

# 3. Proyecto Core

El proyecto Core será la base principal del sistema.

Ubicación:


Core/


Responsabilidad:

Contener la lógica principal de Companion Studio.

No dependerá de:

- Interfaz gráfica.
- Windows.
- Android.
- Modelos específicos de IA.

---

# 4. Estructura Interna del Core

Primera organización:


Core

├── Identity

│ ├── IdentityModel.cs

│ ├── IdentityManager.cs

│ └── IdentityValidator.cs

├── Memory

│ ├── MemoryItem.cs

│ ├── MemoryManager.cs

│ └── MemoryStorage.cs

├── Personality

│ ├── PersonalityModel.cs

│ └── PersonalityManager.cs

├── Security

│ ├── HashManager.cs

│ └── BackupManager.cs

└── Configuration

├── AppSettings.cs

└── ConfigurationManager.cs

---

# 5. Módulo Identity

## IdentityModel.cs

Representa una identidad dentro del sistema.

Contendrá:

- ID.
- Nombre.
- Versión.
- Fecha de creación.
- Estado.

---

## IdentityManager.cs

Gestionará:

- Crear identidades.
- Guardar.
- Cargar.
- Actualizar.

---

## IdentityValidator.cs

Validará:

- Datos obligatorios.
- Integridad.
- Compatibilidad.

---

# 6. Módulo Memory

## MemoryItem.cs

Representa un recuerdo.

Contendrá:

- Identificador.
- Tipo.
- Importancia.
- Contenido.
- Fecha.

---

## MemoryManager.cs

Gestionará:

- Crear recuerdos.
- Buscar.
- Filtrar.
- Eliminar.

---

## MemoryStorage.cs

Gestionará el almacenamiento físico.

Primera versión:

Archivos JSON.

---

# 7. Módulo Personality

## PersonalityModel.cs

Representará una personalidad.

Datos:

- Estilo.
- Tono.
- Creatividad.
- Formalidad.

---

## PersonalityManager.cs

Gestionará:

- Cargar personalidad.
- Modificar valores.
- Guardar cambios.

---

# 8. Módulo Security

## HashManager.cs

Responsable de:

- Crear firmas.
- Validar integridad.

---

## BackupManager.cs

Responsable de:

- Crear respaldos.
- Restaurar información.

---

# 9. Proyecto AI

Ubicación:


AI/


Responsabilidad:

Gestionar comunicación con modelos.

Estructura inicial:


AI

├── Models

│ └── ModelInfo.cs

└── Runtime

├── AIEngine.cs

└── ContextBuilder.cs

---

# 10. Proyecto Apps

Contendrá las interfaces de usuario.

Primera versión:


Apps

└── Windows

└── CompanionStudio.Windows

---

# 11. Proyecto Tests

Contendrá pruebas automáticas.

Ejemplo:


Tests

└── CompanionStudio.Tests


Pruebas iniciales:

- Identity.
- Memory.
- Personality.

---

# 12. Primera Meta de Programación

La primera versión del código debe conseguir:

1. Crear una identidad.

2. Guardarla en disco.

3. Leerla nuevamente.

4. Mostrar sus datos.

---

# 13. Primera Clase a Programar

El primer módulo será:


IdentityModel.cs


Motivo:

La identidad es el núcleo de todo el sistema.

Después se desarrollarán:

1. IdentityManager.
2. MemoryManager.
3. PersonalityManager.
4. SecurityManager.

---

# 14. Reglas de Código

El código debe seguir:

- Nombres claros.
- Una responsabilidad por clase.
- Módulos independientes.
- Documentación cuando sea necesaria.
- Pruebas antes de grandes cambios.

---

# 15. Estado Actual

Versión:


0.1.0 Diseño


Preparado:

- Documentación completa.
- Arquitectura definida.
- Estructura de código diseñada.

Siguiente paso:

Crear la solución de Visual Studio y comenzar el desarrollo del Core.