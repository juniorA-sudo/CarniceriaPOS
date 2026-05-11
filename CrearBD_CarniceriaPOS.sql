-- =========================================================================
-- PROYECTO FINAL COMPLETO: Sistema de Carniceria POS
-- BASE DE DATOS: CarniceriaPOS
-- INCLUYE: Creacion de BD, Tablas y Poblacion de Datos Reales (10 por tabla)
-- =========================================================================

USE master;
GO

-- 1. BORRAR LA BASE DE DATOS SI YA EXISTE PARA EMPEZAR LIMPIO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'CarniceriaPOS')
BEGIN
    ALTER DATABASE CarniceriaPOS SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CarniceriaPOS;
END
GO

-- 2. CREAR LA BASE DE DATOS
CREATE DATABASE CarniceriaPOS;
GO

USE CarniceriaPOS;
GO

-- =========================================================================
-- 3. CREACION DE ESTRUCTURA DE TABLAS (DDL)
-- =========================================================================

CREATE TABLE Roles (
    IdRol INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(255)
);

CREATE TABLE Departamentos (
    IdDepartamento INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255)
);

CREATE TABLE UnidadesMedida (
    IdUnidadMedida INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Abreviatura NVARCHAR(10) NOT NULL
);

CREATE TABLE Empleados (
    IdEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Cedula NVARCHAR(13) UNIQUE NOT NULL,
    Telefono NVARCHAR(20),
    IdDepartamento INT FOREIGN KEY REFERENCES Departamentos(IdDepartamento),
    Puesto NVARCHAR(50),
    Salario DECIMAL(18,2),
    Activo BIT DEFAULT 1
);

CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT FOREIGN KEY REFERENCES Empleados(IdEmpleado),
    NombreUsuario NVARCHAR(50) UNIQUE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    IdRol INT FOREIGN KEY REFERENCES Roles(IdRol),
    Activo BIT DEFAULT 1
);

CREATE TABLE Proveedores (
    IdProveedor INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    RNC NVARCHAR(20) UNIQUE,
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    Activo BIT DEFAULT 1
);

CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Cedula NVARCHAR(13),
    RNC NVARCHAR(20),
    Telefono NVARCHAR(20),
    Activo BIT DEFAULT 1
);

CREATE TABLE Productos (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    CodigoBarras NVARCHAR(50) UNIQUE,
    Nombre NVARCHAR(150) NOT NULL,
    Categoria NVARCHAR(100),
    IdUnidadMedida INT FOREIGN KEY REFERENCES UnidadesMedida(IdUnidadMedida),
    PrecioCompra DECIMAL(18,2) NOT NULL,
    PrecioVenta DECIMAL(18,2) NOT NULL,
    StockActual DECIMAL(18,2) NOT NULL DEFAULT 0,
    AplicaITBIS BIT DEFAULT 0,
    Activo BIT DEFAULT 1
);

CREATE TABLE Ventas (
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
    NumeroFactura NVARCHAR(50) UNIQUE NOT NULL,
    IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente),
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
    FechaVenta DATETIME DEFAULT GETDATE(),
    MetodoPago NVARCHAR(50) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    TotalITBIS DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    MontoRecibido DECIMAL(18,2),
    Cambio DECIMAL(18,2),
    Estado NVARCHAR(20) DEFAULT 'Completada'
);

CREATE TABLE DetalleVentas (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT FOREIGN KEY REFERENCES Ventas(IdVenta),
    IdProducto INT FOREIGN KEY REFERENCES Productos(IdProducto),
    Cantidad DECIMAL(18,2) NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL
);

CREATE TABLE Compras (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    NumeroFacturaProv NVARCHAR(50),
    IdProveedor INT FOREIGN KEY REFERENCES Proveedores(IdProveedor),
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
    FechaCompra DATETIME DEFAULT GETDATE(),
    Total DECIMAL(18,2) NOT NULL,
    Estado NVARCHAR(20) DEFAULT 'Recibida'
);

