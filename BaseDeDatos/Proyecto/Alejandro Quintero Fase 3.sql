--Uso de la base de datos
use UFuenteConocimiento
go

--Consultas simples
--1-Nombres del programa y sus materias 
create view vNombreMaterias as
select NOMBREPROGRAMA as Programa,NOMBRECURSO as Curso
from Programas inner join Cursos
	on Cursos.ID_PROGRAMAS= Programas.ID_PROGRAMAS
go
--2-Horario y nombre de los cursosabiertos
create view vNombreCursoA as
select NOMBRECURSO,DIA,HORA_INICIO,HORA_FINAL
from Cursos left join CursosAbiertos
	on CursosAbiertos.ID_CURSOABIERTO=Cursos.ID_CURSOABIERTO
		inner join Horario
		on CursosAbiertos.ID_CURSOABIERTO=Horario.ID_CURSOABIERTO
go
--3-Fecha de inicio y fecha final de los cursos abiertos, con su horario respectivo
create view vFechaHorario as
select NOMBRECURSO,FECHA_INICIO,FECHA_FINAL,DIA,HORA_INICIO,HORA_INICIO,HORA_FINAL
from Cursos right join CursosAbiertos
	on CursosAbiertos.ID_CURSOABIERTO=Cursos.ID_CURSOABIERTO
		inner join Horario
		on CursosAbiertos.ID_CURSOABIERTO=Horario.ID_CURSOABIERTO
		
go
--4-Informacion de los estudiantes matriculados
create view vEstudiantesM as
select Estudiantes.ID_ESTUDIANTES,NOMBRE_ESTUDIANTE+' '+PRIMER_APELLIDO_E+' '+SEGUNDO_APELLIDO_E as NombreCompleto,CORREO_ESTUDIANTE,TELEFONO_ESTUDIANTE
from Estudiantes full join Matricula
	on Matricula.ID_ESTUDIANTES=Estudiantes.ID_ESTUDIANTES
go
--5-Informacion de los estudiantes y nombre de las materias matriculadas
create view vEstudiantesMateriasM as
select Estudiantes.ID_ESTUDIANTES,NOMBRE_ESTUDIANTE+' '+PRIMER_APELLIDO_E+' '+SEGUNDO_APELLIDO_E as NombreCompleto,CORREO_ESTUDIANTE,TELEFONO_ESTUDIANTE,NOMBRECURSO
from Estudiantes right join Matricula
	on Matricula.ID_ESTUDIANTES=Estudiantes.ID_ESTUDIANTES
	inner join DetalleMatricula
		on DetalleMatricula.ID_MATRICULA=Matricula.ID_MATRICULA
		inner join CursosAbiertos 
			on CursosAbiertos.ID_CURSOABIERTO=DetalleMatricula.ID_CURSOABIERTO
			inner join Cursos
				on Cursos.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
				where  Matricula.ID_ESTUDIANTES is not null
go
--Agregar informacion
insert into Estudiantes(ID_ESTUDIANTES,NOMBRE_ESTUDIANTE,PRIMER_APELLIDO_E,SEGUNDO_APELLIDO_E,CORREO_ESTUDIANTE,TELEFONO_ESTUDIANTE)
	values ('11','Paco','Quesada','Aguero','256984@ina.cr','84596602')
insert into Matricula(ID_MATRICULA,ID_ESTUDIANTES,FECHAMATRICULA,TOTALMATRICULA,ESTADOPAGO)
	values	('11','11',GETDATE(),15000,'COMPLETO')

--6-Informacion de los profesores y nombre de los cursos que imparten
create view vProfesoresCursos as
select Profesores.ID_PROFESOR,NOMBRE_PROFESOR+' '+PRIMER_APELLIDO_P+' '+SEGUNDO_APELLIDO_P as NombreCompleto, TELEFONO_PROFESOR,CORREO_PROFESOR,NOMBRECURSO
from Profesores inner join Certificaciones
	on Certificaciones.ID_PROFESOR= Profesores.ID_PROFESOR
		inner join CursosAbiertos
		on CursosAbiertos.ID_CERTIFICADO=Certificaciones.ID_CERTIFICADO
			inner join Cursos
			on Cursos.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
go
--Consultas de selecci



n funciones agregadadas
--1-Nombre de los cursos que tienen una duracion menor a las 100 horas

select NOMBRECURSO,DURACION
	from Cursos
	  group by NOMBRECURSO,DURACION
	  having DURACION<100

--2-Nombre de los cursos que tienen el programa 2 y tienen un precio menor a 300 mil
--dado caso que un estudiante lleve cualquier programa y tiene un determinado dinero puede hacer la comprobacion con esta consulta, solo se deben editar los numeros
select NOMBRECURSO,PRECIO
from Cursos inner join Programas
	on Cursos.ID_PROGRAMAS=Programas.ID_PROGRAMAS
	where Programas.ID_PROGRAMAS='2'
	 group by NOMBRECURSO,PRECIO
	 having PRECIO < 300000
	
--3-Nombre del estudiante con pago incompleto y que el precio sea menor a 20 mil
select NOMBRE_ESTUDIANTE+' '+PRIMER_APELLIDO_E+' '+SEGUNDO_APELLIDO_E as NombreCompleto,TOTALMATRICULA,ESTADOPAGO
from Estudiantes inner join Matricula
 on Matricula.ID_ESTUDIANTES=Matricula.ID_ESTUDIANTES
	where ESTADOPAGO='INCOMPLETO'
	group by NOMBRE_ESTUDIANTE,PRIMER_APELLIDO_E,SEGUNDO_APELLIDO_E,TOTALMATRICULA,ESTADOPAGO
	having TOTALMATRICULA<20000
	
--Editar para poder hacer pruebas
update Matricula
	set TOTALMATRICULA=20000,
	    ESTADOPAGO = 'INCOMPLETO'
	where ID_MATRICULA='1'
update Matricula
	set ESTADOPAGO = 'INCOMPLETO'
	where ID_MATRICULA='6'			
update Matricula
	set ESTADOPAGO = 'INCOMPLETO'
	where ID_MATRICULA='4'	
update Matricula
	set TOTALMATRICULA=20000
	where ID_MATRICULA='5'

--4-Consulta de Nombre, Fecha_Inicio, Fecha_Final, Duracion y Cuantos dias dura el Curso
select NOMBRECURSO,FECHA_INICIO,FECHA_FINAL,DURACION,DATEDIFF(DD,FECHA_INICIO,FECHA_FINAL) as DIAS
from CursosAbiertos inner join Cursos
 on Cursos.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
  group by NOMBRECURSO,FECHA_INICIO,FECHA_FINAL,DURACION
  having DURACION <100

--Editar CursosAbiertos para realizar consultas
update CursosAbiertos
	set FECHA_FINAL='2021-09-17'
	where ID_CURSOABIERTO='6'
update CursosAbiertos
	set FECHA_FINAL='2021-09-18'
	where ID_CURSOABIERTO='7'
update CursosAbiertos
	set FECHA_FINAL='2021-10-18'
	where ID_CURSOABIERTO='9'
update CursosAbiertos
	set FECHA_FINAL='2021-09-18'
	where ID_CURSOABIERTO='8'
update CursosAbiertos
	set FECHA_FINAL='2021-09-25'
	where ID_CURSOABIERTO='10'

--5-Fecha de Matricula de matricula nombre de estudiante y total de matricula, para los estudiantes que se matricularon en el mes 6 
--y el total de la matricula sea mayor a 20 mil
select NOMBRE_ESTUDIANTE+' '+PRIMER_APELLIDO_E+' '+SEGUNDO_APELLIDO_E as NombreCompleto,FECHAMATRICULA,SUM(TOTALMATRICULA) as TOTAL_X_FECHA
from Matricula inner join Estudiantes
 on Estudiantes.ID_ESTUDIANTES=Matricula.ID_ESTUDIANTES
	where MONTH(FECHAMATRICULA)=6
	group by FECHAMATRICULA,NOMBRE_ESTUDIANTE,PRIMER_APELLIDO_E,SEGUNDO_APELLIDO_E
		having SUM(TOTALMATRICULA)>10000
		order by FECHAMATRICULA

--Editar para hacer las consultas
update Matricula
	set FECHAMATRICULA='2021-06-08'
	where ID_ESTUDIANTES='1'

--6-Consulta de ID_Estudiante, Nombre Completo y el Monto a pagar de los estudiantes matriculados
select Estudiantes.ID_ESTUDIANTES,NOMBRE_ESTUDIANTE+' '+PRIMER_APELLIDO_E+' '+SEGUNDO_APELLIDO_E as NombreCompleto,PRECIO
from Estudiantes inner join NotasMateria
	on NotasMateria.ID_ESTUDIANTES=Estudiantes.ID_ESTUDIANTES
	inner join Cursos
	 on Cursos.ID_CURSO=NotasMateria.ID_CURSO
	  group by Estudiantes.ID_ESTUDIANTES,NOMBRE_ESTUDIANTE,PRIMER_APELLIDO_E,SEGUNDO_APELLIDO_E,PRECIO
	  order by NombreCompleto

--7-Nombre de los cursos que tienen horario los sabados y viernes

select NOMBRECURSO,DIA,HORA_INICIO,HORA_FINAL
from Cursos inner join CursosAbiertos
	on CursosAbiertos.ID_CURSOABIERTO=Cursos.ID_CURSOABIERTO
	inner join Horario on Horario.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
		group by NOMBRECURSO,DIA,HORA_FINAL,HORA_INICIO
		having DIA in('S','V')

--8-ID de la matricula, la fecha de la matricula el precio de la matricula y el promedio de precio total de todos los cursos, que su totalmatricula sea mayor a 10 mil
select ID_MATRICULA,FECHAMATRICULA,TOTALMATRICULA,(select avg(PRECIO)
							   from Cursos inner join CursosAbiertos
								on Cursos.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
								inner join DetalleMatricula
								  on DetalleMatricula.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
								    inner join Matricula
									on Matricula.ID_MATRICULA=DetalleMatricula.ID_MATRICULA) as Promedio
from MATRICULA
	group by ID_MATRICULA,FECHAMATRICULA,TOTALMATRICULA
	having TOTALMATRICULA>10000


