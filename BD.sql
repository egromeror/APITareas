--1.1
create database TAREAS;
use TAREAS;

--1.2
CREATE TABLE ESTADO
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL,
Descripcion VARCHAR(50) NOT NULL);

--1.3
INSERT INTO ESTADO (Nombre,Descripcion) VALUES ('To Do','To Do');
INSERT INTO ESTADO (Nombre,Descripcion) VALUES ('In Progress','In Progress');
INSERT INTO ESTADO (Nombre,Descripcion) VALUES ('Done','Done');

--1.4
CREATE TABLE TAREA
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL,
Descripcion VARCHAR(50) NOT NULL,
Prioridad VARCHAR(50) NOT NULL,
IdEstado INT,
CONSTRAINT TAREA_ESTADO FOREIGN KEY (IdEstado) REFERENCES ESTADO (ID));

--1.5
INSERT INTO TAREA (Nombre,Descripcion,Prioridad,IdEstado) Values ('Tarea 1','Tarea de prueba 1','Baja',1);
--Select * from TAREA
--Select * from ESTADO
--To Do, In Progress, Done

--1.6
CREATE OR ALTER VIEW VW_TAREAS_POR_ESTADO
AS
SELECT E.*,(SELECT COUNT(*) FROM TAREA WHERE IDESTADO=E.Id) TAREAS
FROM [dbo].[ESTADO] E

--select * from VW_TAREAS_POR_ESTADO