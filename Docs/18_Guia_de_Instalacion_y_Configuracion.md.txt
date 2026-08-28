# Companion Studio - Guía de Instalación y Preparación del Entorno

## 1. Introducción

Este documento define los requisitos necesarios para preparar un equipo de desarrollo para Companion Studio.

El objetivo es crear un entorno reproducible donde el proyecto pueda ser compilado, probado y ampliado.

---

# 2. Requisitos del Sistema

## Hardware mínimo recomendado


Procesador:
64 bits

Memoria RAM:
8 GB mínimo

Almacenamiento:
20 GB disponibles

Sistema:
Windows 10/11 x64


---

## Hardware recomendado


Procesador:
6 núcleos o superior

Memoria RAM:
16 GB o más

Almacenamiento:
SSD

GPU:
Opcional para modelos IA locales


---

# 3. Sistema Operativo

Sistema soportado inicialmente:


Windows 11 x64


Configuraciones recomendadas:

- Modo UEFI.
- Sistema actualizado.
- Controladores instalados.
- Espacio suficiente en disco.

---

# 4. Herramientas Principales

## Visual Studio

Debe instalarse:


Visual Studio Community


Componentes necesarios:

- Desarrollo de escritorio con .NET.
- Herramientas de C#.
- Git integration.

Componentes futuros:

- Desarrollo multiplataforma .NET MAUI.
- Herramientas Android.

---

# 5. SDK de .NET

Companion Studio utilizará:


.NET


El SDK permite:

- Compilar proyectos.
- Ejecutar aplicaciones.
- Crear librerías.

Verificación:


dotnet --info


---

# 6. Sistema de Control de Versiones

Herramienta:


Git


Verificación:


git --version


Configuración inicial:


git config --global user.name "Nombre"

git config --global user.email "correo"


---

# 7. Editor de Documentación

Los documentos utilizan Markdown.

Programas compatibles:

- Visual Studio Code.
- Visual Studio.
- Editores Markdown.

Extensiones recomendadas:

- Markdown Preview.
- EditorConfig.

---

# 8. Organización del Proyecto

Ubicación recomendada:


D:\CompanionStudio


Estructura:


CompanionStudio

├── Core

├── AI

├── Apps

├── Tests

├── Tools

├── Docs

└── Data


---

# 9. Configuración Inicial de Git

Dentro del proyecto:


git init


Crear archivo:


.gitignore


Debe excluir:


bin/

obj/

.vs/

*.user


---

# 10. Primera Compilación

Después de crear la solución:

Proceso:


Abrir proyecto

↓

Restaurar paquetes

↓

Compilar

↓

Ejecutar pruebas


---

# 11. Preparación para IA Local

Opcionalmente se podrán instalar:

- Motores de inferencia.
- Modelos compatibles.
- Herramientas de administración.

La instalación de modelos dependerá del hardware disponible.

---

# 12. Respaldos

Antes de cambios importantes:

Realizar:

- Commit Git.
- Copia externa.
- Respaldo de datos.

---

# 13. Estado Actual del Entorno

Equipo preparado:


Sistema:
Windows 11 Pro

Arquitectura:
x64

.NET:
Instalado

Git:
Instalado

Visual Studio:
En instalación


---

# 14. Lista de Verificación

Antes de programar:

[ ] Visual Studio instalado.

[ ] Componentes .NET instalados.

[ ] Git funcionando.

[ ] Repositorio creado.

[ ] Carpeta del proyecto preparada.

[ ] Primera compilación exitosa.

---

# 15. Objetivo Final

Tener un entorno de desarrollo estable que permita construir Companion Studio de forma ordenada, reproducible y preparada para futuras expansiones.