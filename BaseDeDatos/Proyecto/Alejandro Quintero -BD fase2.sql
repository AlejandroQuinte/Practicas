Create database UFuenteConocimiento
go

use UFuenteConocimiento
go

--CREACION DE TABLAS--

--Profesores tienen conexion con horarioProfesores y Certificaciones
create table Profesores(
	ID_PROFESOR varchar(20) primary key not null,
	NOMBRE_PROFESOR VARCHAR(20) NOT NULL,
	PRIMER_APELLIDO_P VARCHAR(20) NOT NULL,
	SEGUNDO_APELLIDO_P VARCHAR(20),
	TELEFONO_PROFESOR int NOT NULL,
	CORREO_PROFESOR VARCHAR(50),
);
--HorarioProfesores tiene conexion con Profesores
create table HorarioProfesores(
	ID_HORARIOPROFESOR varchar(20) primary key not null,
	ID_PROFESOR varchar(20) not null,
	HORA_INICIO time not null,
	HORA_FINAL time not null
);
--Certificaciones tiene conexion con profesores y laboratorios
create table Certificaciones(
	ID_CERTIFICADO varchar(20) primary key not null,
	ID_PROFESOR varchar(20) not null,
	MATERIA varchar(50) not null,
);
--Laboratorios tiene conexion con horarioLaboratorio y cursos
create table Laboratorios(
	ID_LABORATORIO varchar(20) primary key not null,
	ID_Curso varchar(20) not null,
	NOMBRELABORATORIO varchar(50) not null
);
--Cursos tiene conexion con Laboratorios,CursosAbiertos y Programas
create table Cursos(
	ID_CURSO varchar(20) primary key not null,
	ID_CURSOABIERTO varchar(20) not null,
	ID_PROGRAMAS varchar(20) not null,
	NOMBRECURSO varchar(60) not null,
	DURACION INT not null,
	PRECIO float not null
);
--Programas tiene conexion con Cursos
create table Programas(
	ID_PROGRAMAS varchar(20) primary key not null,
	NOMBREPROGRAMA varchar(80) not null
);
--CursosAbietos tiene conexion con cursos y DetalleMatricula y horario
create table CursosAbiertos(
	ID_CURSOABIERTO varchar(20) primary key not null,
	ID_CERTIFICADO varchar(20) not null,
	ID_HORARIOPROFESOR varchar(20) not null,
	FECHA_INICIO date not null,
	FECHA_FINAL date not null
);
--Horario tiene conexion con CursosAbiertos
create table Horario(
	ID_HORARIO varchar(20) primary key not null,
	ID_CURSOABIERTO varchar(20) not null,
	HORA_INICIO time not null,
	HORA_FINAL time not null,
	DIA varchar(20) not null
);
--detalleMatricula tiene conexion con CursosAbiertos y Matricula
create table DetalleMatricula(
	ID_MATRICULA varchar(20) not null,
	ID_CURSOABIERTO varchar(20) not null
);
--Matricula tiene coneccion con detalleMatricula y estudiantes
create table Matricula(
	ID_MATRICULA varchar(20) primary key not null,
	ID_ESTUDIANTES varchar(20) not null,
	FECHAMATRICULA date not null,
	TOTALMATRICULA int,
	ESTADOPAGO varchar(30)
);
--Estudiantes tiene conexion con matricula notasMateria
create table Estudiantes(
	ID_ESTUDIANTES varchar(20) primary key not null,
	NOMBRE_ESTUDIANTE VARCHAR(20) NOT NULL,
	PRIMER_APELLIDO_E VARCHAR(20) NOT NULL,
	SEGUNDO_APELLIDO_E VARCHAR(20),
	CORREO_ESTUDIANTE VARCHAR(25),
	TELEFONO_ESTUDIANTE VARCHAR(8) NOT NULL,
);
--notasMateria tiene conexion con Estudiantes
create table NotasMateria(
	ID_NOTA varchar(20) primary key not null,
	ID_CURSO varchar(20) not null,
	ID_ESTUDIANTES varchar(20) not null,
	PERIODO int not null,
	NOTA float
);

----------Referencias de tablas-----------------
--Referencias Laboratorios
ALTER TABLE Laboratorios 
ADD CONSTRAINT FK_CURSO FOREIGN KEY (ID_CURSO) REFERENCES CURSOS(ID_CURSO)