--Ordenar tablas
--1-Ordenamiento de tabla por nombre de estudiante
select ID_ESTUDIANTES,NOMBRE_ESTUDIANTE,PRIMER_APELLIDO_E,SEGUNDO_APELLIDO_E,CORREO_ESTUDIANTE,TELEFONO_ESTUDIANTE
from Estudiantes
order by NOMBRE_ESTUDIANTE asc
--2-Ordenamiento de cursos mediante nombre
select ID_CURSO,NOMBRECURSO,DURACION,PRECIO
from Cursos
order by NOMBRECURSO asc
--3-Ordenamiento de cursos mediante su precio menor a mayor
select ID_CURSO,NOMBRECURSO,DURACION,PRECIO
from Cursos
order by PRECIO asc
--4-Ordenamiento de cursos mediante su duracion y dias
select ID_CURSO,NOMBRECURSO,DURACION,DATEDIFF(DD,FECHA_INICIO,FECHA_FINAL)as DIAS,PRECIO
from Cursos inner join CursosAbiertos
on CursosAbiertos.ID_CURSOABIERTO=Cursos.ID_CURSOABIERTO
	inner join Horario
	 on Horario.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
	 order by DURACION asc, DIAS asc 

---Uniones de tablas
--1
select ID_CERTIFICADO,MATERIA
from Certificaciones
union
select ID_CURSO,NOMBRECURSO
from Cursos
--2
select HORA_INICIO,HORA_FINAL,FECHA_INICIO,FECHA_FINAL
from CursosAbiertos inner join Horario
	on CursosAbiertos.ID_CURSOABIERTO=Horario.ID_CURSOABIERTO
union
select HORA_INICIO,HORA_FINAL,FECHA_INICIO,FECHA_FINAL
from CursosAbiertos inner join HorarioProfesores
	on CursosAbiertos.ID_HORARIOPROFESOR=HorarioProfesores.ID_HORARIOPROFESOR
go
--Consultas de ayuda al usuario
--1-ID Curso, Nombre, precio y horario de los cursos disponibles
create view vNombreCursoPrecioHorario as
select ID_CURSO,NOMBRECURSO,PRECIO,DIA,HORA_INICIO,HORA_FINAL
from Cursos inner join CursosAbiertos
	on CursosAbiertos.ID_CURSOABIERTO=Cursos.ID_CURSOABIERTO
	inner join Horario
	 on Horario.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
go
--2-id profesor, nombre de los profesores, su horario y cursos que imparten
create view vNombreProfesorHorarioCurso as
select Profesores.ID_PROFESOR,NOMBRE_PROFESOR,NOMBRECURSO,HORA_INICIO,HORA_FINAL
from Profesores inner join HorarioProfesores
 on HorarioProfesores.ID_PROFESOR=Profesores.ID_PROFESOR
 inner join CursosAbiertos
  on CursosAbiertos.ID_HORARIOPROFESOR=HorarioProfesores.ID_HORARIOPROFESOR
  inner join Cursos
   on Cursos.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
go

--Procedimientos almacenados
/*Tabla Profesores*/
--1-Agragado de nuevos profesores
create or alter procedure SP_GUARDAR_PROFESOR (@ID_PROFESOR varchar(20) out,
										 @NOMBRE_PROFESOR varchar(20),@PRIMER_APELLIDO_P varchar(20),
										 @SEGUNDO_APELLIDO_P varchar(20),
										 @TELEFONO_PROFESOR int,
										 @CORREO_PROFESOR varchar(50),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Profesores where ID_PROFESOR=@ID_PROFESOR))
				begin 
					insert into Profesores(ID_PROFESOR,NOMBRE_PROFESOR,PRIMER_APELLIDO_P,SEGUNDO_APELLIDO_P,TELEFONO_PROFESOR,CORREO_PROFESOR)
					values(@ID_PROFESOR,@NOMBRE_PROFESOR,@PRIMER_APELLIDO_P,@SEGUNDO_APELLIDO_P,@TELEFONO_PROFESOR,@CORREO_PROFESOR)
					select @ID_PROFESOR=IDENT_CURRENT('Profesores')
					set @msj='Profesor Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'Profesor ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla Profesores
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_PROFESOR varchar(20)
DECLARE @NOMBRE_PROFESOR varchar(20)
DECLARE @PRIMER_APELLIDO_P varchar(20)
DECLARE @SEGUNDO_APELLIDO_P varchar(20)
DECLARE @TELEFONO_PROFESOR int
DECLARE @CORREO_PROFESOR varchar(50)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_PROFESOR ='11'
set @NOMBRE_PROFESOR ='PANCHO'
set @PRIMER_APELLIDO_P ='CARRAZCO'
set @SEGUNDO_APELLIDO_P = 'TREVOL'
set @TELEFONO_PROFESOR = 84512697
set @CORREO_PROFESOR='475545sadas@ina.cr'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_GUARDAR_PROFESOR]
	@ID_PROFESOR output,
	@NOMBRE_PROFESOR,
	@PRIMER_APELLIDO_P,
	@SEGUNDO_APELLIDO_P,
	@TELEFONO_PROFESOR,
	@CORREO_PROFESOR,
	@msj output
	print 'ID_PROFESOR '+@ID_PROFESOR
	print @msj
go
--2-Editado de profesor
create procedure SP_EDITAR_PROFESOR (@ID_PROFESOR varchar(20) out,
										 @NOMBRE_PROFESOR varchar(20),@PRIMER_APELLIDO_P varchar(20),
										 @SEGUNDO_APELLIDO_P varchar(20),
										 @TELEFONO_PROFESOR int,
										 @CORREO_PROFESOR varchar(50),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Profesores where ID_PROFESOR=@ID_PROFESOR))
				begin
					set @msj='Profesor NO existe, No se puede editar'
				end
			else
				begin
					update Profesores set ID_PROFESOR=@ID_PROFESOR,
										  NOMBRE_PROFESOR=@NOMBRE_PROFESOR,
										  PRIMER_APELLIDO_P=@PRIMER_APELLIDO_P,
										  SEGUNDO_APELLIDO_P=@SEGUNDO_APELLIDO_P,
										  TELEFONO_PROFESOR=@TELEFONO_PROFESOR,
										  CORREO_PROFESOR=@CORREO_PROFESOR
					where ID_PROFESOR = @ID_PROFESOR
					set @msj = 'Profesor Actualizado Correctamente'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_PROFESOR varchar(20)
DECLARE @NOMBRE_PROFESOR varchar(20)
DECLARE @PRIMER_APELLIDO_P varchar(20)
DECLARE @SEGUNDO_APELLIDO_P varchar(20)
DECLARE @TELEFONO_PROFESOR int
DECLARE @CORREO_PROFESOR varchar(50)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_PROFESOR ='11'
set @NOMBRE_PROFESOR ='PANCHO'
set @PRIMER_APELLIDO_P ='CARRAZCO'
set @SEGUNDO_APELLIDO_P = 'TRUNDLE'
set @TELEFONO_PROFESOR = 84512697
set @CORREO_PROFESOR='475545sadas@ina.cr'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_PROFESOR]
	@ID_PROFESOR output,
	@NOMBRE_PROFESOR,
	@PRIMER_APELLIDO_P,
	@SEGUNDO_APELLIDO_P,
	@TELEFONO_PROFESOR,
	@CORREO_PROFESOR,
	@msj output
	print 'ID_PROFESOR '+@ID_PROFESOR
	print @msj
go

--3-Eliminado de un PROFESOR
create  or alter procedure SP_ELIMINAR_PROFESOR (@ID_PROFESOR varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Profesores where ID_PROFESOR=@ID_PROFESOR))
				begin 
					delete from Profesores where ID_PROFESOR  = @ID_PROFESOR
					set @msj = 'PROFESOR Eliminado Correctamente'
				end
			else
				begin
					set @msj = 'PROFESOR NO existe, Agregue alguno'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecutar Procedimiento #3
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_PROFESOR varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_PROFESOR ='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_PROFESOR]
	@ID_PROFESOR output,
	@msj output
	print 'ID_PROFESOR '+@ID_PROFESOR
	print @msj
go

--4-MOSTRADO de un PROFESOR
create procedure SP_MOSTRAR_PROFESOR (@ID_PROFESOR varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Profesores where ID_PROFESOR=@ID_PROFESOR))
				begin 
					Select ID_PROFESOR,NOMBRE_PROFESOR,PRIMER_APELLIDO_P,SEGUNDO_APELLIDO_P,TELEFONO_PROFESOR,CORREO_PROFESOR
					from Profesores
					where ID_PROFESOR=@ID_PROFESOR
				end
			else
				begin
					set @msj = 'PROFESOR NO existe, Agregue alguno'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_PROFESOR varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_PROFESOR ='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_MOSTRAR_PROFESOR]
	@ID_PROFESOR output,
	@msj output
	print 'ID_PROFESOR '+@ID_PROFESOR
	print @msj
go

---------------------------------------------------------------------------

/*Tabla certificaciones*/
--1-Agregado de nuevo certificado 
create or alter procedure SP_GUARDAR_CERTIFICADO (@ID_Certificado varchar(20) out,
										 @ID_Profesor varchar(20),@Materia varchar(50),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Certificaciones where ID_CERTIFICADO=@ID_Certificado))
				begin 
					insert into Certificaciones(ID_CERTIFICADO,ID_PROFESOR,MATERIA)
					values(@ID_Certificado,@ID_Profesor,@Materia)
					select @ID_Certificado=IDENT_CURRENT('Certificaciones')
					set @msj='Certificado Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'CERTIFICADO ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla certificados
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_Certificado varchar(20)
DECLARE @ID_Profesor varchar(20)
DECLARE @Materia varchar(50)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_Certificado = '11'
set @ID_Profesor = '11'
set @Materia = 'Nuevo Certificado'
/*EJECUCION DEL PROCEDIMIENTO*/--Primero se deben agregar datos a profesor
execute @RC = [dbo].[SP_GUARDAR_CERTIFICADO]
	@ID_Certificado output,
	@ID_Profesor,
	@Materia,
	@msj output
	print 'ID_CERTIFICADO '+@ID_Certificado
	print @msj
go

--2-EDITAR un certificado
create procedure SP_EDITAR_CERTIFICADO (@ID_Certificado varchar(20) out,
										 @ID_Profesor varchar(20),@Materia varchar(50),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Certificaciones where ID_CERTIFICADO=@ID_Certificado))
				begin 
					set @msj='CERTIFICADO NO existe, No se puede editar'
				end
			else
				begin
					update Certificaciones set ID_CERTIFICADO=@ID_Certificado,
											   ID_PROFESOR=@ID_Profesor,
											   MATERIA=@Materia
					where ID_CERTIFICADO = @ID_Certificado
					set @msj = 'Certificado Actualizado Correctamente'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_Certificado varchar(20)
