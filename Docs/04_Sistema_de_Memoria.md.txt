# Companion Studio - Sistema de Memoria

## 1. Introducción

El Sistema de Memoria es el componente encargado de almacenar, organizar y recuperar información relevante para mantener continuidad en las interacciones.

La memoria permite que una identidad conserve información importante a través del tiempo, independientemente del modelo de inteligencia artificial utilizado.

La memoria debe ser organizada, controlable y transparente para el usuario.

---

# 2. Objetivo del Sistema de Memoria

El objetivo principal es crear un sistema capaz de:

- Recordar información importante.
- Mantener continuidad entre conversaciones.
- Recuperar contexto relevante.
- Evitar almacenar información innecesaria.
- Permitir al usuario administrar sus recuerdos.

---

# 3. Tipos de Memoria

Companion Studio tendrá diferentes niveles de memoria.

---

## 3.1 Memoria de Sesión

Es la memoria temporal durante una conversación activa.

Características:

- Existe mientras la sesión está abierta.
- Contiene el contexto inmediato.
- Puede eliminarse al cerrar la sesión.

Ejemplos:

- Tema actual de conversación.
- Preguntas recientes.
- Información temporal.

---

## 3.2 Memoria a Corto Plazo

Almacena información reciente que puede ser útil durante un periodo limitado.

Ejemplos:

- Proyectos actuales.
- Tareas pendientes.
- Preferencias recientes.

Puede tener un sistema de expiración.

---

## 3.3 Memoria a Largo Plazo

Contiene información que debe permanecer disponible durante mucho tiempo.

Ejemplos:

- Configuración de identidad.
- Preferencias importantes.
- Información definida por el usuario.
- Conocimientos adquiridos.

---

# 4. Organización de la Memoria

La memoria estará separada por categorías.

Ejemplo:
Memory

├── Core_Memories
│
├── User_Profile
│
├── Experiences
│
├── Preferences
│
└── Knowledge


---

# 5. Memorias Principales

## Core Memories

Información fundamental que define la relación entre usuario e identidad.

Ejemplos:

- Configuraciones importantes.
- Datos esenciales definidos por el usuario.

---

## Preferences

Preferencias del usuario.

Ejemplos:

- Idioma.
- Forma de comunicación.
- Configuraciones elegidas.

---

## Experiences

Registro de experiencias importantes.

Ejemplos:

- Proyectos realizados.
- Eventos relevantes.
- Aprendizajes.

---

## Knowledge

Información aprendida o agregada.

Ejemplos:

- Documentación.
- Notas.
- Datos proporcionados por el usuario.

---

# 6. Sistema de Importancia

No toda información debe guardarse.

Cada recuerdo tendrá una prioridad.

Ejemplo:
Memory Object

ID:
Fecha:
Tipo:
Importancia:
Contenido:
Origen:



Niveles:
Alta:
Información permanente.

Media:
Información útil temporalmente.

Baja:
Información que puede descartarse.


---

# 7. Control del Usuario

El usuario debe poder:

- Ver recuerdos almacenados.
- Editarlos.
- Eliminarlos.
- Exportarlos.
- Crear copias de seguridad.

La memoria pertenece al usuario.

---

# 8. Recuperación de Memoria

Cuando una conversación inicia:

1. Se identifica la identidad activa.
2. Se analiza el contexto actual.
3. Se buscan recuerdos relacionados.
4. Se envía únicamente la información necesaria al modelo.

Esto evita enviar toda la memoria en cada interacción.

---

# 9. Privacidad

La memoria debe diseñarse con prioridad en:

- Almacenamiento local.
- Cifrado opcional.
- Control del usuario.
- Transparencia.

---

# 10. Evolución de la Memoria

La memoria podrá mejorar con el tiempo mediante:

- Mejor clasificación.
- Búsqueda semántica.
- Bases de datos vectoriales.
- Sistemas de resumen.

---

# 11. Objetivo Final

Crear un sistema de memoria persistente que permita a las identidades de Companion Studio mantener continuidad, organización y coherencia, sin depender exclusivamente del historial de conversaciones.