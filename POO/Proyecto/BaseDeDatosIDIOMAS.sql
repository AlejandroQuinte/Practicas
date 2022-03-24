Create database InstitutoIdiomasCR
go
use InstitutoIdiomasCR
go

--creacion de la tabla IDIOMAS
create table Idiomas(
	ID_Idioma varchar(20) primary key not null,
	NombreIdioma varchar(80) not null
);

--Creacion de la tabla CURSOS
create table Cursos(
	ID_Curso varchar(20) primary key not null,
	ID_Nota int not null, --Llave foranea
	ID_Idioma varchar(20) not null, --Llava foranea
	NombreCurso varchar(60) not null,
	CantidadCursos int not null,
	HorasCurso int not null,
	HorasSincronicas int,
	HorasAsincronicas int,
	Precio float not null
);

--Creacion de la tabla MATRICULA
create table Matricula(
	ID_Matricula int identity(1,1) not null primary key,
	ID_Estudiantes int not null, --Llave foranea
	ID_Curso varchar(20) not null, --Llave foranea
	Intensidad int not null,
	FechaMatricula date not null,
	TotalPago float not null,
	EstadoPago varchar(20) not null 
);

--Restriccion en la tabla MATRICULA en la columna EstadoPago
ALTER TABLE Matricula ADD CONSTRAINT CHK_ESTADOPAGOS 
CHECK(EstadoPago IN('COMPLETO','INCOMPLETO'));
--Restriccion en la tabla MATRICULA en la columna EstadoPago
ALTER TABLE Matricula ADD CONSTRAINT CHK_CINTENSIDAD
CHECK(Intensidad in(1,2,3,4));


--Creacion de la tabla ESTUDIANTES
create table Estudiantes(
	ID_Estudiantes int identity(1,1) not null primary key,
	Nombre varchar(20) not null,
	Apellido1 varchar(20) not null,
	Apellido2 varchar(20),
	Correo varchar(50) not null,
	Telefono int not null
);

--Creacion de tabla NOTASMATERIA
create table NotasMateria(
	ID_Nota int identity(1,1) not null primary key,
	Nota float not null,
	Estado varchar(20) not null
);
--Restriccion de la tabla NOTASMATERIA en la columna ESTADO
alter table NotasMateria add constraint CHK_ESTADONOTAS
check(Estado in('APROBADO','REPROBADO'));


--Creacion de la tabla CLASESINCRONICA
create table ClaseSincronica(
	ID_ClaseSincronica int identity(1,1) not null primary key,
	ID_Estudiante int not null,--Llave foranea
	ID_Profesor int not null,--Llave foranea
	ID_Curso varchar(20) not null,--llave foranea
	FechaClase datetime not null,
	HoraInicio datetime not null,
	HoraFinal datetime not null
);

--Creacion de la tabla CERTIFICACIONES
create table Certificaciones(
	ID_Certificado varchar(20) not null primary key,
	ID_Profesor int not null,--Llave foranea
	Materia varchar(20) not null
);

--Creacion de la tabla PROFESORES
create table Profesores(
	ID_Profesor int identity(1,1) not null primary key,
	Nombre varchar(20) not null,
	Apellido1 varchar(20) not null,
	Apellido2 varchar(20),
	Correo varchar(50) not null,
	Telefono int not null
);

--Creacion de la tabla HORARIOPROFESORES
create table HorarioProfesor(
	ID_HorarioProfesor int identity not null primary key,
	ID_Profesor int not null,
	HoraInicio time,
	HoraFinal time,
	FechaInicio datetime not null,
	FechaFinal datetime not null,
	Estado varchar(30) not null
);

--Creacion de la tabla FECHAFERIADOS
create table FechaFeriados(
	ID_Fecha varchar(20) not null primary key,
	Fecha date not null,
	Motivo varchar(20) not null
);


--Creacion de referencia de la tabla CURSOS
ALTER TABLE Cursos
ADD CONSTRAINT FK_NOTA FOREIGN KEY (ID_Nota) REFERENCES NotasMateria(ID_Nota)
--
ALTER TABLE Cursos
ADD CONSTRAINT FK_IDIOMA FOREIGN KEY (ID_Idioma) REFERENCES Idiomas(ID_Idioma)