DECLARE @ID_Profesor varchar(20)
DECLARE @Materia varchar(50)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_Certificado = '11'
set @ID_Profesor = '11'
set @Materia = 'Nuevo Certificado'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_CERTIFICADO]
	@ID_Certificado output,
	@ID_Profesor,
	@Materia,
	@msj output
	print 'ID_CERTIFICADO '+@ID_Certificado
	print @msj
go

--3-Eliminado de un certificado
create procedure SP_ELIMINAR_CERTIFICADO (@ID_Certificado varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Certificaciones where ID_CERTIFICADO=@ID_Certificado))
				begin 
					delete from Certificaciones where ID_CERTIFICADO=@ID_Certificado
					set @msj = 'Certificado Eliminado Correctamente'
				end
			else
				begin
					set @msj = 'Certificado NO existe, Agregue alguno'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecutar Procedimiento #3
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_Certificado varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_Certificado = '11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_CERTIFICADO]
	@ID_Certificado output,
	@msj output
	print 'ID_CERTIFICADO '+@ID_Certificado
	print @msj
go

--4-Consulta de datos
create procedure SP_CONSULTA_CERTIFICADO (@ID_Certificado varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Certificaciones where ID_CERTIFICADO=@ID_Certificado))
				begin 
					select ID_CERTIFICADO,ID_PROFESOR,MATERIA
					from Certificaciones
					where ID_CERTIFICADO=@ID_Certificado
				end
			else
				begin
					set @msj = 'Certificado NO existe'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_Certificado varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_Certificado = '11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_CONSULTA_CERTIFICADO]
	@ID_Certificado output,
	@msj output
	print 'ID_CERTIFICADO '+@ID_Certificado
	print @msj
go

-------------------------------------------------------
/*Tabla Programas*/
--1-Agregado de nuevo programa
create procedure SP_GUARDAR_PROGRAMA (@ID_PROGRAMA varchar(20) out,
										 @NOMBREPROGRAMA varchar(80),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Programas where ID_PROGRAMAS=@ID_PROGRAMA))
				begin 
					insert into Programas(ID_PROGRAMAS,NOMBREPROGRAMA)
					values(@ID_PROGRAMA,@NOMBREPROGRAMA)
					select @ID_PROGRAMA=IDENT_CURRENT('Programas')
					set @msj='Programa Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'Programa ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla programas
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_PROGRAMA varchar(20)
DECLARE @NOMBREPROGRAMA varchar(50)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_PROGRAMA = '4'
set @NOMBREPROGRAMA = 'Nuevo Programa'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_GUARDAR_PROGRAMA]
	@ID_PROGRAMA output,
	@NOMBREPROGRAMA,
	@msj output
	print 'ID_PROGRAMA '+@ID_PROGRAMA
	print @msj
go

--2-EDITADO de programa
create procedure SP_EDITAR_PROGRAMA (@ID_PROGRAMA varchar(20) out,
										 @NOMBREPROGRAMA varchar(80),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Programas where ID_PROGRAMAS=@ID_PROGRAMA))
				begin 
					set @msj='Programa No se puede editar, No se encuentra'
				end
			else
				begin
					update Programas set ID_PROGRAMAS=@ID_PROGRAMA,
										 NOMBREPROGRAMA=@NOMBREPROGRAMA
					where ID_PROGRAMAS = @ID_PROGRAMA
					set @msj = 'Programa Actualizado Correctamente'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla programas
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_PROGRAMA varchar(20)
DECLARE @NOMBREPROGRAMA varchar(50)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_PROGRAMA = '4'
set @NOMBREPROGRAMA = 'Nuevo Programa'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_PROGRAMA]
	@ID_PROGRAMA output,
	@NOMBREPROGRAMA,
	@msj output
	print 'ID_PROGRAMA '+@ID_PROGRAMA
	print @msj
go


--3-ELIMINADO de programa
create procedure SP_ELIMINAR_PROGRAMA (@ID_PROGRAMA varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Programas where ID_PROGRAMAS=@ID_PROGRAMA))
				begin 
					delete from Programas where ID_PROGRAMAS=@ID_PROGRAMA
					set @msj = 'Certificado Eliminado Correctamente'
				end
			else
				begin
					set @msj = 'Programa NO existe en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla programas
--Ejecutar Procedimiento #3
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_PROGRAMA varchar(20)
DECLARE @NOMBREPROGRAMA varchar(50)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_PROGRAMA = '4'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_PROGRAMA]
	@ID_PROGRAMA output,
	@msj output
	print 'ID_PROGRAMA '+@ID_PROGRAMA
	print @msj
go


--4-MOSTRADO de un programa
create procedure SP_MOSTRAR_PROGRAMA (@ID_PROGRAMA varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Programas where ID_PROGRAMAS=@ID_PROGRAMA))
				begin 
					select ID_PROGRAMAS,NOMBREPROGRAMA
					from Programas
					where ID_PROGRAMAS=@ID_PROGRAMA
				end
			else
				begin
					set @msj = 'Programa NO existe en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla programas
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_PROGRAMA varchar(20)
DECLARE @NOMBREPROGRAMA varchar(50)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_PROGRAMA = '4'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_MOSTRAR_PROGRAMA]
	@ID_PROGRAMA output,
	@msj output
	print 'ID_PROGRAMA '+@ID_PROGRAMA
	print @msj
go


/*Tabla ESTUDIANTES*/
--1-Agregado de nuevo estudiante
create procedure SP_GUARDAR_ESTUDIANTE (@ID_ESTUDIANTE varchar(20) out,
										 @NOMBRE_ESTUDIANTE varchar(20),
										 @PRIMER_APELLIDO_E varchar(20),
										 @SEGUNDO_APELLIDO_E varchar(20),
										 @CORREO_ESTUDIANTE varchar(25),
										 @TELEFONO_ESTUDIANTE varchar(8),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Estudiantes where ID_ESTUDIANTES=@ID_ESTUDIANTE))
				begin 
					insert into Estudiantes(ID_ESTUDIANTES,NOMBRE_ESTUDIANTE,PRIMER_APELLIDO_E,SEGUNDO_APELLIDO_E,CORREO_ESTUDIANTE,TELEFONO_ESTUDIANTE)
					values(@ID_ESTUDIANTE,@NOMBRE_ESTUDIANTE,@PRIMER_APELLIDO_E,@SEGUNDO_APELLIDO_E,@CORREO_ESTUDIANTE,@TELEFONO_ESTUDIANTE)
					select @ID_ESTUDIANTE=IDENT_CURRENT('Estudiantes')
					set @msj='ESTUDIANTE Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'ESTUDIANTE ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla estudiantes
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_ESTUDIANTE varchar(20)
DECLARE @NOMBRE_ESTUDIANTE varchar(20)
DECLARE @PRIMER_APELLIDO_E varchar(20)
DECLARE @SEGUNDO_APELLIDO_E varchar(20)
DECLARE @CORREO_ESTUDIANTE varchar(25)
DECLARE @TELEFONO_ESTUDIANTE varchar(8)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_ESTUDIANTE = '12'
set @NOMBRE_ESTUDIANTE='FRANCO' 
set @PRIMER_APELLIDO_E ='CARRAZCO'
set @SEGUNDO_APELLIDO_E ='CARRAZCO'
set @CORREO_ESTUDIANTE ='estudiante12@ina.cr'
set @TELEFONO_ESTUDIANTE ='84516237'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_GUARDAR_ESTUDIANTE]
	@ID_ESTUDIANTE output,
	@NOMBRE_ESTUDIANTE,
	@PRIMER_APELLIDO_E,
	@SEGUNDO_APELLIDO_E,
	@CORREO_ESTUDIANTE,
	@TELEFONO_ESTUDIANTE,
	@msj output
	print 'ID_ESTUDIANTE '+@ID_ESTUDIANTE
	print @msj
go

--2-EDITADO de nuevo estudiante
create procedure SP_EDITAR_ESTUDIANTE (@ID_ESTUDIANTE varchar(20) out,
										 @NOMBRE_ESTUDIANTE varchar(20),
										 @PRIMER_APELLIDO_E varchar(20),
										 @SEGUNDO_APELLIDO_E varchar(20),
										 @CORREO_ESTUDIANTE varchar(25),
										 @TELEFONO_ESTUDIANTE varchar(8),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Estudiantes where ID_ESTUDIANTES=@ID_ESTUDIANTE))
				begin 
					set @msj='ESTUDIANTE No existe en la base de datos, no se puede editar'
				end
			else
				begin
					update Estudiantes
					set ID_ESTUDIANTES=@ID_ESTUDIANTE,
						NOMBRE_ESTUDIANTE= @NOMBRE_ESTUDIANTE,
						PRIMER_APELLIDO_E= @PRIMER_APELLIDO_E,
						SEGUNDO_APELLIDO_E= @SEGUNDO_APELLIDO_E,
						CORREO_ESTUDIANTE= @CORREO_ESTUDIANTE,
						TELEFONO_ESTUDIANTE= @TELEFONO_ESTUDIANTE
					where ID_ESTUDIANTES=@ID_ESTUDIANTE
					set @msj='ESTUDIANTE ACTUALIZADO CORRECTAMENTE'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_ESTUDIANTE varchar(20)
DECLARE @NOMBRE_ESTUDIANTE varchar(20)
DECLARE @PRIMER_APELLIDO_E varchar(20)
DECLARE @SEGUNDO_APELLIDO_E varchar(20)
DECLARE @CORREO_ESTUDIANTE varchar(25)
DECLARE @TELEFONO_ESTUDIANTE varchar(8)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_ESTUDIANTE = '12'
set @NOMBRE_ESTUDIANTE='FRANCO' 
set @PRIMER_APELLIDO_E ='CARRAZCO'
set @SEGUNDO_APELLIDO_E ='CARRAZCO'
set @CORREO_ESTUDIANTE ='estudiante12@ina.cr'
set @TELEFONO_ESTUDIANTE ='84516237'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_ESTUDIANTE]
	@ID_ESTUDIANTE output,
	@NOMBRE_ESTUDIANTE,
	@PRIMER_APELLIDO_E,
	@SEGUNDO_APELLIDO_E,
	@CORREO_ESTUDIANTE,
	@TELEFONO_ESTUDIANTE,
	@msj output
	print 'ID_ESTUDIANTE '+@ID_ESTUDIANTE
	print @msj
go

