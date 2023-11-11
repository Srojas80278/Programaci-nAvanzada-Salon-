CREATE DATABASE salon;

use salon;

-- Crear la tabla productos
CREATE TABLE [dbo].[productos](
	[ConProducto] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Imagen] [varchar](250) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_TProducto] PRIMARY KEY CLUSTERED 
(
	[ConProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Crear la tabla roles
CREATE TABLE roles (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

-- Crear la tabla user
CREATE TABLE users (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(50) NOT NULL,
    password VARCHAR(100) NOT NULL,
    role_id BIGINT NOT NULL,
    FOREIGN KEY (role_id) REFERENCES roles(id)
);


-- Crear la tabla citas
CREATE TABLE citas (
    id_cita INT IDENTITY(1,1) PRIMARY KEY,
    estilista VARCHAR(100) NOT NULL,
    fecha DATE NOT NULL,
    sede VARCHAR(50) NOT NULL,
    nombre_cliente VARCHAR(100) NOT NULL,
    servicio VARCHAR(30) NOT NULL,
    descripcion_servicio VARCHAR(200) NOT NULL
);

-- Crear la tabla carrito
CREATE TABLE carrito (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id BIGINT NOT NULL,
    id_producto BIGINT NOT NULL,
    cantidad INT NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    subtotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (id_producto) REFERENCES productos(ConProducto)
);

--SP
-- Procedimiento almacenado para actualizar una cuenta
--CREATE PROCEDURE [dbo].[ActualizarCuentaSP]
--	@id BIGINT,
--	@name VARCHAR(100),
--	@email VARCHAR(50),
--	@password VARCHAR(100),
--	@role_id BIGINT
--AS
--BEGIN
--	UPDATE dbo.users
--	SET name = @name,
--		email = @email,
--		password = @password,
--		role_id = @role_id
--	WHERE id = @id
--END
--GO

-- Procedimiento almacenado de Autenticacion
GO
CREATE PROCEDURE [dbo].[IniciarSesionSP]
	@email varchar(100),
    @password varchar(100)
AS
BEGIN
	SELECT id,
		name,
		email,
		password,
		role_id
	FROM dbo.users
	WHERE email = @email
	AND password = @password
END
GO

CREATE PROCEDURE [dbo].[RecuperarCuentaSP]
	@email varchar(50)
AS
BEGIN
	
	SELECT name,
		   email,
		   password
	  FROM dbo.users
	  WHERE email = @email

END
GO

CREATE PROCEDURE [dbo].[RegistrarCuentaSP]
	@name VARCHAR(100),
    @email VARCHAR(50),
    @password VARCHAR(100),
    @role_id BIGINT
AS
BEGIN
	INSERT INTO dbo.users (name, email, password, role_id)
    VALUES (@name, @email, @password, @role_id)
END
GO

/*PROCEDIMIENTOS ALMACENADOS DE CITAS: ConsultarCitas */
CREATE PROCEDURE [dbo].[ConsultarCitaSP]
AS
BEGIN
SELECT [id_cita]
      ,[estilista]
      ,[fecha]
      ,[sede]
      ,[nombre_cliente]
      ,[servicio]
      ,[descripcion_servicio]
  FROM [dbo].[citas]
END
GO

/*PROCEDIMIENTOS ALMACENADOS DE CITAS: RegistrarCitas */
CREATE PROCEDURE [dbo].[RegistrarCitaSP]
    @estilista VARCHAR(100),
    @fecha DATETIME,
    @sede VARCHAR(50),
    @nombre_cliente VARCHAR(100),
    @servicio VARCHAR(30),
    @descripcion_servicio VARCHAR(200)
AS
BEGIN
    INSERT INTO Citas (estilista, fecha, sede, nombre_cliente, servicio, descripcion_servicio)
    VALUES (@estilista, @fecha, @sede, @nombre_cliente, @servicio, @descripcion_servicio)
END
GO

/*PROCEDIMIENTOS ALMACENADOS DE CITAS: ActualizarCitas */
CREATE PROCEDURE [dbo].[ActualizarCitaSP]
		@estilista				varchar(100),
		@fecha					datetime,
		@sede					varchar(50),
		@nombre_cliente			varchar(100),
		@servicio				varchar(30),
		@descripcion_servicio	varchar(200),
		@id_cita int
AS
BEGIN
		
UPDATE dbo.citas
   SET estilista =				@estilista,
       fecha =					@fecha,
       sede =					@sede, 
       nombre_cliente =		    @nombre_cliente,
       servicio =			    @servicio,
       descripcion_servicio =   @descripcion_servicio

	   where id_cita =			@id_cita
END
GO

/*PROCEDIMIENTOS ALMACENADOS DE Producto: ConsultarProducto */
CREATE PROCEDURE [dbo].[ConsultarProductoSP]
AS
BEGIN
SELECT [ConProducto]
      ,[Nombre]
      ,[Descripcion]
      ,[Cantidad]
      ,[Precio]
      ,[Imagen]
      ,[Estado]
  FROM [dbo].[productos]
END
GO

/*PROCEDIMIENTOS ALMACENADOS DE Producto: RegistrarProducto */
CREATE PROCEDURE [dbo].[RegistrarProductoSP]
    @Nombre VARCHAR(250),
    @Descripcion VARCHAR (500),
    @Cantidad int,
    @Precio decimal (18, 2),
    @Imagen VARCHAR(250),
    @Estado bit
AS
BEGIN
    INSERT INTO productos (Nombre, Descripcion, Cantidad, Precio, Imagen, Estado)
    VALUES (@Nombre, @Descripcion, @Cantidad, @Precio, @Imagen, @Estado)
END
GO
-- PROCEDIMIENTO ALMACENADO DE Producto: EliminarProductoSP
CREATE PROCEDURE [dbo].[EliminarProductoSP]
    @ConProducto INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[productos]
    WHERE [ConProducto] = @ConProducto;
END
GO


----//> salonEntities
INSERT INTO dbo.roles (name)
VALUES ('admin');

INSERT INTO dbo.roles (name)
VALUES ('usuario');

select * from users;
select * from roles;
select * from productos;
select * from citas;

UPDATE [dbo].[users]
   SET [role_id] = 1
 WHERE id=1
GO