--Referencias de Cursos
ALTER TABLE Cursos 
ADD CONSTRAINT FK_CURSOABIERTO FOREIGN KEY (ID_CURSOABIERTO) REFERENCES CursosAbiertos(ID_CURSOABIERTO)
ALTER TABLE Cursos 
ADD CONSTRAINT FK_PROGRAMAS FOREIGN KEY (ID_PROGRAMAS) REFERENCES Programas(ID_PROGRAMAS)

--Referencias CursosAbiertos
ALTER TABLE CursosAbiertos
ADD CONSTRAINT FK_HorarioProfesor FOREIGN KEY (ID_HORARIOPROFESOR) REFERENCES HorarioProfesores(ID_HORARIOPROFESOR)
ALTER TABLE CursosAbiertos
ADD CONSTRAINT FK_Certificado FOREIGN KEY (ID_Certificado) REFERENCES certificaciones(ID_Certificado)

--referencias NotasMateria
ALTER TABLE NotasMateria
ADD CONSTRAINT FK_IDCurso FOREIGN KEY (ID_CURSO) REFERENCES cursos(ID_CURSO)
ALTER TABLE NotasMateria
ADD CONSTRAINT FK_IDEstudiantes FOREIGN KEY (ID_ESTUDIANTES) REFERENCES estudiantes(ID_ESTUDIANTES)

--referencias horario
ALTER TABLE horario
ADD CONSTRAINT FK_IDCursoA FOREIGN KEY (ID_CURSOABIERTO) REFERENCES cursosAbiertos(ID_CURSOABIERTO)

--referencias horariosProfesores
ALTER TABLE horarioprofesores
ADD CONSTRAINT FK_IDProfesor FOREIGN KEY (ID_PROFESOR) REFERENCES profesores(ID_PROFESOR)

--referencias certificaciones
ALTER TABLE certificaciones
ADD CONSTRAINT FK_IDProfesorC FOREIGN KEY (ID_PROFESOR) REFERENCES profesores(ID_PROFESOR)


--Referencias DetalleMatricula
ALTER TABLE DetalleMatricula
ADD CONSTRAINT FK_CursoAbierto_M FOREIGN KEY (ID_CURSOABIERTO) REFERENCES CursosAbiertos(ID_CURSOABIERTO)
ALTER TABLE DetalleMatricula
ADD CONSTRAINT FK_Matricula FOREIGN KEY (ID_Matricula) REFERENCES Matricula(ID_Matricula)

--Referencias Matricula
ALTER TABLE Matricula
ADD CONSTRAINT FK_Estudiantes FOREIGN KEY (ID_ESTUDIANTES) REFERENCES Estudiantes(ID_ESTUDIANTES)



--Insertar a Profesores---1
INSERT INTO Profesores(ID_PROFESOR,NOMBRE_PROFESOR,PRIMER_APELLIDO_P,SEGUNDO_APELLIDO_P,TELEFONO_PROFESOR,CORREO_PROFESOR)
VALUES  (1,'Luis Ángel','Chacon','Zuniga','88881111','luis@ina.ac.cr'),
		(2,'Alonso','Bogantes','Rodriguez','88881112','alonso@ina.ac.cr'),
		(3,'Oscar','Pacheco','Vazquez','88881113','pacheco@ina.ac.cr'),
		(4,'Laura','Fonseca','Rojas','88881114','laura@ina.ac.cr'),
		(5,'Irene','Cruz','Fernandez','88881115','irene@ina.ac.cr'),
		(6,'Jimmy','Zuniga','Sanchez','88881116','jimmy@ina.ac.cr'),
		(7,'Nelson','Jimenez','Jimenez','88881117','Nelson@ina.ac.cr'),
		(8,'Rebeca','Aguilar','Navarez','88881118','Rebeca@ina.ac.cr'),
		(9,'Sady','Carrillo','Sanchez','88881119','Sady@ina.ac.cr'),
		(10,'Muricio','Cordero','Lizano','88881120','Mauricio@ina.ac.cr');

--SELECT * FROM Profesores

--Insertar a programas---2
INSERT INTO Programas(ID_PROGRAMAS,NOMBREPROGRAMA)
VALUES (1,'Programación de Dispositivos Moviles'),
	   (2,'Programación de Sistemas de Escritorio'),
	   (3,'Programación de Paginas Web');

--SELECT * FROM Programas