--Creacion de referencia de la tabla MATRICULA
ALTER TABLE Matricula
ADD CONSTRAINT FK_ESTUDIANTE FOREIGN KEY (ID_Estudiantes) REFERENCES Estudiantes(ID_Estudiantes)
--
ALTER TABLE Matricula
ADD CONSTRAINT FK_CURSO FOREIGN KEY (ID_Curso) REFERENCES Cursos(ID_Curso)

--Creacion de referencia de la tabla CLASESINCRONICA
alter table ClaseSincronica
add constraint FK_ESTUDIANTECLASE foreign key (ID_Estudiante) references Estudiantes(ID_Estudiantes)
--
alter table ClaseSincronica
add constraint FK_PROFESORCLASE foreign key (ID_Profesor) references Profesores(ID_Profesor)
--
alter table ClaseSincronica
add constraint FK_CURSOCLASE foreign key (ID_Curso) references Cursos(ID_Curso)

--Creacion de referencia de la tabla CERTIFICACIONES
alter table Certificaciones 
add constraint FK_PROFESORCERTIFICACION foreign key (ID_Profesor) references Profesores(ID_Profesor)


--Creacion de referencia de la tabla HORARIOPROFESORES
alter table HorarioProfesor
add constraint FK_PROFESORHORARIO foreign key (ID_Profesor) references Profesores(ID_Profesor)




 --Insertado de datos

--Insertar datos en la tabla notasMateria para hacer prueba
insert into NotasMateria(Nota,Estado)
values (0,'Reprobado');

 --Insertar datos a fecha feriado
 insert into FechaFeriados(ID_Fecha,Fecha,Motivo)
 values('FKM123','01-02-2022','Prueba');

 --Insertar datos a idioma
 insert into Idiomas(ID_Idioma,NombreIdioma)
 values('IDM321','Inglés'),
		('IDM456','Francés'),
		('IDM845','Alemán'),
		('IDM541','Mandarín');

--Insertar datos en la tabla Cursos
insert into Cursos(ID_Curso,ID_Idioma,ID_Nota,NombreCurso,CantidadCursos,HorasCurso,HorasSincronicas,HorasAsincronicas,Precio)
values ('CRO123','IDM321',1,'Inglés',12,80,20,60,200000),
	   ('CRO456','IDM456',1,'Francés',4,100,25,75,250000),
	   ('CRO789','IDM845',1,'Alemán',10,94,23,71,235000),
	   ('CRO987','IDM541',1,'Mandarín',14,120,30,90,300000);


--Insertarn datos en la tabla profesores
insert into Profesores(Nombre,Apellido1,Apellido2,Correo,Telefono)
values('Paco','Carrazco','Carrazco','PacoCRZ@ina.cr',81828384),
      ('Lucas','Zeledon','Carrazco','LucasZC@ina.cr',81855152),
	  ('Marina','Herrera','Carrazco','MarinaCRZ@ina.cr',81812514),
	  ('Manfred','Orozco','Orozco','Manfred0121@ina.cr',81828465);

--Insertar daatos en la tabla HorarioProfesores
insert into HorarioProfesor(ID_Profesor,FechaInicio,FechaFinal,Estado)--sin colocar hora inicio ni hora final, son datos para colocar clases
values  (1,'2022-05-02 08:00:00','2022-05-06 16:00:00','Libre'),
		(2,'2022-05-02 08:00:00','2022-05-06 16:00:00','Libre'),
		(3,'2022-05-02 14:00:00','2022-05-06 22:00:00','Libre'),
		(4,'2022-05-02 14:00:00','2022-05-06 22:00:00','Libre');

--insertar datos en la tabla certificacion
insert into Certificaciones(ID_Certificado,ID_Profesor,Materia)
values	('CER123',1,'Inglés'),
		('CER456',2,'Francés'),
		('CER789',3,'Alemán'),
		('CER987',4,'Mandarín');
		
