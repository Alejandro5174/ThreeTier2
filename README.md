# 🧾 Sistema de Facturación Multicapas (Three Tier)

## 📌 Descripción

Este proyecto corresponde a la **segunda fase** de un sistema de facturación desarrollado bajo arquitectura **Three Tier (multicapas)**.

En esta etapa se amplió el sistema inicial mediante la implementación de funcionalidades **CRUD (Crear, Leer, Actualizar y Eliminar)** para la gestión de clientes y productos, integrándolos completamente con el módulo de facturación.

El sistema permite registrar facturas asociando clientes, empleados y productos, realizando cálculos automáticos como el total y el IVA.

---

## 🏗️ Arquitectura

El sistema está organizado en tres capas principales:

* **Capa de Presentación**

  * Interfaz desarrollada en Windows Forms
  * Interacción con el usuario

* **Capa de Negocio (BLL)**

  * Contiene la lógica del sistema
  * Procesamiento de datos y validaciones

* **Capa de Acceso a Datos (DAL)**

  * Manejo de la conexión a la base de datos
  * Ejecución de consultas SQL

---

## ⚙️ Funcionalidades

### 👤 Clientes

* Crear clientes
* Editar clientes
* Eliminar clientes
* Buscar clientes

### 📦 Productos

* Crear productos
* Editar productos
* Eliminar productos
* Consultar productos

### 🧾 Facturación

* Crear facturas
* Agregar productos a la factura
* Cálculo automático de totales
* Editar facturas
* Eliminar facturas

---

## 🗄️ Base de Datos

El sistema utiliza SQL Server con las siguientes tablas principales:

* TBLCLIENTES
* TBLPRODUCTO
* TBLFACTURA
* TBLDETALLE_FACTURA
* TBLEMPLEADO
* TBLESTADO_FACTURA

---

## 🛠️ Tecnologías Utilizadas

* C# (.NET / Windows Forms)
* SQL Server
* ADO.NET
* Git y GitHub

---

## 👨‍💻 Autor

* Alejandro Montaño
* Docente: Walter Arboleda

