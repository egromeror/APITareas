create database TAREAS;
use TAREAS;

CREATE TABLE ESTADO
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL,
Descripcion VARCHAR(50) NOT NULL);

INSERT INTO ESTADO (Nombre,Descripcion) VALUES ('To Do','To Do');
INSERT INTO ESTADO (Nombre,Descripcion) VALUES ('In Progress','In Progress');
INSERT INTO ESTADO (Nombre,Descripcion) VALUES ('Done','Done');

CREATE TABLE TAREA
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL,
Descripcion VARCHAR(50) NOT NULL,
Prioridad VARCHAR(50) NOT NULL,
IdEstado INT,
CONSTRAINT TAREA_ESTADO FOREIGN KEY (IdEstado) REFERENCES ESTADO (ID));

INSERT INTO TAREA (Nombre,Descripcion,Prioridad,IdEstado) Values ('Tarea 1','Tarea de prueba 1','Baja',1);
Select * from TAREA
Select * from ESTADO
--To Do, In Progress, Done

select * from VW_TAREAS_POR_ESTADO
CREATE OR ALTER VIEW VW_TAREAS_POR_ESTADO
AS
SELECT E.*,(SELECT COUNT(*) FROM TAREA WHERE IDESTADO=E.Id) TAREAS
FROM [dbo].[ESTADO] E