--3-ELIMINAR estudiante
create procedure SP_ELIMINAR_ESTUDIANTE (@ID_ESTUDIANTE varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Estudiantes where ID_ESTUDIANTES=@ID_ESTUDIANTE))
				begin 
					delete from Estudiantes
					where ID_ESTUDIANTES=@ID_ESTUDIANTE
					set @msj='ESTUDIANTE ELIMINADO CORRECTAMENTE'
				end
			else
				begin
					set @msj='ESTUDIANTE NO EXISTE EN LA BASE DE DATOS'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecutar Procedimiento #3
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_ESTUDIANTE varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_ESTUDIANTE = '12'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_ESTUDIANTE]
	@ID_ESTUDIANTE output,
	@msj output
	print 'ID_ESTUDIANTE '+@ID_ESTUDIANTE
	print @msj
go

--4-CONSULTAR estudiante
create procedure SP_CONSULTAR_ESTUDIANTE (@ID_ESTUDIANTE varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Estudiantes where ID_ESTUDIANTES=@ID_ESTUDIANTE))
				begin 
					select ID_ESTUDIANTES,NOMBRE_ESTUDIANTE,PRIMER_APELLIDO_E,SEGUNDO_APELLIDO_E
					from Estudiantes
					where ID_ESTUDIANTES=@ID_ESTUDIANTE
				end
			else
				begin
					set @msj='ESTUDIANTE NO EXISTE EN LA BASE DE DATOS'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_ESTUDIANTE varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_ESTUDIANTE = '12'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_CONSULTAR_ESTUDIANTE]
	@ID_ESTUDIANTE output,
	@msj output
	print 'ID_ESTUDIANTE '+@ID_ESTUDIANTE
	print @msj
go



/*Tabla MATRICULA*/
--1-Agregado de nuevo MATRICULA
create procedure SP_GUARDAR_MATRICULA (@ID_MATRICULA varchar(20) out,
										 @ID_ESTUDIANTES varchar(20),
										 @FECHAMATRICULA date,
										 @TOTALMATRICULA int,
										 @ESTADOPAGO varchar(30),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Matricula where ID_MATRICULA=@ID_MATRICULA))
				begin 
					insert into Matricula(ID_MATRICULA,ID_ESTUDIANTES,FECHAMATRICULA,TOTALMATRICULA,ESTADOPAGO)
					values(@ID_MATRICULA,@ID_ESTUDIANTES,@FECHAMATRICULA,@TOTALMATRICULA,@ESTADOPAGO)
					select @ID_MATRICULA=IDENT_CURRENT('Matricula')
					set @msj='ESTUDIANTE Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'MATRICULA ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go

--Ejecucion de procedimientos de tabla matricula
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_MATRICULA varchar(20)
DECLARE @ID_ESTUDIANTES varchar(20)
DECLARE @FECHAMATRICULA date
DECLARE @TOTALMATRICULA int
DECLARE @ESTADOPAGO varchar(30)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_MATRICULA = '12'
set @ID_ESTUDIANTES = '12'
set @FECHAMATRICULA = GETDATE()
set @TOTALMATRICULA = 17000
set @ESTADOPAGO = 'COMPLETO'

/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_GUARDAR_MATRICULA]
	@ID_MATRICULA output,
	@ID_ESTUDIANTES,
	@FECHAMATRICULA,
	@TOTALMATRICULA,
	@ESTADOPAGO,
	@msj output
	print 'ID_MATRICULA '+@ID_MATRICULA
	print @msj
go


--2-EDITADO MATRICULA
create or alter procedure SP_EDITAR_MATRICULA (@ID_MATRICULA varchar(20) out,
										 @ID_ESTUDIANTES varchar(20),
										 @FECHAMATRICULA date,
										 @TOTALMATRICULA int,
										 @ESTADOPAGO varchar(30),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Matricula where ID_MATRICULA=@ID_MATRICULA))
				begin 
					set @msj='MATRICULA NO EXISTE NO SE PUEDE EDITAR'
				end
			else
				begin
					update Matricula
						set ID_MATRICULA=@ID_MATRICULA,
							ID_ESTUDIANTES=@ID_ESTUDIANTES,
							FECHAMATRICULA=@FECHAMATRICULA,
							TOTALMATRICULA=@TOTALMATRICULA,
							ESTADOPAGO=@ESTADOPAGO
					where ID_MATRICULA=@ID_MATRICULA
					set @msj='MATRICULA ACTUALIZADO CORRECTAMENTE'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla matricula
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_MATRICULA varchar(20)
DECLARE @ID_ESTUDIANTES varchar(20)
DECLARE @FECHAMATRICULA date
DECLARE @TOTALMATRICULA int
DECLARE @ESTADOPAGO varchar(30)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_MATRICULA = '12'
set @ID_ESTUDIANTES = '12'
set @FECHAMATRICULA = GETDATE()
set @TOTALMATRICULA = 17000
set @ESTADOPAGO = 'COMPLETO'

/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_MATRICULA]
	@ID_MATRICULA output,
	@ID_ESTUDIANTES,
	@FECHAMATRICULA,
	@TOTALMATRICULA,
	@ESTADOPAGO,
	@msj output
	print 'ID_MATRICULA '+@ID_MATRICULA
	print @msj
go


--3-ELIMINADO DE MATRICULA
create procedure SP_ELIMINAR_MATRICULA (@ID_MATRICULA varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Matricula where ID_MATRICULA=@ID_MATRICULA))
				begin 
					delete from Matricula
					where ID_MATRICULA=@ID_MATRICULA
				end
			else
				begin
					set @msj ='LA MATRICULA NO EXISTE, NO SE PUEDE ELIMINAR'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla matricula
--Ejecutar Procedimiento #3
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_MATRICULA varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_MATRICULA = '12'

/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_MATRICULA]
	@ID_MATRICULA output,
	@msj output
	print 'ID_MATRICULA '+@ID_MATRICULA
	print @msj
go

--4-CONSULTA DE MATRICULA
create procedure SP_CONSULTAR_MATRICULA (@ID_MATRICULA varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Matricula where ID_MATRICULA=@ID_MATRICULA))
				begin 
					select ID_MATRICULA,ID_ESTUDIANTES,FECHAMATRICULA,TOTALMATRICULA,ESTADOPAGO
					from Matricula
					where ID_MATRICULA=@ID_MATRICULA
				end
			else
				begin
					set @msj ='LA MATRICULA NO EXISTE, NO SE PUEDE CONSULTAR'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla matricula
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_MATRICULA varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_MATRICULA = '12'

/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_CONSULTAR_MATRICULA]
	@ID_MATRICULA output,
	@msj output
	print 'ID_MATRICULA '+@ID_MATRICULA
	print @msj
go



/*Tabla HORARIOPROFESORES*/
--1-Agregado a HORARIOPROFESOR
create or alter procedure SP_GUARDAR_HORARIOPROFESOR (@ID_HORARIOPROFESOR varchar(20) out,
										 @ID_PROFESOR varchar(20),
										 @HORA_INICIO time,
										 @HORA_FINAL time,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from HorarioProfesores where ID_HORARIOPROFESOR=@ID_HORARIOPROFESOR))
				begin 
					insert into HorarioProfesores(ID_HORARIOPROFESOR,ID_PROFESOR,HORA_INICIO,HORA_FINAL)
					values(@ID_HORARIOPROFESOR,@ID_PROFESOR,@HORA_INICIO,@HORA_FINAL)
					select @ID_HORARIOPROFESOR=IDENT_CURRENT('HorarioProfesores')
					set @msj='HORARIOPROFESOR Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'HORARIOPROFESOR ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla HORARIOPROFESOR
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_HORARIOPROFESOR varchar(20)
DECLARE @ID_PROFESOR varchar(20)
DECLARE @HORA_INICIO time
DECLARE @HORA_FINAL time
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_HORARIOPROFESOR = '11'
set @ID_PROFESOR = '11'
set @HORA_INICIO = '07:00:00'
set @HORA_FINAL = '12:00:00'

/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_GUARDAR_HORARIOPROFESOR]
	@ID_HORARIOPROFESOR output,
	@ID_PROFESOR,
	@HORA_INICIO,
	@HORA_FINAL,
	@msj output
	print 'ID_HORARIOPROFESOR '+@ID_HORARIOPROFESOR
	print @msj
go



--2-EDITAR HORARIOPROFESOR
create procedure SP_EDITAR_HORARIOPROFESOR (@ID_HORARIOPROFESOR varchar(20) out,
										 @ID_PROFESOR varchar(20),
										 @HORA_INICIO time,
										 @HORA_FINAL time,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from HorarioProfesores where ID_HORARIOPROFESOR=@ID_HORARIOPROFESOR))
				begin 
					set @msj='HORARIOPROFESOR NO EXISTE EN LA BASE DE DATOS'
				end
			else
				begin
					update HorarioProfesores
						set ID_HORARIOPROFESOR=@ID_HORARIOPROFESOR,
							ID_PROFESOR=@ID_PROFESOR,
							HORA_INICIO=@HORA_INICIO,
							HORA_FINAL=@HORA_FINAL
						where ID_HORARIOPROFESOR=@ID_HORARIOPROFESOR
					set @msj='HORARIOPROFESOR EDITADO CORRECTAMENTE'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla HORARIOPROFESOR
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_HORARIOPROFESOR varchar(20)
DECLARE @ID_PROFESOR varchar(20)
DECLARE @HORA_INICIO time
DECLARE @HORA_FINAL time
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_HORARIOPROFESOR = '11'
set @ID_PROFESOR = '11'
set @HORA_INICIO = '07:00:00'
set @HORA_FINAL = '12:00:00'

/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_HORARIOPROFESOR]
	@ID_HORARIOPROFESOR output,
	@ID_PROFESOR,
	@HORA_INICIO,
	@HORA_FINAL,
	@msj output
	print 'ID_HORARIOPROFESOR '+@ID_HORARIOPROFESOR
	print @msj
go



--3-ELIMINAR HORARIOPROFESOR
create procedure SP_ELIMINAR_HORARIOPROFESOR (@ID_HORARIOPROFESOR varchar(20) out,
												@msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from HorarioProfesores where ID_HORARIOPROFESOR=@ID_HORARIOPROFESOR))
				begin 
					delete from HorarioProfesores
					where ID_HORARIOPROFESOR=@ID_HORARIOPROFESOR
					set @msj='HORARIOPROFESOR ELIMINADO CORRECTAMENTE'
				end
			else
				begin
					set @msj = 'EL HORARIO NO EXISTE EN LA BASE DE DATOS'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla HORARIOPROFESOR
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_HORARIOPROFESOR varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_HORARIOPROFESOR = '11'

/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_HORARIOPROFESOR]
	@ID_HORARIOPROFESOR output,
	@msj output
	print 'ID_HORARIOPROFESOR '+@ID_HORARIOPROFESOR
	print @msj