CREATE TABLE DetalleCompras (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdCompra INT FOREIGN KEY REFERENCES Compras(IdCompra),
    IdProducto INT FOREIGN KEY REFERENCES Productos(IdProducto),
    Cantidad DECIMAL(18,2) NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL
);

CREATE TABLE AuditoriaAcceso (
    IdAuditoria INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
    Modulo NVARCHAR(100) NOT NULL,
    Accion NVARCHAR(50) NOT NULL,
    Resultado NVARCHAR(50) NOT NULL,
    FechaHora DATETIME DEFAULT GETDATE(),
    Detalles NVARCHAR(255)
);

GO -- Fin de la creacion de estructura. A partir de aqui, las tablas existen.

-- =========================================================================
-- 4. POBLACION DE DATOS (DML) - LOTE CONTINUO SIN 'GO' HASTA EL FINAL
-- =========================================================================

-- Declaracion de variables para el lote completo
DECLARE @Rol_Admin INT, @Rol_Cajero INT, @Rol_Supervisor INT;
DECLARE @Depto_Ventas INT, @Depto_Admin INT, @Depto_Produccion INT;
DECLARE @UOM_Lb INT, @UOM_Unid INT;
DECLARE @Emp_Carlos INT, @Emp_Ana INT;
DECLARE @Usuario_Carlos INT, @Usuario_Ana INT;
DECLARE @Prov_CarnesSur INT, @Prov_DistOriente INT;
DECLARE @Cliente_Juan INT, @Cliente_Maria INT;
DECLARE @Prod_Bistec INT, @Prod_Chorizo INT;
DECLARE @Venta1 INT, @Venta2 INT, @Venta3 INT, @Venta4 INT, @Venta5 INT, @Venta6 INT, @Venta7 INT, @Venta8 INT, @Venta9 INT, @Venta10 INT;
DECLARE @Compra1 INT, @Compra2 INT, @Compra3 INT, @Compra4 INT, @Compra5 INT, @Compra6 INT, @Compra7 INT, @Compra8 INT, @Compra9 INT, @Compra10 INT;

-- 4.1 CATALOGOS BASE
INSERT INTO Roles (Nombre, Descripcion) VALUES ('Administrador', 'Acceso total al sistema');
INSERT INTO Roles (Nombre, Descripcion) VALUES ('Cajero', 'Acceso limitado para ventas y punto de venta');
INSERT INTO Roles (Nombre, Descripcion) VALUES ('Supervisor', 'Acceso para ventas, reportes y supervision');
SELECT @Rol_Admin = 1, @Rol_Cajero = 2, @Rol_Supervisor = 3;

INSERT INTO Departamentos (Nombre, Descripcion) VALUES ('Administracion', 'Gestion central y oficinas');
INSERT INTO Departamentos (Nombre, Descripcion) VALUES ('Ventas', 'Area de atencion al publico y cajas');
INSERT INTO Departamentos (Nombre, Descripcion) VALUES ('Produccion', 'Corte, preparacion y empaque de carnes');
SELECT @Depto_Admin = 1, @Depto_Ventas = 2, @Depto_Produccion = 3;

INSERT INTO UnidadesMedida (Nombre, Abreviatura) VALUES ('Libras', 'Lb');
INSERT INTO UnidadesMedida (Nombre, Abreviatura) VALUES ('Unidades', 'Unid');
SELECT @UOM_Lb = 1, @UOM_Unid = 2;

