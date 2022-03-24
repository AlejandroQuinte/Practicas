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


ALTER TABLE DetalleFactura
ADD CONSTRAINT FK_IDProducto FOREIGN KEY (ID_Producto) REFERENCES Productos(ID_Producto)

ALTER TABLE DetalleFactura
ADD CONSTRAINT FK_IDFactura FOREIGN KEY (ID_Factura) REFERENCES EncabezadoFactura(ID_Factura)

alter table EncabezadoFactura
add constraint FK_IDCliente foreign key (ID_Cliente) references Clientes(ID_Cliente)