go


--4-CONSULTAR HORARIOPROFESOR
create procedure SP_CONSULTAR_HORARIOPROFESOR (@ID_HORARIOPROFESOR varchar(20) out,
												@msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from HorarioProfesores where ID_HORARIOPROFESOR=@ID_HORARIOPROFESOR))
				begin 
					select ID_HORARIOPROFESOR,ID_PROFESOR,HORA_INICIO,HORA_FINAL
					from HorarioProfesores
					where ID_HORARIOPROFESOR=@ID_HORARIOPROFESOR
				end
			else
				begin
					set @msj = 'EL HORARIO NO EXISTE EN LA BASE DE DATOS'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla HORARIOPROFESOR
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_HORARIOPROFESOR varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_HORARIOPROFESOR = '11'

/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_CONSULTAR_HORARIOPROFESOR]
	@ID_HORARIOPROFESOR output,
	@msj output
	print 'ID_HORARIOPROFESOR '+@ID_HORARIOPROFESOR
	print @msj
go



/*Tabla CURSOSABIERTOS*/
--1-Agregado a CURSOSABIERTOS
create or alter procedure SP_GUARDAR_CURSOSABIERTOS (@ID_CURSOABIERTO varchar(20) out,
										 @ID_CERTIFICADO varchar(20),
										 @ID_HORARIOPROFESOR varchar(20),
										 @FECHA_INICIO date,
										 @FECHA_FINAL date,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from CursosAbiertos where ID_CURSOABIERTO=@ID_CURSOABIERTO))
				begin 
					insert into CursosAbiertos(ID_CURSOABIERTO,ID_CERTIFICADO,ID_HORARIOPROFESOR,FECHA_INICIO,FECHA_FINAL)
					values(@ID_CURSOABIERTO,@ID_CERTIFICADO,@ID_HORARIOPROFESOR,@FECHA_INICIO,@FECHA_FINAL)
					select @ID_CURSOABIERTO=IDENT_CURRENT('CursosAbiertos')
					set @msj='CursosAbiertos Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'CursosAbiertos ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla CursosAbiertos
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_CURSOABIERTO varchar(20)
DECLARE @ID_CERTIFICADO varchar(20)
DECLARE @ID_HORARIOPROFESOR varchar(20)
DECLARE @FECHA_INICIO date
DECLARE @FECHA_FINAL date
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_CURSOABIERTO=11
set @ID_CERTIFICADO=11
set @ID_HORARIOPROFESOR=11
set @FECHA_INICIO=GETDATE()
set @FECHA_FINAL ='20210923'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_GUARDAR_CURSOSABIERTOS]
	@ID_CURSOABIERTO output,
	@ID_CERTIFICADO,
	@ID_HORARIOPROFESOR,
	@FECHA_INICIO,
	@FECHA_FINAL,
	@msj output
	print 'ID_CURSOABIERTO '+@ID_CURSOABIERTO
	print @msj
go
--2-EDITAR CURSOSABIERTOS
create procedure SP_EDITAR_CURSOSABIERTOS (@ID_CURSOABIERTO varchar(20) out,
										 @ID_CERTIFICADO varchar(20),
										 @ID_HORARIOPROFESOR varchar(20),
										 @FECHA_INICIO date,
										 @FECHA_FINAL date,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from CursosAbiertos where ID_CURSOABIERTO=@ID_CURSOABIERTO))
				begin 
					set @msj='CursosAbiertos No existe en la base de datos'
				end
			else
				begin
					update CursosAbiertos
						set ID_CURSOABIERTO=@ID_CURSOABIERTO,
							ID_CERTIFICADO=@ID_CERTIFICADO,
							ID_HORARIOPROFESOR=@ID_HORARIOPROFESOR,
							FECHA_INICIO=@FECHA_INICIO,
							FECHA_FINAL=@FECHA_FINAL
						where ID_CURSOABIERTO=@ID_CURSOABIERTO
					set @msj='CursosAbiertos editado correctamente'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla CursosAbiertos
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_CURSOABIERTO varchar(20)
DECLARE @ID_CERTIFICADO varchar(20)
DECLARE @ID_HORARIOPROFESOR varchar(20)
DECLARE @FECHA_INICIO date
DECLARE @FECHA_FINAL date
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_CURSOABIERTO='11'
set @ID_CERTIFICADO='11'
set @ID_HORARIOPROFESOR='11' 
set @FECHA_INICIO=GETDATE()
set @FECHA_FINAL =GETDATE()
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_CURSOSABIERTOS]
	@ID_CURSOABIERTO output,
	@ID_CERTIFICADO,
	@ID_HORARIOPROFESOR,
	@FECHA_INICIO,
	@FECHA_FINAL,
	@msj output
	print 'ID_CURSOABIERTO '+@ID_CURSOABIERTO
	print @msj
go


--3-ELIMINAR CURSOSABIERTOS
create procedure SP_ELIMINAR_CURSOSABIERTOS (@ID_CURSOABIERTO varchar(20) out,
											@msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from CursosAbiertos where ID_CURSOABIERTO=@ID_CURSOABIERTO))
				begin 
					delete from CursosAbiertos where ID_CURSOABIERTO=@ID_CURSOABIERTO
					set @msj='CursosAbiertos eliminado correctamente'
				end
			else
				begin
					set @msj='CursosAbiertos NO se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla CursosAbiertos
--Ejecutar Procedimiento #3
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_CURSOABIERTO varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_CURSOABIERTO='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_CURSOSABIERTOS]
	@ID_CURSOABIERTO output,
	@msj output
	print 'ID_CURSOABIERTO '+@ID_CURSOABIERTO
	print @msj
go

--4-CONSULTAR CURSOSABIERTOS
create procedure SP_CONSULTAR_CURSOSABIERTOS (@ID_CURSOABIERTO varchar(20) out,
											@msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from CursosAbiertos where ID_CURSOABIERTO=@ID_CURSOABIERTO))
				begin 
					select ID_CURSOABIERTO,ID_CERTIFICADO,ID_HORARIOPROFESOR,FECHA_INICIO,FECHA_FINAL
					from CursosAbiertos
					where ID_CURSOABIERTO=@ID_CURSOABIERTO
				end
			else
				begin
					set @msj='CursosAbiertos NO se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla CursosAbiertos
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_CURSOABIERTO varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_CURSOABIERTO='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_CONSULTAR_CURSOSABIERTOS]
	@ID_CURSOABIERTO output,
	@msj output
	print 'ID_CURSOABIERTO '+@ID_CURSOABIERTO
	print @msj
go


/*Tabla CURSOS*/
--1-Agregado a CURSOS
create procedure SP_GUARDAR_CURSOS (@ID_CURSO varchar(20) out,
										 @ID_CURSOABIERTO varchar(20),
										 @ID_PROGRAMAS varchar(20),
										 @NOMBRECURSO varchar(20),
										 @DURACION int,
										 @PRECIO float,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Cursos where ID_CURSO=@ID_CURSO))
				begin 
					insert into Cursos(ID_CURSO,ID_CURSOABIERTO,ID_PROGRAMAS,NOMBRECURSO,DURACION,PRECIO)
					values(@ID_CURSO,@ID_CURSOABIERTO,@ID_PROGRAMAS,@NOMBRECURSO,@DURACION,@PRECIO)
					select @ID_CURSO=IDENT_CURRENT('Cursos')
					set @msj='Curso Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'Curso ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla Cursos
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_CURSO varchar(20) 
DECLARE @ID_CURSOABIERTO varchar(20)
DECLARE @ID_PROGRAMAS varchar(20)
DECLARE @NOMBRECURSO varchar(20)
DECLARE @DURACION int
DECLARE @PRECIO float
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_CURSO='11'
set @ID_CURSOABIERTO='11' 
set @ID_PROGRAMAS ='4'
set @NOMBRECURSO ='Nuevo curso'
set @DURACION =40
set @PRECIO =85000
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_GUARDAR_CURSOS]
	@ID_CURSO output,
	@ID_CURSOABIERTO,
	@ID_PROGRAMAS,
	@NOMBRECURSO,
	@DURACION,
	@PRECIO,
	@msj output
	print 'ID_CURSO '+@ID_CURSO
	print @msj
go

--2-EDITAR CURSOS
create procedure SP_EDITAR_CURSOS (@ID_CURSO varchar(20) out,
										 @ID_CURSOABIERTO varchar(20),
										 @ID_PROGRAMAS varchar(20),
										 @NOMBRECURSO varchar(20),
										 @DURACION int,
										 @PRECIO float,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Cursos where ID_CURSO=@ID_CURSO))
				begin 
					set @msj='Curso no existe en la base de datos'
				end
			else
				begin
					update Cursos
						set ID_CURSO=@ID_CURSO,
							ID_CURSOABIERTO=@ID_CURSOABIERTO,
							ID_PROGRAMAS=@ID_PROGRAMAS,
							NOMBRECURSO=@NOMBRECURSO,
							DURACION=@DURACION,
							PRECIO=@PRECIO
					where ID_CURSO=@ID_CURSO
					set @msj = 'Curso editado correctamente'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla Cursos
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_CURSO varchar(20) 
DECLARE @ID_CURSOABIERTO varchar(20)
DECLARE @ID_PROGRAMAS varchar(20)
DECLARE @NOMBRECURSO varchar(20)
DECLARE @DURACION int
DECLARE @PRECIO float
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_CURSO='11'
set @ID_CURSOABIERTO='11' 
set @ID_PROGRAMAS ='4'
set @NOMBRECURSO ='Nuevo curso'
set @DURACION =40
set @PRECIO =85000
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_CURSOS]
	@ID_CURSO output,
	@ID_CURSOABIERTO,
	@ID_PROGRAMAS,
	@NOMBRECURSO,
	@DURACION,
	@PRECIO,
	@msj output
	print 'ID_CURSO '+@ID_CURSO
	print @msj
go

--3-ELIMINAR CURSOS
create procedure SP_ELIMINAR_CURSOS (@ID_CURSO varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Cursos where ID_CURSO=@ID_CURSO))
				begin 
					delete Cursos where ID_CURSO=@ID_CURSO
					set @msj = 'Curso eliminado correctamente'
				end
			else
				begin
					set @msj = 'Curso no se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla Cursos
--Ejecutar Procedimiento #3
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_CURSO varchar(20) 
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_CURSO='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_CURSOS]
	@ID_CURSO output,
	@msj output
	print 'ID_CURSO '+@ID_CURSO
	print @msj
go