---- insertar datos en la tabla estudiantes para hacer pruebas
insert into Estudiantes(Nombre,Apellido1,Apellido2,Correo,Telefono)
values('Paco','Carrazco','Carrazco','CPAC@gmail.com',84951351);

--Insertar datos de claseSincronica
insert into ClaseSincronica(ID_Estudiante,ID_Profesor,ID_Curso,FechaClase,HoraInicio,HoraFinal)
values(1,1,'CRO123','2022-05-06','16:00:00',' 16:00:00');
 

  --insertar en tabla matricula
 insert into Matricula(ID_Estudiantes,ID_Curso,Intensidad,FechaMatricula,TotalPago,EstadoPago)
values(1,'CRO123',1,'2022-05-02 08:00:00',12000,'COMPLETO')

go

CREATE or alter PROCEDURE INSERTARIDIOMA
		@ididioma varchar(20),  --recibe un id
		@nombreidioma varchar(80),
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
if (not exists(select * from Idiomas where ID_Idioma=@ididioma))
	begin

		if(not exists(select * from Idiomas where NombreIdioma=@nombreidioma))
			begin
			insert into Idiomas(ID_Idioma,NombreIdioma) 
			values (@ididioma,@nombreidioma);

			set @msj='Idioma agregado correctamente'
			return 1
			end
		else
		begin
			set @msj='El NOMBRE del IDIOMA ya se encuentra en la base de datos'
			return 0
		end
		
	end
else
	begin
		
		set @msj='El CODIGO del Idioma ya se encuentra en la base de datos'
		return 0
	end
END
GO

----------------------------------------------
CREATE or alter PROCEDURE INSERTARCURSO
		@idCurso varchar(20),  --recibe un id
		@idNota int,
		@idIdioma varchar(20),
		@nombreCurso varchar(60),
		@cantidadCurso int,
		@horasCurso int,
		@horasSincronicas int,
		@horasAsincronicas int,
		@precio float,
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
	if(not exists(select * from Cursos where NombreCurso=@nombreCurso))
		begin

			if(not exists(select * from Cursos inner join NotasMateria on NotasMateria.ID_Nota = @idNota ))
			begin
				set @msj='El ID_NOTA NO se encuentra en la base de datos'
				return 2
			end
			else if(not exists(select * from Cursos inner join Idiomas on Idiomas.ID_Idioma = @idIdioma))
			begin 
				set @msj='El ID_IDIOMA NO se encuentra en la base de datos'
				return 3
			end
			else
			begin

				insert into Cursos(ID_Curso,ID_Idioma,ID_Nota,NombreCurso,CantidadCursos,HorasCurso,HorasSincronicas,HorasAsincronicas,Precio) 
				values (@idCurso,@idIdioma,@idNota,@nombreCurso,@cantidadCurso,@horasCurso,@horasSincronicas,@horasAsincronicas,@precio);

				set @msj='Curso agregado correctamente'
				return 1
			end
			
		end
	else
	begin
		set @msj='El NOMBRE del CURSO ya se encuentra en la base de datos'
		return 0
	end
end

go



--------------------------
CREATE or alter PROCEDURE INSERTARMATRICULA
		--@idMatricula int,  --recibe un id
		@idEstudiante int,
		@idCurso varchar(20),
		@intensidad int,
		@fechaMatricula date,
		@totalPago float,
		@estadoPago varchar(20),
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN

	if(exists(select * from Matricula inner join Estudiantes on Estudiantes.ID_Estudiantes = Matricula.ID_Estudiantes where Matricula.ID_Estudiantes=@idEstudiante))
	begin
		set @msj='El Estudiante ya se encuentra matriculado'
		return 0
	end
	else 
	begin
		if(exists(select * from Matricula inner join Estudiantes on Estudiantes.ID_Estudiantes = @idEstudiante ))
			begin

				if(not exists(select * from Matricula inner join Cursos on Cursos.ID_Curso = @idCurso))
				begin
					set @msj='El ID_CURSO NO se encuentra en la base de datos'
					return 0
				end
				else
				begin
					if(exists(select Precio from Cursos inner join Matricula on Matricula.ID_Curso = Cursos.ID_Curso where Cursos.Precio >= @totalPago))
					begin

						insert into Matricula(ID_Estudiantes,ID_Curso,Intensidad,FechaMatricula,TotalPago,EstadoPago) 
						values (@idEstudiante,@idCurso,@intensidad,@fechaMatricula,@totalPago,@estadoPago);

						set @msj='Matricula agregada correctamente'
						return 1

					end
					else
					begin
						set @msj='El precio digitado es mayor al precio del curso'
						return 0 
					end
					
				end
			
			end
		else
		begin
			set @msj='El ID_ESTUDIANTE NO se encuentra en la base de datos'
			return 0
		end
	end
	
