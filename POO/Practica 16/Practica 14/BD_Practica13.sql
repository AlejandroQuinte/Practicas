create database BD_CAPAS_PRACTICA1
go

use BD_CAPAS_PRACTICA1
go

CREATE TABLE CLIENTES(
	ID_CLIENTE int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	NOMBRE varchar(80) NOT NULL,
	TELEFONO varchar(11) NULL,
	DIRECCION varchar(80) NULL,
)

select * from CLIENTES;

create table EncabezadoFactura(
	ID_Factura int identity(1,1) not null primary key,
	Fecha datetime not null,
	ID_Cliente int not null,
	Subtotal float,
	Impuesto float not null,
	MontoDescuento float
);

create table DetalleFactura(
	ID_Factura int identity not null primary key,
	ID_Producto int not null,
	Cantidad int not null
);

create table Productos(
	ID_Producto int identity not null primary key,
	Descripcion varchar(50) not null,
	PrecioCompra float not null,
	PrecioVenta float not null,
	Gravado varchar(20) not null
);

select * from Productos;
ALTER TABLE DetalleFactura
ADD CONSTRAINT FK_IDProducto FOREIGN KEY (ID_Producto) REFERENCES Productos(ID_Producto)

ALTER TABLE DetalleFactura
ADD CONSTRAINT FK_IDFactura FOREIGN KEY (ID_Factura) REFERENCES EncabezadoFactura(ID_Factura)

alter table EncabezadoFactura
add constraint FK_IDCliente foreign key (ID_Cliente) references Clientes(ID_Cliente)
go


--Procedimientos
CREATE PROCEDURE ELIMINARCLIENTE
		@idcliente int,  --recibe un id
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
if (not exists(select * from CLIENTES where ID_CLIENTE=@idcliente))
	begin
		set @msj='El cliente no existe'
		return 0
	end
else
	begin
		DELETE from CLIENTES where ID_CLIENTE=@idcliente
		set @msj='Cliente eliminado'
		return 1
	end
END
GO
--
CREATE PROCEDURE MODIFICARCLIENTE
		@idcliente int,  --recibe la informacion del cliente
		@nombre varchar(20),
		@telefono int,
		@direccion varchar(100),
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
if (not exists(select * from CLIENTES where ID_CLIENTE=@idcliente))
	begin
		insert into CLIENTES(NOMBRE,TELEFONO,DIRECCION) values (@nombre,@telefono,@direccion);
		set @msj='El Cliente a sido Agregado'
		return 1
	end
else
	begin
		update CLIENTES set NOMBRE=@nombre,TELEFONO=@telefono, DIRECCION=@direccion where
				ID_CLIENTE=@idcliente;
		
		set @msj='El Cliente a sido Modificado'
		return 1
	end
END
GO

--Procedimiento producto
--Procedimientos
CREATE PROCEDURE ELIMINARPRODUCTO
		@idproducto int,  --recibe un id
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
if (not exists(select * from Productos where ID_Producto=@idproducto))
	begin
		set @msj='El producto no existe'
		return 0
	end
else
	begin
		DELETE from Productos where ID_Producto=@idproducto
		set @msj='Producto eliminado'
		return 1
	end
END
GO
--


CREATE PROCEDURE MODIFICARPRODUCTO
		@idproducto int,  --recibe la informacion del cliente
		@descripcion varchar(50),
		@precioCompra float,
		@precioVenta float,
		@gravado varchar(20),
		@msj varchar(50) out   --devuelve un mensaje
AS BEGIN
if (not exists(select * from Productos where ID_Producto=@idproducto))
	begin
		insert into Productos(Descripcion,PrecioCompra,PrecioVenta,Gravado) values (@descripcion,@precioCompra,@precioVenta,@gravado);
		set @msj='El Producto a sido Agregado'
		return 1
	end
else
	begin
		update Productos set Descripcion=@descripcion,PrecioCompra=@precioCompra, PrecioVenta=@precioVenta, Gravado= @gravado where
				ID_Producto=@idproducto;
		
		set @msj='El Producto a sido Modificado'
		return 1
	end
END
GO