--4-CONSULTAR CURSOS
create procedure SP_CONSULTAR_CURSOS (@ID_CURSO varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Cursos where ID_CURSO=@ID_CURSO))
				begin 
					select ID_CURSO,ID_CURSOABIERTO,ID_PROGRAMAS,NOMBRECURSO,DURACION,PRECIO
					from Cursos
					where ID_CURSO=@ID_CURSO
				end
			else
				begin
					set @msj = 'Curso no se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla Cursos
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_CURSO varchar(20) 
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_CURSO='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_CONSULTAR_CURSOS]
	@ID_CURSO output,
	@msj output
	print 'ID_CURSO '+@ID_CURSO
	print @msj
go



/*Tabla DETALLEMATRIUCLA*/
--1-Agregado a DETALLEMATRICULA
create procedure SP_GUARDAR_DETALLEMATRICULA (@ID_MATRICULA varchar(20) out,
										 @ID_CURSOABIERTO varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from DetalleMatricula where ID_MATRICULA=@ID_MATRICULA))
				begin 
					insert into DetalleMatricula(ID_MATRICULA,ID_CURSOABIERTO)
					values(@ID_MATRICULA,@ID_CURSOABIERTO)
					select @ID_MATRICULA=IDENT_CURRENT('DetalleMatricula')
					set @msj='DetalleMatricula Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'DetalleMatricula ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla DETALLEMATRICULA
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_MATRICULA varchar(20) 
DECLARE @ID_CURSOABIERTO varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_MATRICULA='11'
set @ID_CURSOABIERTO='11' 
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_GUARDAR_DETALLEMATRICULA]
	@ID_MATRICULA output,
	@ID_CURSOABIERTO output,
	@msj output
	print 'ID_MATRICULA '+@ID_MATRICULA
	print 'ID_CURSOABIERTO '+@ID_CURSOABIERTO
	print @msj
go


--2-Editar DETALLEMATRICULA
create procedure SP_EDITAR_DETALLEMATRICULA (@ID_MATRICULA varchar(20) out,
										 @ID_CURSOABIERTO varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from DetalleMatricula where ID_MATRICULA=@ID_MATRICULA))
				begin 
					set @msj='DetalleMatricula no se encuentra en la base de datos'
				end
			else
				begin
					update DetalleMatricula 
						set	ID_MATRICULA=@ID_MATRICULA,
							ID_CURSOABIERTO=@ID_CURSOABIERTO
					where ID_MATRICULA=@ID_MATRICULA
					set @msj = 'DetalleMatricula editado correctamente'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla DETALLEMATRICULA
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_MATRICULA varchar(20) 
DECLARE @ID_CURSOABIERTO varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_MATRICULA='11'
set @ID_CURSOABIERTO='11' 
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_DETALLEMATRICULA]
	@ID_MATRICULA output,
	@ID_CURSOABIERTO output,
	@msj output
	print 'ID_MATRICULA '+@ID_MATRICULA
	print 'ID_CURSOABIERTO '+@ID_CURSOABIERTO
	print @msj
go


--3-Eliminar DETALLEMATRICULA
create procedure SP_ELIMINAR_DETALLEMATRICULA (@ID_MATRICULA varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from DetalleMatricula where ID_MATRICULA=@ID_MATRICULA))
				begin 
					delete DetalleMatricula where ID_MATRICULA=@ID_MATRICULA
					set @msj='DetalleMatricula ELIMINADO CORRECTAMENTE'
				end
			else
				begin
					set @msj = 'DetalleMatricula no se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla DETALLEMATRICULA
--Ejecutar Procedimiento #3
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_MATRICULA varchar(20) 
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_MATRICULA='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_DETALLEMATRICULA]
	@ID_MATRICULA output,
	@msj output
	print 'ID_MATRICULA '+@ID_MATRICULA
	print @msj
go


--4-CONSULTAR DETALLEMATRICULA
create procedure SP_CONSULTAR_DETALLEMATRICULA (@ID_MATRICULA varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from DetalleMatricula where ID_MATRICULA=@ID_MATRICULA))
				begin 
					select ID_MATRICULA,ID_CURSOABIERTO
					from DetalleMatricula
					where ID_MATRICULA=@ID_MATRICULA
				end
			else
				begin
					set @msj = 'DetalleMatricula no se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla DETALLEMATRICULA
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_MATRICULA varchar(20) 
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_MATRICULA='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_CONSULTAR_DETALLEMATRICULA]
	@ID_MATRICULA output,
	@msj output
	print 'ID_MATRICULA '+@ID_MATRICULA
	print @msj
go


/*Tabla HORARIO*/
--1-Agregado a HORARIO
create procedure SP_GUARDAR_HORARIO (@ID_HORARIO varchar(20) out,
										 @ID_CURSOABIERTO varchar(20),
										 @HORA_INICIO time,
										 @HORA_FINAL time,
										 @DIA varchar(20),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Horario where ID_HORARIO=@ID_HORARIO))
				begin 
					insert into Horario(ID_HORARIO,ID_CURSOABIERTO,HORA_INICIO,HORA_FINAL,DIA)
					values(@ID_HORARIO,@ID_CURSOABIERTO,@HORA_INICIO,@HORA_FINAL,@DIA)
					select @ID_HORARIO=IDENT_CURRENT('Horario')
					set @msj='Horario Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'Horario ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla Horario
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_HORARIO varchar(20) 
DECLARE @ID_CURSOABIERTO varchar(20) 
DECLARE @HORA_INICIO time
DECLARE @HORA_FINAL time
DECLARE @DIA varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_HORARIO='11'
set @ID_CURSOABIERTO='11' 
set @HORA_INICIO='07:00:00'
set @HORA_FINAL='12:00:00'
set @DIA='L'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_GUARDAR_HORARIO]
	@ID_HORARIO output,
	@ID_CURSOABIERTO,
	@HORA_INICIO,
	@HORA_FINAL,
	@DIA,
	@msj output
	print 'ID_HORARIO '+@ID_HORARIO
	print @msj
go


--2-EDITAR HORARIO
create procedure SP_EDITAR_HORARIO (@ID_HORARIO varchar(20) out,
										 @ID_CURSOABIERTO varchar(20),
										 @HORA_INICIO time,
										 @HORA_FINAL time,
										 @DIA varchar(20),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Horario where ID_HORARIO=@ID_HORARIO))
				begin 
					set @msj='Horario NO se encuentra en la base de datos'
				end
			else
				begin
					update Horario
						set ID_HORARIO=@ID_HORARIO,
							ID_CURSOABIERTO=@ID_CURSOABIERTO,
							HORA_INICIO=@HORA_INICIO,
							HORA_FINAL=@HORA_FINAL
					where ID_HORARIO=@ID_HORARIO
					set @msj = 'Horario se edito correctamente'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla Horario
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_HORARIO varchar(20) 
DECLARE @ID_CURSOABIERTO varchar(20) 
DECLARE @HORA_INICIO time
DECLARE @HORA_FINAL time
DECLARE @DIA varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_HORARIO='11'
set @ID_CURSOABIERTO='11' 
set @HORA_INICIO='07:00:00'
set @HORA_FINAL='12:00:00'
set @DIA='L'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_HORARIO]
	@ID_HORARIO output,
	@ID_CURSOABIERTO,
	@HORA_INICIO,
	@HORA_FINAL,
	@DIA,
	@msj output
	print 'ID_HORARIO '+@ID_HORARIO
	print @msj
go


--3-ELIMINAR HORARIO
create procedure SP_ELIMINAR_HORARIO (@ID_HORARIO varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Horario where ID_HORARIO=@ID_HORARIO))
				begin 
					delete from Horario where ID_HORARIO=@ID_HORARIO
					set @msj='Horario eliminado correctamente'
				end
			else
				begin
					set @msj = 'Horario NO se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla Horario
--Ejecutar Procedimiento #3
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_HORARIO varchar(20) 
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_HORARIO='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_HORARIO]
	@ID_HORARIO output,
	@msj output
	print 'ID_HORARIO '+@ID_HORARIO
	print @msj
go

--4-CONSULTAR HORARIO
create procedure SP_CONSULTAR_HORARIO (@ID_HORARIO varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Horario where ID_HORARIO=@ID_HORARIO))
				begin 
					select ID_HORARIO,ID_CURSOABIERTO,HORA_INICIO,HORA_FINAL,DIA
					from Horario
					where ID_HORARIO=@ID_HORARIO
					set @msj='Horario eliminado correctamente'
				end
			else
				begin
					set @msj = 'Horario NO se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla Horario
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_HORARIO varchar(20) 
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_HORARIO='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_CONSULTAR_HORARIO]
	@ID_HORARIO output,
	@msj output
	print 'ID_HORARIO '+@ID_HORARIO
	print @msj
go


/*Tabla LABORATORIO*/
--1-Agregado a LABORATORIO
create procedure SP_GUARDAR_LABORATORIO (@ID_LABORATORIO varchar(20) out,
										 @ID_CURSO varchar(20),
										 @NOMBRELABORATORIO varchar(50),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Laboratorios where ID_LABORATORIO=@ID_LABORATORIO))
				begin 
					insert into Laboratorios(ID_LABORATORIO,ID_Curso,NOMBRELABORATORIO)
					values(@ID_LABORATORIO,@ID_CURSO,@NOMBRELABORATORIO)
					select @ID_LABORATORIO=IDENT_CURRENT('Laboratorios')
					set @msj='Laboratorio Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'Laboratorio ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla LABORATORIO
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_LABORATORIO varchar(20)
DECLARE @ID_CURSO varchar(20)
DECLARE @NOMBRELABORATORIO varchar(50)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_LABORATORIO='11'
set @ID_CURSO='11' 
set @NOMBRELABORATORIO='07:00:00'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_GUARDAR_LABORATORIO]
	@ID_LABORATORIO output,
	@ID_CURSO,
	@NOMBRELABORATORIO,
	@msj output
	print 'ID_LABORATORIO '+@ID_LABORATORIO
	print @msj
go


--2-EDITAR LABORATORIO
create procedure SP_EDITAR_LABORATORIO (@ID_LABORATORIO varchar(20) out,
										 @ID_CURSO varchar(20),
										 @NOMBRELABORATORIO varchar(50),
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from Laboratorios where ID_LABORATORIO=@ID_LABORATORIO))
				begin 
					set @msj='Laboratorio NO se encuentra en la base de datos'
				end
			else
				begin
					update Laboratorios
						set ID_LABORATORIO=@ID_LABORATORIO,
							ID_Curso=@ID_CURSO,
							NOMBRELABORATORIO=@NOMBRELABORATORIO
					where ID_LABORATORIO=@ID_LABORATORIO
					set @msj = 'Laboratorio actualizado correctamente'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla LABORATORIO
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_LABORATORIO varchar(20)
DECLARE @ID_CURSO varchar(20)
DECLARE @NOMBRELABORATORIO varchar(50)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_LABORATORIO='11'
set @ID_CURSO='11' 
set @NOMBRELABORATORIO='07:00:00'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_LABORATORIO]
	@ID_LABORATORIO output,
	@ID_CURSO,
	@NOMBRELABORATORIO,
	@msj output
	print 'ID_LABORATORIO '+@ID_LABORATORIO
	print @msj