end
GO


CREATE or alter PROCEDURE MODIFICARMATRICULA
		@idMatricula int,  --recibe un id
		--@idEstudiante int,
		@idCurso varchar(20),
		@intensidad int,
		@fechaMatricula date,
		@totalPago float,
		@estadoPago varchar(20),
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
	update Matricula set ID_Curso=@idCurso,Intensidad=@intensidad,FechaMatricula=@fechaMatricula,TotalPago=@totalPago,
            EstadoPago=@estadoPago where ID_Matricula=@idMatricula

	set @msj='Matricula Modificada correctamente'
	return 1
	
end
GO

	--------------------------
CREATE or alter PROCEDURE MODIFICARESTUDIANTE
		@idEstudiante int,  --recibe un id
		@nombre varchar(20),
		@apellido1 varchar(20),
		@apellido2 varchar(20),
		@correo varchar(50),
		@telefono int,
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
	update Estudiantes set Nombre=@nombre, Apellido1=@apellido1, 
           Apellido2=@apellido2,Correo=@correo,Telefono=@telefono where ID_Estudiantes=@idEstudiante
		   set @msj='Agregado Correctamente'
		   return 1
END
GO
	--------------------------
CREATE or alter PROCEDURE INSERTARESTUDIANTE
		--@idEstudiante int,  --recibe un id
		@nombre varchar(20),
		@apellido1 varchar(20),
		@apellido2 varchar(20),
		@correo varchar(50),
		@telefono int,
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
	if(exists(select * from Estudiantes where Nombre=@nombre ) and exists(select * from Estudiantes where Apellido1=@apellido1 )
		and exists(select * from Estudiantes where Apellido2=@apellido2))
		begin
			set @msj='El ESTUDIANTE ya se encuentra en la base de datos'
			return 0	
		end
		else
		begin
			if(exists(select * from Estudiantes where Correo=@correo))
			begin
				set @msj='El CORREO ya se encuentra en la base de datos'
				return 0
			end
		else
		begin

			insert into Estudiantes(Nombre,Apellido1,Apellido2,Correo,Telefono) 
			values (@nombre,@apellido1,@apellido2,@correo,@telefono);

			set @msj='Estudiante agregado correctamente'
			return 1
					
		end
	end
END
GO


CREATE or alter PROCEDURE INSERTARNOTA
		--@idNota int,  --recibe un id
		@nota float,
		@estado varchar(20),
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN 
	insert into NotasMateria( Nota,Estado) 
	values (@nota,@estado);

	set @msj='Nota agregada correctamente'
	return 1
END
GO

		--------------------------
CREATE or alter PROCEDURE INSERTARCLASESINCRONICA
		--@ID int,  --recibe un id
		@idEstudiante int,
		@idProfesor int,
		@idCurso varchar(20),
		@fechaClase datetime,
		@horaInicio datetime,
		@horaFinal datetime,
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
	if(exists(select * from ClaseSincronica inner join Estudiantes on Estudiantes.ID_Estudiantes=@idEstudiante))
		begin

			if(exists(select * from ClaseSincronica inner join Profesores on Profesores.ID_Profesor=@idProfesor))
			begin
				if(exists(select * from ClaseSincronica inner join Cursos on Cursos.ID_Curso=@idCurso))
				begin
					insert into ClaseSincronica( ID_Estudiante,ID_Profesor,ID_Curso,FechaClase,HoraInicio,HoraFinal) 
					values (@idEstudiante,@idProfesor,@idCurso,@fechaClase,@horaInicio,@horaFinal);

					set @msj='Estudiante agregado correctamente'
					return 1
				end
				else
				begin 
					set @msj='El ID_CURSO NO se encuentra en la base de datos'
					return 0
				end
			end
			else
			begin
				set @msj='El ID_PROFESOR NO se encuentra en la base de datos'
				return 0
			end
		end
		else
		begin
			set @msj='El ID_ESTUDIANTE NO se encuentra en la base de datos'
			return 0
		end