-- 4.2 EMPLEADOS Y USUARIOS (10 cada uno)
INSERT INTO Empleados (Nombre, Cedula, Telefono, IdDepartamento, Puesto, Salario, Activo) VALUES ('Carlos Gomez', '001-1234567-8', '(809) 555-1111', @Depto_Admin, 'Administrador', 25000.00, 1);
INSERT INTO Empleados (Nombre, Cedula, Telefono, IdDepartamento, Puesto, Salario, Activo) VALUES ('Ana Martinez', '402-9876543-2', '(829) 555-2222', @Depto_Ventas, 'Cajera', 18000.00, 1);
INSERT INTO Empleados (Nombre, Cedula, Telefono, IdDepartamento, Puesto, Salario, Activo) VALUES ('Luis Rodriguez', '047-5555555-5', '(809) 555-3333', @Depto_Ventas, 'Cajero', 18000.00, 1);
INSERT INTO Empleados (Nombre, Cedula, Telefono, IdDepartamento, Puesto, Salario, Activo) VALUES ('Pedro Sanchez', '101-1234567-8', '(849) 555-4444', @Depto_Produccion, 'Carnicero Principal', 22000.00, 1);
INSERT INTO Empleados (Nombre, Cedula, Telefono, IdDepartamento, Puesto, Salario, Activo) VALUES ('Maria Vargas', '002-1234567-8', '(809) 555-5555', @Depto_Ventas, 'Supervisora de Caja', 20000.00, 1);
INSERT INTO Empleados (Nombre, Cedula, Telefono, IdDepartamento, Puesto, Salario, Activo) VALUES ('Jose Perez', '003-1234567-8', '(829) 555-6666', @Depto_Produccion, 'Despostador', 21000.00, 1);
INSERT INTO Empleados (Nombre, Cedula, Telefono, IdDepartamento, Puesto, Salario, Activo) VALUES ('Laura Diaz', '004-1234567-8', '(849) 555-7777', @Depto_Admin, 'Gerente', 30000.00, 1);
INSERT INTO Empleados (Nombre, Cedula, Telefono, IdDepartamento, Puesto, Salario, Activo) VALUES ('Andres Castro', '005-1234567-8', '(809) 555-8888', @Depto_Admin, 'Contador', 28000.00, 1);
INSERT INTO Empleados (Nombre, Cedula, Telefono, IdDepartamento, Puesto, Salario, Activo) VALUES ('Sofia Ramirez', '006-1234567-8', '(829) 555-9999', @Depto_Produccion, 'Carnicero de Salon', 20000.00, 1);
INSERT INTO Empleados (Nombre, Cedula, Telefono, IdDepartamento, Puesto, Salario, Activo) VALUES ('Manuel Cruz', '007-1234567-8', '(849) 555-0000', @Depto_Ventas, 'Auxiliar Caja', 17000.00, 1);
SELECT @Emp_Carlos = 1, @Emp_Ana = 2;

INSERT INTO Usuarios (IdEmpleado, NombreUsuario, Email, PasswordHash, IdRol, Activo) VALUES (@Emp_Carlos, 'carlos.admin', 'admin@carniceria.com', 'admin123', @Rol_Admin, 1);
INSERT INTO Usuarios (IdEmpleado, NombreUsuario, Email, PasswordHash, IdRol, Activo) VALUES (@Emp_Ana, 'ana.cajera', 'ana@carniceria.com', 'ana123', @Rol_Cajero, 1);
INSERT INTO Usuarios (IdEmpleado, NombreUsuario, Email, PasswordHash, IdRol, Activo) VALUES (3, 'luis.cajero', 'luis@carniceria.com', 'luis123', @Rol_Cajero, 1);
INSERT INTO Usuarios (IdEmpleado, NombreUsuario, Email, PasswordHash, IdRol, Activo) VALUES (5, 'maria.supervisor', 'maria@carniceria.com', 'maria123', @Rol_Supervisor, 1);
INSERT INTO Usuarios (IdEmpleado, NombreUsuario, Email, PasswordHash, IdRol, Activo) VALUES (7, 'laura.gerente', 'laura@carniceria.com', 'laura123', @Rol_Admin, 1);
INSERT INTO Usuarios (IdEmpleado, NombreUsuario, Email, PasswordHash, IdRol, Activo) VALUES (8, 'andres.contador', 'andres@carniceria.com', 'andres123', @Rol_Admin, 1);
INSERT INTO Usuarios (IdEmpleado, NombreUsuario, Email, PasswordHash, IdRol, Activo) VALUES (10, 'manuel.auxiliar', 'manuel@carniceria.com', 'manuel123', @Rol_Cajero, 1);
INSERT INTO Usuarios (IdEmpleado, NombreUsuario, Email, PasswordHash, IdRol, Activo) VALUES (4, 'pedro.carnicero', 'pedro@carniceria.com', 'pedro123', @Rol_Supervisor, 1);
INSERT INTO Usuarios (IdEmpleado, NombreUsuario, Email, PasswordHash, IdRol, Activo) VALUES (6, 'jose.despostador', 'jose@carniceria.com', 'jose123', @Rol_Supervisor, 1);
INSERT INTO Usuarios (IdEmpleado, NombreUsuario, Email, PasswordHash, IdRol, Activo) VALUES (9, 'sofia.carnicero', 'sofia@carniceria.com', 'sofia123', @Rol_Supervisor, 1);
SELECT @Usuario_Carlos = 1, @Usuario_Ana = 2;