go



--3-ELIMINAR LABORATORIO
create procedure SP_ELIMINAR_LABORATORIO (@ID_LABORATORIO varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Laboratorios where ID_LABORATORIO=@ID_LABORATORIO))
				begin 
					delete Laboratorios where ID_LABORATORIO=@ID_LABORATORIO
					set @msj='Laboratorio eliminado correctamente'
				end
			else
				begin
					set @msj = 'Laboratorio no se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla LABORATORIO
--Ejecutar Procedimiento #3
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_LABORATORIO varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_LABORATORIO='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_LABORATORIO]
	@ID_LABORATORIO output,
	@msj output
	print 'ID_LABORATORIO '+@ID_LABORATORIO
	print @msj
go

--4-CONSULTAR LABORATORIO
create procedure SP_CONSULTAR_LABORATORIO (@ID_LABORATORIO varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from Laboratorios where ID_LABORATORIO=@ID_LABORATORIO))
				begin 
					select ID_LABORATORIO,ID_Curso,NOMBRELABORATORIO
					from Laboratorios
					where ID_LABORATORIO=@ID_LABORATORIO
				end
			else
				begin
					set @msj = 'Laboratorio no se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla LABORATORIO
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_LABORATORIO varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_LABORATORIO='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_CONSULTAR_LABORATORIO]
	@ID_LABORATORIO output,
	@msj output
	print 'ID_LABORATORIO '+@ID_LABORATORIO
	print @msj
go



/*Tabla NOTASMATERIAS*/
--1-Agregado a NOTASMATERIAS
create procedure SP_GUARDAR_NOTASMATERIAS (@ID_NOTA varchar(20) out,
										 @ID_CURSO varchar(20),
										 @ID_ESTUDIANTE varchar(20),
										 @PERIODO int,
										 @NOTA float,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from NotasMateria where ID_NOTA=@ID_NOTA))
				begin 
					insert into NotasMateria(ID_NOTA,ID_CURSO,ID_ESTUDIANTES,PERIODO,NOTA)
					values(@ID_NOTA,@ID_CURSO,@ID_ESTUDIANTE,@PERIODO,@NOTA)
					select @ID_CURSO=IDENT_CURRENT('NotasMateria')
					set @msj='NotasMateria Ingresado Satisfactoriamente'
				end
			else
				begin
					set @msj = 'NotasMateria ya se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla NotasMateria
--Ejecutar Procedimiento #1
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_NOTA varchar(20)
DECLARE @ID_CURSO varchar(20)
DECLARE @ID_ESTUDIANTE varchar(20)
DECLARE @PERIODO int
DECLARE @NOTA float
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_NOTA ='11'
set @ID_CURSO ='11'
set @ID_ESTUDIANTE='11' 
set @PERIODO =1
set @NOTA =75
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_GUARDAR_NOTASMATERIAS]
	@ID_NOTA output,
	@ID_CURSO,
	@ID_ESTUDIANTE,
	@PERIODO,
	@NOTA,
	@msj output
	print 'ID_NOTA '+@ID_NOTA
	print @msj
go

--2-EDITAR NOTASMATERIAS
create procedure SP_EDITAR_NOTASMATERIAS (@ID_NOTA varchar(20) out,
										 @ID_CURSO varchar(20),
										 @ID_ESTUDIANTE varchar(20),
										 @PERIODO int,
										 @NOTA float,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(NOT exists (select 1 from NotasMateria where ID_NOTA=@ID_NOTA))
				begin 
					set @msj='NotasMateria no se encuentran en la base de datos'
				end
			else
				begin
					update NotasMateria 
						set ID_NOTA=@ID_NOTA,
							ID_CURSO=@ID_CURSO,
							ID_ESTUDIANTES=@ID_ESTUDIANTE,
							PERIODO=@PERIODO,
							NOTA=@NOTA
					where ID_NOTA=@ID_NOTA
					set @msj = 'NotasMateria ACTUALIZADO CORRECTAMENTE'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla NotasMateria
--Ejecutar Procedimiento #2
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_NOTA varchar(20)
DECLARE @ID_CURSO varchar(20)
DECLARE @ID_ESTUDIANTE varchar(20)
DECLARE @PERIODO int
DECLARE @NOTA float
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_NOTA ='11'
set @ID_CURSO ='11'
set @ID_ESTUDIANTE='11' 
set @PERIODO =1
set @NOTA =75
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_EDITAR_NOTASMATERIAS]
	@ID_NOTA output,
	@ID_CURSO,
	@ID_ESTUDIANTE,
	@PERIODO,
	@NOTA,
	@msj output
	print 'ID_NOTA '+@ID_NOTA
	print @msj
go


--3-ELIMINAR NOTASMATERIAS
create procedure SP_ELIMINAR_NOTASMATERIAS (@ID_NOTA varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from NotasMateria where ID_NOTA=@ID_NOTA))
				begin 
					delete NotasMateria where ID_NOTA=@ID_NOTA
					set @msj='NotasMateria ELIMINADO CORRECTAMENTE'
				end
			else
				begin
					set @msj = 'NotasMateria No se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla NotasMateria
--Ejecutar Procedimiento #3
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_NOTA varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_NOTA ='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_ELIMINAR_NOTASMATERIAS]
	@ID_NOTA output,
	@msj output
	print 'ID_NOTA '+@ID_NOTA
	print @msj
go

--4-CONSULTAR NOTASMATERIAS
create procedure SP_CONSULTAR_NOTASMATERIAS (@ID_NOTA varchar(20) out,
										 @msj varchar(50) out)
as
	begin try
		begin transaction
			if(exists (select 1 from NotasMateria where ID_NOTA=@ID_NOTA))
				begin 
					select ID_NOTA,ID_CURSO,ID_ESTUDIANTES,PERIODO,NOTA
					from NotasMateria
					where ID_NOTA=@ID_NOTA
				end
			else
				begin
					set @msj = 'NotasMateria No se encuentra en la base de datos'
				end
			commit transaction
	end try
	begin catch
		rollback transaction
		set @msj = ERROR_MESSAGE()
	end catch
go
--Ejecucion de procedimientos de tabla NotasMateria
--Ejecutar Procedimiento #4
/*DECLARACION DE VARIABLES*/
DECLARE @RC int
DECLARE @ID_NOTA varchar(20)
DECLARE @msj varchar(50)
/*ASIGNANDO VALORES*/
set @ID_NOTA ='11'
/*EJECUCION DEL PROCEDIMIENTO*/
execute @RC = [dbo].[SP_CONSULTAR_NOTASMATERIAS]
	@ID_NOTA output,
	@msj output
	print 'ID_NOTA '+@ID_NOTA
	print @msj
go



--Funciones
--1-Funcion para calcular el costo total del curso, sumando el total de la matricula y el total del curso
create or alter function fn_CALCULA_SUMA_COSTO(@ID_ESTUDIANTE varchar(20))
returns decimal(10,2) as
begin
	declare @costoCurso decimal(10,2),
			@costoMatricula decimal(10,2),
			@total decimal(10,2)

	select @costoCurso=SUM(PRECIO),@costoMatricula=sum(TOTALMATRICULA)
	from Estudiantes inner join Matricula
		on Matricula.ID_ESTUDIANTES=Estudiantes.ID_ESTUDIANTES
		inner join DetalleMatricula
		on DetalleMatricula.ID_MATRICULA=Matricula.ID_MATRICULA
		 inner join CursosAbiertos
		 on CursosAbiertos.ID_CURSOABIERTO=DetalleMatricula.ID_CURSOABIERTO
			inner join Cursos
			on Cursos.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
			where Estudiantes.ID_ESTUDIANTES=@ID_ESTUDIANTE and DATEPART(YYYY,FECHAMATRICULA)=DATEPART(YYYY,GETDATE());

	set @total=@costoCurso+@costoMatricula;
	return @total
end
go

--Consulta agregando la funcion anterior
--1-Mostrar el nombre completo del estudiante, el nombre del curso, la fecha de inicio, precio total del curso y matricula
select Estudiantes.ID_ESTUDIANTES,NOMBRE_ESTUDIANTE+' '+PRIMER_APELLIDO_E+' '+SEGUNDO_APELLIDO_E as NombreCompleto,
		NOMBRECURSO,FECHA_INICIO,FECHA_FINAL,DBO.fn_CALCULA_SUMA_COSTO(Estudiantes.ID_ESTUDIANTES) as PrecioTotal
from Estudiantes inner join Matricula
		on Matricula.ID_ESTUDIANTES=Estudiantes.ID_ESTUDIANTES
		inner join DetalleMatricula
		on DetalleMatricula.ID_MATRICULA=Matricula.ID_MATRICULA
		 inner join CursosAbiertos
		 on CursosAbiertos.ID_CURSOABIERTO=DetalleMatricula.ID_CURSOABIERTO
			inner join Cursos
			on Cursos.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
			order by NombreCompleto asc

go

--2-Funcion para saber un descuento determinado que podria dar la Universidad en algun curso, puede que la universidad le de un 5% de descuento
--en algun curso que escoja, con esta funcion se puede saber
create or alter function fn_CALCULA_DESCUENTO(@ID_CURSO varchar(20),@DESCUENTO decimal(10,2))
returns decimal(10,2) as
begin
	declare @costoCurso decimal(10,2),
			@total decimal(10,2)

	select @costoCurso=PRECIO
	from Programas inner join Cursos
		on Cursos.ID_PROGRAMAS=Programas.ID_PROGRAMAS
			where Cursos.ID_CURSO=@ID_CURSO
			set @total=ISNULL(@costoCurso,0)*(@DESCUENTO/100)

	return @total
end
go

--Consulta al id_estudiante, nombre estudiante,nombre del programa, nombre del curso precio del curso y precio total con el descuento del 5% ya realizado
--(El descuento puede ser cualquiera, 5% es un ejemplo )
select Estudiantes.ID_ESTUDIANTES,NOMBRE_ESTUDIANTE+' '+PRIMER_APELLIDO_E+' '+SEGUNDO_APELLIDO_E as NombreCompleto,NOMBREPROGRAMA,
		NOMBRECURSO,PRECIO,DBO.fn_CALCULA_DESCUENTO(Cursos.ID_CURSO,5) as PrecioTotal
