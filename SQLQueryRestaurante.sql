
create database test1;
use RestauranteAWS;



/****************************/
/* Tabla EstadoMesa */
CREATE TABLE EstadoMesa (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL
);

/****************************/
/* Tabla EstadoPedido */
CREATE TABLE EstadoPedido (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL
);

/****************************/
/* Tabla Roles */
CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL
);

/****************************/
/* Tabla Sectores */
CREATE TABLE Sectores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL
);

/****************************/
/* Tabla Empleados */
CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SectorId INT NOT NULL,
    RolId INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Usuario VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    FOREIGN KEY (SectorId) REFERENCES Sectores(Id),
    FOREIGN KEY (RolId) REFERENCES Roles(Id)
);

/****************************/
/* Tabla Mesas */
CREATE TABLE Mesas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    EstadoMesaId INT DEFAULT 1,
    FOREIGN KEY (EstadoMesaId) REFERENCES EstadoMesa(Id)
);

/****************************/
/* Tabla Productos */
CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SectorId INT NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    Stock INT NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (SectorId) REFERENCES Sectores(Id)
);

/****************************/
insert into EstadoMesa(Descripcion)
values
	('cliente esperando pedido'),
	('cliente comiendo'),
	('cliente pagando'),
	('cerrada');

select * from EstadoMesa

/************************/
insert into EstadoPedido(Descripcion)
  values
		 ('listo para servir');
		('pendiente'),
		('en preparacion'),
		('finalizado');

select * from EstadoPedido

/************************************/
  insert into Roles(Descripcion)
  values
		('bartender'),
		('cervecero'),
		('cocinero'),
		('mozo'),
		('administrador'),
		('socio');
select * from Roles
/*****************************************/
  insert into Sectores(descripcion)
  values
		('Tragos'),
		('Cerveceria'),
		('Cocina'),
		('Postres'),
		('Administracion'),
		('Socio');

select * from Sectores
/*********************************************/
 insert into Empleados(SectorId, RolId, Nombre, Usuario, Password)
  values
		(1,1,'Lucas','lucas','1111'),
		(1,1,'Ariel','ariel','1111'),
		(2,2,'Adriana','adriana','1111'),
		(2,2,'Lili','lili','1111'),
		(3,3,'Fabian','fabian','1111'),
		(3,3,'Hector','hector','1111'),
		(4,4,'Carlos','carlos','1111'),
		(4,4,'Pepe','pepe','1111'),
		(5,5,'Admin1','unAdmin','2222'),
		(6,6,'Socio1','unSocio','3333');
	
	Select * from Empleados

use test1
ALTER TABLE Mesas
ADD CONSTRAINT DF_Mesas_EstadoMesaId DEFAULT 1 FOR EstadoMesaId;

/*cargamos Mesas*/
 insert into Mesas(Nombre)
  values('mesa para 6'),
		('mesa para 6'),
		('mesa para 8'),
		('terraza para 4'),
		('terraza para 6')
select * from Mesas;

/*Cargamos Productos */
insert into Productos(SectorId, Descripcion, Stock, Precio)
values
		(1,'Malbec Vino tinto',10,15500),
		(1,'Bonarda Vino tinto',12,22000),
		(1,'Michel Torino tinto',20,7600),
		(1,'Pantera Rosa',10,8000),
		(1,'Daikiri Frutilla',10,8000),
		(1,'Satanas',10,8000),
		(2,'Quilmes',50,4500),
		(2,'Estela',50,7000),
		(2,'Cerveza Artesanal Mendoza',15,6000),
		(2,'Cerveza Artesanal San Juan',13,6500),
		(3,'Espaguetis con estofado',25,9000),
		(3,'Vacio',30,12000),
		(3,'Milanesa',25,10000),
		(3,'Empanada',60,1500),
		(4,'Flan',15,2500),
		(4,'Tiramisu',15,2500),
		(4,'Helado',15,2500);
select * from Productos;