-- 4.3 PROVEEDORES Y CLIENTES (10 cada uno)
INSERT INTO Proveedores (Nombre, RNC, Telefono, Email, Activo) VALUES ('Carnes del Sur, SRL', '1-01-23456-7', '(809) 555-7777', 'ventas@carnesdelsur.do', 1);
INSERT INTO Proveedores (Nombre, RNC, Telefono, Email, Activo) VALUES ('Distribuidora Oriental, SRL', '1-01-23456-8', '(829) 555-8888', 'contacto@distribuidoraoriental.com', 1);
INSERT INTO Proveedores (Nombre, RNC, Telefono, Email, Activo) VALUES ('Suplidora Carnica Dom', '1-01-23456-9', '(849) 555-9999', 'info@suplidoracarnica.do', 1);
INSERT INTO Proveedores (Nombre, RNC, Telefono, Email, Activo) VALUES ('Industrias El Cibao, SRL', '1-01-23456-0', '(809) 555-0000', 'gerencia@elcibao.com', 1);
INSERT INTO Proveedores (Nombre, RNC, Telefono, Email, Activo) VALUES ('Premium del Este, SRL', '1-02-23456-1', '(829) 555-1111', 'compras@premiumdeleste.do', 1);
INSERT INTO Proveedores (Nombre, RNC, Telefono, Email, Activo) VALUES ('Suplidora La Granja', '1-02-23456-2', '(849) 555-2222', 'admin@lagranja.com', 1);
INSERT INTO Proveedores (Nombre, RNC, Telefono, Email, Activo) VALUES ('Aves de Corral, SRL', '1-02-23456-3', '(809) 555-3333', 'ventas@avesdecorral.do', 1);
INSERT INTO Proveedores (Nombre, RNC, Telefono, Email, Activo) VALUES ('Sazones del Caribe', '1-02-23456-4', '(829) 555-4444', 'pedidos@sazonescaribe.do', 1);
INSERT INTO Proveedores (Nombre, RNC, Telefono, Email, Activo) VALUES ('Empaques y Plasticos', '1-02-23456-5', '(849) 555-5555', 'servicio@empaques.com', 1);
INSERT INTO Proveedores (Nombre, RNC, Telefono, Email, Activo) VALUES ('Mant. de Equipos SRL', '1-02-23456-6', '(809) 555-6666', 'soporte@equipos.do', 1);
SELECT @Prov_CarnesSur = 1, @Prov_DistOriente = 2;

