# Companion Studio - Arquitectura del Sistema

## 1. Introducción

La arquitectura de Companion Studio está diseñada para crear una plataforma modular capaz de administrar identidades, memorias y personalidades para modelos de inteligencia artificial locales.

El sistema estará dividido en capas independientes para facilitar el mantenimiento, la expansión y la compatibilidad con diferentes motores de IA.

---

# 2. Arquitectura General

Companion Studio estará compuesto por las siguientes capas:

Usuario
|
|
Interfaces (Apps)
|
|
Core del Sistema
|
├── Identity
├── Memory
├── Personality
└── Security
|
|
AI Runtime
|
|
Modelos de IA


---

# 3. Capa Core

El Core es el núcleo principal del sistema.

Su función es administrar la información que define una identidad de IA y controlar la comunicación entre módulos.

Está dividido en:

---

## 3.1 Identity

Responsable de la identidad base.

Funciones:

- Nombre de la identidad.
- Características principales.
- Información base.
- Valores definidos.
- Configuración permanente.

La identidad debe mantenerse separada del modelo de IA para permitir cambiar de modelo sin perder la personalidad creada.

---

## 3.2 Memory

Sistema encargado de administrar recuerdos.

Funciones:

- Almacenamiento de información importante.
- Organización de recuerdos.
- Recuperación de contexto.
- Gestión de memoria a corto y largo plazo.

Tipos de memoria:

- Memoria temporal.
- Memoria persistente.
- Información relevante del usuario.

---

## 3.3 Personality

Controla la forma de interacción.

Incluye:

- Estilo de comunicación.
- Tono.
- Forma de responder.
- Preferencias de comportamiento.
- Parámetros de personalidad.

La personalidad debe poder modificarse sin alterar la identidad principal.

---

## 3.4 Security

Capa encargada de proteger el sistema.

Funciones:

- Control de acceso.
- Protección de archivos.
- Integridad de identidad.
- Copias de seguridad.
- Validación de datos.

---

# 4. Capa AI

La capa AI permite conectar Companion Studio con diferentes modelos.

No depende de un único modelo.

Puede trabajar con:

- Modelos locales.
- Motores externos compatibles.
- Diferentes arquitecturas de IA.

Ejemplos de motores:

- llama.cpp.
- Ollama.
- Otros runtimes compatibles.

---

# 5. Gestión de Modelos

Los modelos estarán separados de la identidad.

Ejemplo:
AI
|
└── Models
|
├── Modelo_A
├── Modelo_B
└── Modelo_C


Una misma identidad podrá utilizar diferentes modelos sin perder sus características.

---

# 6. Capa de Aplicaciones

Las aplicaciones serán las interfaces mediante las cuales el usuario interactúa con Companion Studio.

## Windows

Primera plataforma objetivo.

Funciones iniciales:

- Crear identidades.
- Administrar configuraciones.
- Gestionar modelos.
- Conversar con asistentes.

## Android

Segunda plataforma.

Funciones:

- Acceso móvil.
- Sincronización.
- Uso portátil.

---

# 7. Principios de Diseño

## Modularidad

Cada sistema debe poder actualizarse sin afectar los demás.

## Separación de datos

La identidad, memoria y modelo deben permanecer independientes.

## Escalabilidad

La arquitectura debe permitir agregar nuevas funciones en el futuro.

## Funcionamiento local

La plataforma debe priorizar la ejecución local cuando sea posible.

---

# 8. Flujo General de Funcionamiento

1. El usuario selecciona una identidad.
2. El sistema carga su configuración.
3. Se recupera la memoria relevante.
4. Se conecta con el modelo de IA seleccionado.
5. La respuesta es procesada con las reglas de personalidad.
6. La nueva información importante puede almacenarse en memoria.

---

# 9. Estado Actual del Proyecto

Fase actual:

Diseño y documentación.

Próximas fases:

- Creación del núcleo básico.
- Sistema de identidad.
- Sistema de memoria.
- Primera interfaz Windows.
- Integración con modelos locales.