from Estudiantes inner join Matricula
		on Matricula.ID_ESTUDIANTES=Estudiantes.ID_ESTUDIANTES
		inner join DetalleMatricula
		on DetalleMatricula.ID_MATRICULA=Matricula.ID_MATRICULA
		 inner join CursosAbiertos
		 on CursosAbiertos.ID_CURSOABIERTO=DetalleMatricula.ID_CURSOABIERTO
			inner join Cursos
			on Cursos.ID_CURSOABIERTO=CursosAbiertos.ID_CURSOABIERTO
			 inner join Programas
			 on Programas.ID_PROGRAMAS=Cursos.ID_PROGRAMAS
			 order by NombreCompleto asc
go


--Triggers
--Creacion de tabla Historial
create table Historial(
	FECHA date not null,
	CODIGO_ID varchar(20)not null,
	DESCRIPCION varchar(100)not null,
	TABLA varchar(50) not null,
	USUARIO varchar(20) not null
)
go
--Tabla Certificaciones
--TRIGGER INSERT
create or alter trigger TR_FI_CERTIFICACIONES
on Certificaciones for insert
as
	Print 'Se ingresó el dato correctamente'
	
	declare @CODIGO_ID varchar(20)
	select @CODIGO_ID=ID_CERTIFICADO from inserted

	insert into Historial(FECHA,CODIGO_ID,DESCRIPCION,TABLA,USUARIO)
		values (GETDATE(),@CODIGO_ID,'Se INGRESO un dato nuevo','CERTIFICACIONES',SYSTEM_USER)
go

--Tabla Cursos
--TRIGGER INSERT
create or alter trigger TR_FI_CURSOS
on Cursos for insert
as
	Print 'Se ingresó el dato correctamente'
	
	declare @CODIGO_ID varchar(20)
	select @CODIGO_ID=ID_CURSO from inserted

	insert into Historial(FECHA,CODIGO_ID,DESCRIPCION,TABLA,USUARIO)
		values (GETDATE(),@CODIGO_ID,'Se INGRESO un dato nuevo','Cursos',SYSTEM_USER)
go

--Tabla CursosAbiertos
--TRIGGER INSERT
create or alter trigger TR_FI_CURSOSABIERTOS
on CursosAbiertos for insert
as
	Print 'Se ingresó el dato correctamente'
	
	declare @CODIGO_ID varchar(20)
	select @CODIGO_ID=ID_CURSOABIERTO from inserted

	insert into Historial(FECHA,CODIGO_ID,DESCRIPCION,TABLA,USUARIO)
		values (GETDATE(),@CODIGO_ID,'Se INGRESO un dato nuevo','CursosAbiertos',SYSTEM_USER)
go

--Tabla Estudiantes
--TRIGGER INSERT
create or alter trigger TR_FI_ESTUDIANTES
on Estudiantes for insert
as
	Print 'Se ingresó el dato correctamente'
	
	declare @CODIGO_ID varchar(20)
	select @CODIGO_ID=ID_ESTUDIANTES from inserted

	insert into Historial(FECHA,CODIGO_ID,DESCRIPCION,TABLA,USUARIO)
		values (GETDATE(),@CODIGO_ID,'Se INGRESO un dato nuevo','Estudiantes',SYSTEM_USER)
go

--Tabla Horario
--TRIGGER INSERT
create or alter trigger TR_FI_HORARIO
on Horario for insert
as
	Print 'Se ingresó el dato correctamente'
	
	declare @CODIGO_ID varchar(20)
	select @CODIGO_ID=ID_HORARIO from inserted

	insert into Historial(FECHA,CODIGO_ID,DESCRIPCION,TABLA,USUARIO)
		values (GETDATE(),@CODIGO_ID,'Se INGRESO un dato nuevo','Horario',SYSTEM_USER)
go

--Tabla HorarioProfesores
--TRIGGER INSERT
create or alter trigger TR_FI_HORARIOPROFESORES
on HorarioProfesores for insert
as
	Print 'Se ingresó el dato correctamente'
	
	declare @CODIGO_ID varchar(20)
	select @CODIGO_ID=ID_HORARIOPROFESOR from inserted

	insert into Historial(FECHA,CODIGO_ID,DESCRIPCION,TABLA,USUARIO)
		values (GETDATE(),@CODIGO_ID,'Se INGRESO un dato nuevo','HorarioProfesores',SYSTEM_USER)
go

--Tabla Laboratorios
--TRIGGER INSERT
create or alter trigger TR_FI_LABORATORIOS
on Laboratorios for insert
as
	Print 'Se ingresó el dato correctamente'
	
	declare @CODIGO_ID varchar(20)
	select @CODIGO_ID=ID_LABORATORIO from inserted

	insert into Historial(FECHA,CODIGO_ID,DESCRIPCION,TABLA,USUARIO)
		values (GETDATE(),@CODIGO_ID,'Se INGRESO un dato nuevo','Laboratorios',SYSTEM_USER)
go

--Tabla Matricula
--TRIGGER INSERT
create or alter trigger TR_FI_MATRICULA
on Matricula for insert
as
	Print 'Se ingresó el dato correctamente'
	
	declare @CODIGO_ID varchar(20)
	select @CODIGO_ID=ID_MATRICULA from inserted

	insert into Historial(FECHA,CODIGO_ID,DESCRIPCION,TABLA,USUARIO)
		values (GETDATE(),@CODIGO_ID,'Se INGRESO un dato nuevo','Matricula',SYSTEM_USER)
go

--Tabla NotasMateria
--TRIGGER INSERT
create or alter trigger TR_FI_NOTASMATERIA
on NotasMateria for insert
as
	Print 'Se ingresó el dato correctamente'
	
	declare @CODIGO_ID varchar(20)
	select @CODIGO_ID=ID_NOTA from inserted

	insert into Historial(FECHA,CODIGO_ID,DESCRIPCION,TABLA,USUARIO)
		values (GETDATE(),@CODIGO_ID,'Se INGRESO un dato nuevo','NotasMateria',SYSTEM_USER)
go

--Tabla Profesores
--TRIGGER INSERT
create or alter trigger TR_FI_PROFESORES
on Profesores for insert
as
	Print 'Se ingresó el dato correctamente'
	
	declare @CODIGO_ID varchar(20)
	select @CODIGO_ID=ID_PROFESOR from inserted

	insert into Historial(FECHA,CODIGO_ID,DESCRIPCION,TABLA,USUARIO)
		values (GETDATE(),@CODIGO_ID,'Se INGRESO un dato nuevo','Profesores',SYSTEM_USER)
go

--Tabla Programas
--TRIGGER INSERT
create or alter trigger TR_FI_PROGRAMAS
on Programas for insert
as
	Print 'Se ingresó el dato correctamente'
	
	declare @CODIGO_ID varchar(20)
	select @CODIGO_ID=ID_PROGRAMAS from inserted

	insert into Historial(FECHA,CODIGO_ID,DESCRIPCION,TABLA,USUARIO)
		values (GETDATE(),@CODIGO_ID,'Se INGRESO un dato nuevo','Programas',SYSTEM_USER)
go

--Comprobacion de triggers
--Insert
--Tabla profesores
INSERT INTO Profesores(ID_PROFESOR,NOMBRE_PROFESOR,PRIMER_APELLIDO_P,SEGUNDO_APELLIDO_P,TELEFONO_PROFESOR,CORREO_PROFESOR)
	VALUES  (13,'Miguel Ángel','Chacon','Zuniga','86581111','miguel@ina.ac.cr');
--Tabla Certificaciones
insert into Certificaciones(ID_CERTIFICADO,ID_PROFESOR,MATERIA)
	values(13,13,'Materia Nueva');
--Tabla programa
INSERT INTO Programas(ID_PROGRAMAS,NOMBREPROGRAMA)
VALUES (5,'Nuevo programa1');
--Tabla estudiantes
INSERT INTO Estudiantes(ID_ESTUDIANTES,NOMBRE_ESTUDIANTE,PRIMER_APELLIDO_E,SEGUNDO_APELLIDO_E,TELEFONO_ESTUDIANTE,CORREO_ESTUDIANTE)
VALUES (13,'PANCHO','HERRERA','JIMENEZ','88848101','215470615@ina.cr');
--Tabla Matricula
INSERT INTO Matricula(ID_MATRICULA,ID_ESTUDIANTES,FECHAMATRICULA,TOTALMATRICULA,ESTADOPAGO)
VALUES (13,13,GETDATE(),12000,'COMPLETO');
--Tabla HorarioProfesor
INSERT INTO HorarioProfesores(ID_HORARIOPROFESOR,ID_PROFESOR,HORA_INICIO,HORA_FINAL)
VALUES (13,13,'08:10:00','12:00:00');
--Tabla CursosAbiertos
INSERT INTO CursosAbiertos(ID_CURSOABIERTO,ID_CERTIFICADO,ID_HORARIOPROFESOR,FECHA_INICIO,FECHA_FINAL)
VALUES (12,13,13,'20210812','20220414');
--Tabla Cursos
INSERT INTO Cursos(ID_CURSO,ID_CURSOABIERTO,ID_PROGRAMAS,NOMBRECURSO,DURACION,PRECIO)
VALUES (12,12,5,'Programa nuevo',200,710000);
--Tabla DetalleMatricula
INSERT INTO DetalleMatricula(ID_MATRICULA,ID_CURSOABIERTO)
VALUES (12,12);
--Tabla Horario
INSERT INTO Horario(ID_HORARIO,ID_CURSOABIERTO,HORA_INICIO,HORA_FINAL,DIA)
VALUES (12,12,'07:00:00','12:00:00','L');
--Tabla Laboratorios
INSERT INTO Laboratorios(ID_LABORATORIO,ID_Curso,NOMBRELABORATORIO)
VALUES (12,12,'LAB10');
--Tabla notas materia
INSERT INTO NotasMateria(ID_NOTA,ID_CURSO,ID_ESTUDIANTES,PERIODO,NOTA)
VALUES (12,12,12,0,0);




--Consultas hacia todas las tablas
select * from Certificaciones
select * from Cursos
select * from CursosAbiertos
select * from DetalleMatricula
select * from Estudiantes
select * from Horario
select * from HorarioProfesores
select * from Laboratorios
select * from Matricula
select * from NotasMateria
select * from Profesores
select * from Programas