INSERT INTO Clientes (Nombre, Cedula, RNC, Telefono, Activo) VALUES ('Juan Perez', '001-1234567-8', NULL, '(809) 555-1212', 1);
INSERT INTO Clientes (Nombre, Cedula, RNC, Telefono, Activo) VALUES ('Maria Rodriguez', '402-9876543-2', '1-01-23456-7', '(809) 555-3434', 1);
INSERT INTO Clientes (Nombre, Cedula, RNC, Telefono, Activo) VALUES ('Consumidor Final', NULL, NULL, NULL, 1);
INSERT INTO Clientes (Nombre, Cedula, RNC, Telefono, Activo) VALUES ('Distribuidora Gonzalez', NULL, '1-30-45678-9', '(849) 555-5656', 1);
INSERT INTO Clientes (Nombre, Cedula, RNC, Telefono, Activo) VALUES ('Carlos Marte', '047-5555555-5', NULL, '(809) 555-7878', 1);
INSERT INTO Clientes (Nombre, Cedula, RNC, Telefono, Activo) VALUES ('Luis Ramirez', '002-1234567-8', NULL, '(829) 555-8989', 1);
INSERT INTO Clientes (Nombre, Cedula, RNC, Telefono, Activo) VALUES ('Sofia Castro', '010-1234567-8', NULL, '(829) 555-9999', 1);
INSERT INTO Clientes (Nombre, Cedula, RNC, Telefono, Activo) VALUES ('Manuel Diaz', '011-1234567-8', NULL, '(849) 555-0000', 1);
INSERT INTO Clientes (Nombre, Cedula, RNC, Telefono, Activo) VALUES ('Elena Rojas', '012-1234567-8', NULL, '(829) 555-1122', 1);
INSERT INTO Clientes (Nombre, Cedula, RNC, Telefono, Activo) VALUES ('Roberto Pena', '013-1234567-8', NULL, '(849) 555-3344', 1);
SELECT @Cliente_Juan = 1, @Cliente_Maria = 2;

-- 4.4 PRODUCTOS (10 registros)
INSERT INTO Productos (CodigoBarras, Nombre, Categoria, IdUnidadMedida, PrecioCompra, PrecioVenta, StockActual, AplicaITBIS, Activo) VALUES ('P-001', 'Bistec de Res Selecto', 'Res', @UOM_Lb, 550.00, 650.00, 50.00, 0, 1);
INSERT INTO Productos (CodigoBarras, Nombre, Categoria, IdUnidadMedida, PrecioCompra, PrecioVenta, StockActual, AplicaITBIS, Activo) VALUES ('P-002', 'Costillas de Cerdo', 'Cerdo', @UOM_Lb, 420.00, 520.00, 30.00, 0, 1);
INSERT INTO Productos (CodigoBarras, Nombre, Categoria, IdUnidadMedida, PrecioCompra, PrecioVenta, StockActual, AplicaITBIS, Activo) VALUES ('P-003', 'Pollo Entero', 'Aves', @UOM_Lb, 180.00, 230.00, 100.00, 0, 1);
INSERT INTO Productos (CodigoBarras, Nombre, Categoria, IdUnidadMedida, PrecioCompra, PrecioVenta, StockActual, AplicaITBIS, Activo) VALUES ('P-004', 'Salami Ranchero (1lb)', 'Embutidos', @UOM_Unid, 200.00, 250.00, 20.00, 1, 1);
INSERT INTO Productos (CodigoBarras, Nombre, Categoria, IdUnidadMedida, PrecioCompra, PrecioVenta, StockActual, AplicaITBIS, Activo) VALUES ('P-005', 'Longaniza Casera', 'Embutidos', @UOM_Lb, 450.00, 550.00, 15.00, 1, 1);
INSERT INTO Productos (CodigoBarras, Nombre, Categoria, IdUnidadMedida, PrecioCompra, PrecioVenta, StockActual, AplicaITBIS, Activo) VALUES ('P-006', 'Chuleta Ahumada', 'Cerdo', @UOM_Lb, 400.00, 500.00, 25.00, 0, 1);
INSERT INTO Productos (CodigoBarras, Nombre, Categoria, IdUnidadMedida, PrecioCompra, PrecioVenta, StockActual, AplicaITBIS, Activo) VALUES ('P-007', 'Carne Molida de Res', 'Res', @UOM_Lb, 500.00, 600.00, 40.00, 0, 1);
INSERT INTO Productos (CodigoBarras, Nombre, Categoria, IdUnidadMedida, PrecioCompra, PrecioVenta, StockActual, AplicaITBIS, Activo) VALUES ('P-008', 'Pechuga de Pollo Desosada', 'Aves', @UOM_Lb, 320.00, 380.00, 60.00, 0, 1);
INSERT INTO Productos (CodigoBarras, Nombre, Categoria, IdUnidadMedida, PrecioCompra, PrecioVenta, StockActual, AplicaITBIS, Activo) VALUES ('P-009', 'Sazoncito Ranchero (sobre)', 'Sazon', @UOM_Unid, 20.00, 30.00, 200.00, 1, 1);
INSERT INTO Productos (CodigoBarras, Nombre, Categoria, IdUnidadMedida, PrecioCompra, PrecioVenta, StockActual, AplicaITBIS, Activo) VALUES ('P-010', 'Bolsas Plasticas Grand.', 'Empaque', @UOM_Unid, 5.00, 10.00, 500.00, 1, 1);
SELECT @Prod_Bistec = 1, @Prod_Chorizo = 5;