--Insertar a Estudiantes--------3
INSERT INTO Estudiantes(ID_ESTUDIANTES,NOMBRE_ESTUDIANTE,PRIMER_APELLIDO_E,SEGUNDO_APELLIDO_E,TELEFONO_ESTUDIANTE,CORREO_ESTUDIANTE)
VALUES (1,'JOEL','ROJAS','JIMENEZ','88880101','208170615@ina.cr'),
	   (2,'MIGUEL','SUAREZ','GARCIA','88880102','702420185@ina.cr'),
	   (3,'CARLOS','RODRIGUEZ','AGUILAR','88880103','207990019@ina.cr'),			
	   (4,'CARMEN','SOSA','GONZALES','88880104','205790810@ina.cr'),
	   (5,'MARIA','PEREZ','JIMENEZ','88880105','206470303@ina.cr'),
	   (6,'MARIANO','ARCE','ROJAS','88880106','116870306@ina.cr'),
	   (7,'DIANA','PREREIRA','SALAZAR','88880107','901390706@ina.cr'),
	   (8,'FERNANDO','ZELEDON','PACHECO','88880108','208110717@ina.cr'),
	   (9,'LUCIA','SANCHEZ','JIMENEZ','88880109','701890285@ina.cr'),
	   (10,'PACO','SANCHEZ','JIMENEZ','88880109','701890285@ina.cr');

--SELECT * FROM Estudiantes

--Restriccion matricula
ALTER TABLE MATRICULA ADD CONSTRAINT CHK_ESTADOP 
CHECK(ESTADOPAGO IN('COMPLETO','INCOMPLETO'))

--Insertar a matricula-----4
INSERT INTO Matricula(ID_MATRICULA,ID_ESTUDIANTES,FECHAMATRICULA,TOTALMATRICULA,ESTADOPAGO)
VALUES (1,1,GETDATE(),10000,'COMPLETO'),
	   (2,2,GETDATE(),10000,'COMPLETO'),
	   (3,3,GETDATE(),10000,'COMPLETO'),
	   (4,4,GETDATE(),10000,'COMPLETO'),
	   (5,5,GETDATE(),10000,'COMPLETO'),
	   (6,6,GETDATE(),10000,'COMPLETO'),
	   (7,7,GETDATE(),10000,'COMPLETO'),
	   (8,8,GETDATE(),10000,'COMPLETO'),
	   (9,9,GETDATE(),10000,'COMPLETO'),
	   (10,10,GETDATE(),10000,'COMPLETO');

--SELECT * FROM Matricula


--Restriccion HorarioProfesores
ALTER TABLE HorarioProfesores ADD CONSTRAINT CHK_HORA_FINALP 
CHECK(HORA_FINAL<='17:00:00' and HORA_FINAL>='08:00:00')

--Insertar a HorarioProfesores---------5
INSERT INTO HorarioProfesores(ID_HORARIOPROFESOR,ID_PROFESOR,HORA_INICIO,HORA_FINAL)
VALUES (1,1,'07:10:00','12:00:00'),
	   (2,2,'07:10:00','12:00:00'),
	   (3,3,'08:00:00','13:00:00'),
	   (4,4,'09:00:00','14:00:00'),
	   (5,5,'07:00:00','10:00:00'),
	   (6,6,'10:00:00','12:00:00'),
	   (7,7,'12:00:00','17:00:00'),
	   (8,8,'07:30:00','12:30:00'),
	   (9,9,'01:00:00','16:00:00'),
	   (10,10,'07:10:00','10:00:00');

--SELECT * FROM HorarioProfesores

--Insertar a certificaciones----------6
INSERT INTO Certificaciones(ID_CERTIFICADO,ID_PROFESOR,MATERIA)
VALUES (1,1,'Programación para Android'),
	   (2,2,'Programación para Aplicaciones Mixtas'),
	   (3,3,'Lógica Computacional'),
	   (4,4,'Introducción a Java'),
	   (5,5,'Programación Orientada a Objetos'),
	   (6,6,'HTML'),
	   (7,7,'CSS'),
	   (8,8,'JavaScript'),
	   (9,9,'Bootstrap'),
	   (10,10,'Node js');

--SELECT * FROM Certificaciones


--Restriccion CursosAbiertos
ALTER TABLE CursosAbiertos ADD CONSTRAINT CHK_FECHAINICIO 
CHECK(FECHA_INICIO>=GETDATE())
alter table CursosAbiertos drop CHK_FECHAINICIO 