UPDATE Productos
SET Stock = CASE 
    WHEN Descripcion = 'Malbec Vino tinto' THEN 100
    WHEN Descripcion = 'Bonarda Vino tinto' THEN 102
    WHEN Descripcion = 'Michel Torino tinto' THEN 200
    WHEN Descripcion = 'Pantera Rosa' THEN 100
    WHEN Descripcion = 'Daikiri Frutilla' THEN 100
    WHEN Descripcion = 'Satanas' THEN 100
    WHEN Descripcion = 'Quilmes' THEN 500
    WHEN Descripcion = 'Estela' THEN 5000
    WHEN Descripcion = 'Cerveza Artesanal Mendoza' THEN 105
    WHEN Descripcion = 'Cerveza Artesanal San Juan' THEN 103
    WHEN Descripcion = 'Espaguetis con estofado' THEN 205
    WHEN Descripcion = 'Vacio' THEN 300
    WHEN Descripcion = 'Milanesa' THEN 205
    WHEN Descripcion = 'Empanada' THEN 600
    WHEN Descripcion = 'Flan' THEN 105
    WHEN Descripcion = 'Tiramisu' THEN 105
    WHEN Descripcion = 'Helado' THEN 105
    ELSE Stock -- Si no hay coincidencia, mantener el valor original
END
WHERE Descripcion IN (
    'Malbec Vino tinto', 'Bonarda Vino tinto', 'Michel Torino tinto',
    'Pantera Rosa', 'Daikiri Frutilla', 'Satanas', 'Quilmes',
    'Estela', 'Cerveza Artesanal Mendoza', 'Cerveza Artesanal San Juan',
    'Espaguetis con estofado', 'Vacio', 'Milanesa', 'Empanada',
    'Flan', 'Tiramisu', 'Helado'
);

/* IMPORTANTE 3 
Nota:
No se puede Generar un pedido si no existe una comanda
Para crear una comanda necesitamos :
Id que es el numero de mesa, y su nombre significa donde queda y para cuantas personas es la mesa.
nombreCliente : El nombre del cliente
codigoComanda : Es un código Alfanumerico de 5 caracteres

Ahora si podemos crear un pedido ya que tenemos el Id de la comanda (ComandaId)
para crear el pedido necesitamos:
ProductoId : Este ya esta precargado, según su Id es el producto relacionado.
ComandaId : La comanda generada para esa mesa y cliente (Deberia de existir para poder crear el pedido).
EstadoId : Son 3 los estados posibles, "Pendiente", "En preparación" y "Listo para servir"
Cantidad: La cantidad del producto solicitado.
FechaCreacion : Se auto completa con la fecha del dia generado el pedido.
*/


/* 7 de septiembre.
******IMPORTANTE 1 *******
Se agregaron mesas con su descripcion por ejemplo 'Mesa para 4'
Estas tienen una relacion de una a muchas con EstadoMesas, lo que significa que la mesa puede estar 
cliente esperando pedido
cliente comiendo
cliente pagando
cerrada
Para nuestra logica y para no generar otro campo más como podria ser: Mesa 'Libre', vamos a tomar que cuando creamos
una Mesa nos cree el campo
EstadoMesaId = 4

*****IMPORTANTE 2 *******
Modificamos la tabla para que por default sea 4 (cerrada)
La idea es que cuando se cree una nueva comanda , se supone que esa mesa esta libre (cerrada)
entonces pase al estado 1 (cliente esperando pedido)
Dentro de la creacion de comanda no tenemos el campo EstadoMesa, pero cuando se ejecute la una nueva comanda deberia ejecutarse una 
logica que nos modifique esa mesa o haga un Update en la tabla Mesas en el campo EstadoMesaId = 1 ("cliente esperando pedido") 
*/

 SELECT * FROM Comandas WHERE Id = 1;

 INSERT INTO [dbo].[Comandas] (MesaId, nombreCliente, codigoComanda) 
VALUES 
(1, 'test', 'test'),
(1, 'Juan Perez', 'C001'),
(2, 'Maria Lopez', 'C002'),
(3, 'Carlos Garcia', 'C003'),
(1, 'Ana Torres', 'C004');


use test1

DELETE FROM [dbo].[Pedidos];

select * from Pedidos;
SELECT * FROM Pedidos WHERE CodigoPedido IS NULL;

ALTER TABLE [dbo].[Pedidos] ADD [CodigoPedido] NVARCHAR(5) NULL;

ALTER TABLE Pedidos ADD EmpleadoModificadorId INT  NULL;

select * from Productos