END
GO

CREATE or alter PROCEDURE INSERTARCERTIFICADO
		--@ID int,  --recibe un id
		@idCertificado varchar(20),
		@idProfesor int,
		@materia varchar(20),
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
	if(exists(select * from Profesores inner join Certificaciones on Profesores.ID_Profesor=@idProfesor))
		begin
			if(exists(select * from Certificaciones where ID_Certificado=@idCertificado))
			begin
				set @msj='El ID_CERTIFICADO ya se encuentra en la base de datos'
				return 0
			end
			else
			begin
				insert into Certificaciones(ID_Certificado,ID_Profesor,Materia) 
				values (@idCertificado,@idProfesor,@materia);

				set @msj='Certificacion agregada correctamente'
				return 1
			end
			
		end
		else
		begin
			set @msj='El ID_PROFESOR NO se encuentra en la base de datos'
			return 0
		end
END
GO

CREATE or alter PROCEDURE INSERTARPROFESOR
		--@ID_Profesor int,  --recibe un id
		@nombre varchar(20),
		@apellido1 varchar(20),
		@apellido2 varchar(20),
		@correo varchar(50),
		@telefono int,
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
	if(exists(select * from Profesores where Nombre=@nombre ) and exists(select * from Profesores where Apellido1=@apellido1 )
		and exists(select * from Profesores where Apellido2=@apellido2))
		begin
			set @msj='El PROFESOR ya se encuentra en la base de datos'
			return 0	
		end
		else
		begin
			if(exists(select * from Profesores where Correo=@correo))
			begin
				set @msj='El CORREO ya se encuentra en la base de datos'
				return 0
			end
		else
		begin

			insert into Profesores(Nombre,Apellido1,Apellido2,Correo,Telefono) 
			values (@nombre,@apellido1,@apellido2,@correo,@telefono);

			set @msj='PROFESOR agregado correctamente'
			return 1
					
		end
	end
END
GO---------------------------------------------


CREATE or alter PROCEDURE INSERTARHORARIOPROFESOR
		--@ID_Profesor int,  --recibe un id
		@idProfesor int,
		@horaInicio time,
		@horaFinal time,
		@fechaInicio datetime,
		@fechaFinal datetime,
		@estado varchar(30),
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
	if(not exists(select * from HorarioProfesor where ID_Profesor=@idProfesor))
	begin
		set @msj='El ID_PROFESOR NO se encuentra en la base de datos'
		return 0	
	end
	else
	begin

		insert into HorarioProfesor(ID_Profesor,HoraInicio,HoraFinal,FechaInicio,FechaFinal,Estado) 
		values (@idProfesor,@horaInicio,@horaFinal,@fechaInicio,@fechaFinal,@estado);

		set @msj='PROFESOR agregado correctamente'
		return 1

	end
END
GO--------------------------------------------


CREATE or alter PROCEDURE INSERTARFECHAFERIADO
		--@ID_Profesor int,  --recibe un id
		@idFecha varchar(20),
		@fecha date,
		@motivo varchar(20),
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
	if(not exists(select * from FechaFeriados where ID_Fecha=@idFecha))
	begin
		insert into FechaFeriados(ID_Fecha,Fecha,Motivo) 
		values (@idFecha,@fecha,@motivo);

		set @msj='Fecha agregado correctamente'
		return 1
			
	end
	else
	begin

		set @msj='El ID_FECHAFERIADO ya se encuentra en la base de datos'
		return 0

	end
END
GO------------------------------------