--Insertar a CursosAbiertos------------7
INSERT INTO CursosAbiertos(ID_CURSOABIERTO,ID_CERTIFICADO,ID_HORARIOPROFESOR,FECHA_INICIO,FECHA_FINAL)
VALUES (11,11,11,'20210812','20220414'),
	   (2,2,2,'20210818','20220418'),
	   (3,3,3,'20210813','20220411'),
	   (4,4,4,'20210814','20220416'),
	   (5,5,5,'20210816','20220417'),
	   (6,6,6,'20210818','20220418'),
	   (7,7,7,'20210814','20220410'),
	   (8,8,8,'20210816','20220413'),
	   (9,9,9,'20210817','20220412'),
	   (10,10,10,'20210810','20220411');

--SELECT * FROM CursosAbiertos


--Restriccion Cursos
ALTER TABLE Cursos ADD CONSTRAINT CHK_DURACION
CHECK(DURACION>0 and DURACION<1400)
ALTER TABLE Cursos ADD CONSTRAINT CHK_PRECIO
CHECK(PRECIO>=0 and DURACION<6000000)

--Insertar a Cursos--------------8
INSERT INTO Cursos(ID_CURSO,ID_CURSOABIERTO,ID_PROGRAMAS,NOMBRECURSO,DURACION,PRECIO)
VALUES (1,1,1,'Programación para Android',330,710000),
	   (2,2,1,'Programación para Aplicaciones Mixtas',100,195000),
	   (3,3,2,'Lógica Computacional',140,225000),
	   (4,4,2,'Introducción a Java',150,335000),
	   (5,5,2,'Programación Orientada a Objetos',160,345000),
	   (6,6,3,'HTML',90,185000),
	   (7,7,3,'CSS',60,175000),
	   (8,8,3,'JavaScript',70,180000),
	   (9,9,3,'Bootstrap',90,185000),
	   (10,10,3,'Node js',90,185000);

--SELECT * FROM Cursos


--Insertar a DetalleMatricula------------9
INSERT INTO DetalleMatricula(ID_MATRICULA,ID_CURSOABIERTO)
VALUES (1,1),
	   (2,2),
	   (3,3),
	   (4,4),
	   (5,5),
	   (6,6),
	   (7,7),
	   (8,8),
	   (9,9),
	   (10,10);

--SELECT * FROM DetalleMatricula


--Restriccion Horario
ALTER TABLE Horario ADD CONSTRAINT CHK_HORA_FINAL 
CHECK(HORA_FINAL<='17:00:00' and HORA_FINAL>='9:00:00')
ALTER TABLE HORARIO ADD CONSTRAINT CHK_DIA
CHECK(DIA IN('L','K','M','J','V','S') and DIA = upper(DIA))

--Insertar a Horario-----------10
INSERT INTO Horario(ID_HORARIO,ID_CURSOABIERTO,HORA_INICIO,HORA_FINAL,DIA)
VALUES (1,1,'07:00:00','12:00:00','L'),
	   (2,2,'07:00:00','12:00:00','K'),
	   (3,3,'08:00:00','13:00:00','M'),
	   (4,4,'09:00:00','14:00:00','J'),
	   (5,5,'07:00:00','10:00:00','V'),
	   (6,6,'10:00:00','12:00:00','S'),
	   (7,7,'12:00:00','17:00:00','L'),
	   (8,8,'07:30:00','12:30:00','K'),
	   (9,9,'01:00:00','16:00:00','M'),
	   (10,10,'07:00:00','10:00:00','J');


SELECT * FROM Horario

--Insertar a Laboratorios-----------11
INSERT INTO Laboratorios(ID_LABORATORIO,ID_Curso,NOMBRELABORATORIO)
VALUES (1,1,'LAB1'),
	   (2,2,'LAB2'),
	   (3,3,'LAB3'),
	   (4,4,'LAB4'),
	   (5,5,'LAB5'),
	   (6,6,'LAB6'),
	   (7,7,'LAB7'),
	   (8,8,'LAB8'),
	   (9,9,'LAB9'),
	   (10,10,'LAB10');

--SELECT * FROM Laboratorios

--Insertar a NOTASmATERia---------------12
INSERT INTO NotasMateria(ID_NOTA,ID_CURSO,ID_ESTUDIANTES,PERIODO,NOTA)
VALUES (1,1,1,0,0),
	   (2,2,2,0,0),
	   (3,3,3,0,0),
	   (4,4,4,0,0),
	   (5,5,5,0,0),
	   (6,6,6,0,0),
	   (7,7,7,0,0),
	   (8,8,8,0,0),
	   (9,9,9,0,0),
	   (10,10,10,0,0);

--SELECT * FROM NotasMateria