-- 4.5 VENTAS Y DETALLES DE VENTAS (10 cada uno, exactamente 1 a 1)
INSERT INTO Ventas (NumeroFactura, IdCliente, IdUsuario, FechaVenta, MetodoPago, Subtotal, TotalITBIS, Total, MontoRecibido, Cambio) VALUES ('V-10045', @Cliente_Juan, @Usuario_Ana, GETDATE(), 'Efectivo', 1625.00, 0.00, 1625.00, 2000.00, 375.00); SELECT @Venta1 = SCOPE_IDENTITY();
INSERT INTO Ventas (NumeroFactura, IdCliente, IdUsuario, FechaVenta, MetodoPago, Subtotal, TotalITBIS, Total, MontoRecibido, Cambio) VALUES ('V-10046', @Cliente_Maria, @Usuario_Ana, GETDATE(), 'Tarjeta', 550.00, 99.00, 649.00, 649.00, 0.00); SELECT @Venta2 = SCOPE_IDENTITY();
INSERT INTO Ventas (NumeroFactura, IdCliente, IdUsuario, FechaVenta, MetodoPago, Subtotal, TotalITBIS, Total, MontoRecibido, Cambio) VALUES ('V-10047', 3, @Usuario_Ana, GETDATE(), 'Efectivo', 230.00, 0.00, 230.00, 300.00, 70.00); SELECT @Venta3 = SCOPE_IDENTITY();
INSERT INTO Ventas (NumeroFactura, IdCliente, IdUsuario, FechaVenta, MetodoPago, Subtotal, TotalITBIS, Total, MontoRecibido, Cambio) VALUES ('V-10048', 3, @Usuario_Ana, GETDATE(), 'Tarjeta', 520.00, 0.00, 520.00, 520.00, 0.00); SELECT @Venta4 = SCOPE_IDENTITY();
INSERT INTO Ventas (NumeroFactura, IdCliente, IdUsuario, FechaVenta, MetodoPago, Subtotal, TotalITBIS, Total, MontoRecibido, Cambio) VALUES ('V-10049', 3, @Usuario_Ana, GETDATE(), 'Efectivo', 1300.00, 0.00, 1300.00, 1500.00, 200.00); SELECT @Venta5 = SCOPE_IDENTITY();
INSERT INTO Ventas (NumeroFactura, IdCliente, IdUsuario, FechaVenta, MetodoPago, Subtotal, TotalITBIS, Total, MontoRecibido, Cambio) VALUES ('V-10050', 3, @Usuario_Ana, GETDATE(), 'Efectivo', 460.00, 0.00, 460.00, 500.00, 40.00); SELECT @Venta6 = SCOPE_IDENTITY();
INSERT INTO Ventas (NumeroFactura, IdCliente, IdUsuario, FechaVenta, MetodoPago, Subtotal, TotalITBIS, Total, MontoRecibido, Cambio) VALUES ('V-10051', 3, @Usuario_Ana, GETDATE(), 'Efectivo', 250.00, 45.00, 295.00, 300.00, 5.00); SELECT @Venta7 = SCOPE_IDENTITY();
INSERT INTO Ventas (NumeroFactura, IdCliente, IdUsuario, FechaVenta, MetodoPago, Subtotal, TotalITBIS, Total, MontoRecibido, Cambio) VALUES ('V-10052', 3, @Usuario_Ana, GETDATE(), 'Tarjeta', 650.00, 0.00, 650.00, 650.00, 0.00); SELECT @Venta8 = SCOPE_IDENTITY();
INSERT INTO Ventas (NumeroFactura, IdCliente, IdUsuario, FechaVenta, MetodoPago, Subtotal, TotalITBIS, Total, MontoRecibido, Cambio) VALUES ('V-10053', 3, @Usuario_Ana, GETDATE(), 'Efectivo', 600.00, 0.00, 600.00, 1000.00, 400.00); SELECT @Venta9 = SCOPE_IDENTITY();
INSERT INTO Ventas (NumeroFactura, IdCliente, IdUsuario, FechaVenta, MetodoPago, Subtotal, TotalITBIS, Total, MontoRecibido, Cambio) VALUES ('V-10054', 3, @Usuario_Ana, GETDATE(), 'Tarjeta', 760.00, 0.00, 760.00, 760.00, 0.00); SELECT @Venta10 = SCOPE_IDENTITY();

INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Venta1, 1, 2.50, 650.00, 1625.00); -- Bistec
INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Venta2, 5, 1.00, 550.00, 550.00); -- Chorizo
INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Venta3, 3, 1.00, 230.00, 230.00); -- Pollo
INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Venta4, 2, 1.00, 520.00, 520.00); -- Costillas
INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Venta5, 1, 2.00, 650.00, 1300.00); -- Bistec
INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Venta6, 3, 2.00, 230.00, 460.00); -- Pollo
INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Venta7, 4, 1.00, 250.00, 250.00); -- Salami
INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Venta8, 1, 1.00, 650.00, 650.00); -- Bistec
INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Venta9, 7, 1.00, 600.00, 600.00); -- Carne Molida
INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Venta10, 8, 2.00, 380.00, 760.00); -- Pechuga

-- 4.6 COMPRAS Y DETALLES DE COMPRAS (10 cada uno, exactamente 1 a 1)
INSERT INTO Compras (NumeroFacturaProv, IdProveedor, IdUsuario, FechaCompra, Total) VALUES ('FAC-9901', @Prov_CarnesSur, @Usuario_Carlos, GETDATE(), 11000.00); SELECT @Compra1 = SCOPE_IDENTITY();
INSERT INTO Compras (NumeroFacturaProv, IdProveedor, IdUsuario, FechaCompra, Total) VALUES ('FAC-1102', @Prov_DistOriente, @Usuario_Carlos, GETDATE(), 4500.00); SELECT @Compra2 = SCOPE_IDENTITY();
INSERT INTO Compras (NumeroFacturaProv, IdProveedor, IdUsuario, FechaCompra, Total) VALUES ('FAC-2203', 3, @Usuario_Carlos, GETDATE(), 15000.00); SELECT @Compra3 = SCOPE_IDENTITY();
INSERT INTO Compras (NumeroFacturaProv, IdProveedor, IdUsuario, FechaCompra, Total) VALUES ('FAC-3304', 4, @Usuario_Carlos, GETDATE(), 5000.00); SELECT @Compra4 = SCOPE_IDENTITY();
INSERT INTO Compras (NumeroFacturaProv, IdProveedor, IdUsuario, FechaCompra, Total) VALUES ('FAC-4405', 5, @Usuario_Carlos, GETDATE(), 20000.00); SELECT @Compra5 = SCOPE_IDENTITY();
INSERT INTO Compras (NumeroFacturaProv, IdProveedor, IdUsuario, FechaCompra, Total) VALUES ('FAC-5506', 6, @Usuario_Carlos, GETDATE(), 7500.00); SELECT @Compra6 = SCOPE_IDENTITY();
INSERT INTO Compras (NumeroFacturaProv, IdProveedor, IdUsuario, FechaCompra, Total) VALUES ('FAC-6607', 7, @Usuario_Carlos, GETDATE(), 12000.00); SELECT @Compra7 = SCOPE_IDENTITY();
INSERT INTO Compras (NumeroFacturaProv, IdProveedor, IdUsuario, FechaCompra, Total) VALUES ('FAC-7708', 8, @Usuario_Carlos, GETDATE(), 2500.00); SELECT @Compra8 = SCOPE_IDENTITY();
INSERT INTO Compras (NumeroFacturaProv, IdProveedor, IdUsuario, FechaCompra, Total) VALUES ('FAC-8809', 9, @Usuario_Carlos, GETDATE(), 3000.00); SELECT @Compra9 = SCOPE_IDENTITY();
INSERT INTO Compras (NumeroFacturaProv, IdProveedor, IdUsuario, FechaCompra, Total) VALUES ('FAC-9910', 10, @Usuario_Carlos, GETDATE(), 6000.00); SELECT @Compra10 = SCOPE_IDENTITY();

INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Compra1, 1, 20.00, 550.00, 11000.00); -- Bistec
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Compra2, 5, 10.00, 450.00, 4500.00); -- Chorizo
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Compra3, 1, 27.27, 550.00, 15000.00); -- Bistec
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Compra4, 2, 11.90, 420.00, 5000.00); -- Costillas
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Compra5, 1, 36.36, 550.00, 20000.00); -- Bistec
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Compra6, 3, 41.66, 180.00, 7500.00); -- Pollo
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Compra7, 8, 37.50, 320.00, 12000.00); -- Pechuga
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Compra8, 9, 125.00, 20.00, 2500.00); -- Sazoncito
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Compra9, 10, 600.00, 5.00, 3000.00); -- Bolsas
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@Compra10, 2, 14.28, 420.00, 6000.00); -- Costillas

GO
-- =========================================================================
-- FIN DEL SCRIPT.
-- A continuacion, una consulta para comprobar que todas las tablas
-- tienen exactamente la cantidad de registros solicitada.
-- =========================================================================

SELECT 'Roles' AS Tabla, COUNT(*) AS TotalRegistros FROM Roles
UNION ALL SELECT 'Departamentos', COUNT(*) FROM Departamentos
UNION ALL SELECT 'UnidadesMedida', COUNT(*) FROM UnidadesMedida
UNION ALL SELECT 'Empleados', COUNT(*) FROM Empleados
UNION ALL SELECT 'Usuarios', COUNT(*) FROM Usuarios
UNION ALL SELECT 'Proveedores', COUNT(*) FROM Proveedores
UNION ALL SELECT 'Clientes', COUNT(*) FROM Clientes
UNION ALL SELECT 'Productos', COUNT(*) FROM Productos
UNION ALL SELECT 'Ventas', COUNT(*) FROM Ventas
UNION ALL SELECT 'DetalleVentas', COUNT(*) FROM DetalleVentas
UNION ALL SELECT 'Compras', COUNT(*) FROM Compras
UNION ALL SELECT 'DetalleCompras', COUNT(*) FROM DetalleCompras;


[FIN DEL ARCHIVO]


RESUMEN DE ARCHIVOS ENCONTRADOS

Total archivos encontrados: 11
  Ã¢Å“â€œ FrmLogin.cs
  Ã¢Å“â€œ FrmPrincipal.cs
  Ã¢Å“â€œ FrmProductos.cs
  Ã¢Å“â€œ FrmCaja.cs
  Ã¢Å“â€œ FrmReporteBase.cs
  Ã¢Å“â€œ FrmReporteBase.Designer.cs
  Ã¢Å“â€œ FrmReportes.cs
  Ã¢Å“â€œ FrmSelectorReportes.cs
  Ã¢Å“â€œ SesionActual.cs
  Ã¢Å“â€œ Validador.cs
  Ã¢Å“â€œ CrearBD_CarniceriaPOS.sql