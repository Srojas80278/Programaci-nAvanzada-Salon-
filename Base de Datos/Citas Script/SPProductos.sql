/*TABLA PRODUCTOS */
USE [salonbellezaMN]
GO

/****** Object:  Table [dbo].[productos]    Script Date: 11/10/2023 12:42:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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


-- PROCEDIMIENTO ALMACENADO DE Producto: Actualizar Producto
CREATE PROCEDURE [dbo].[ActualizarProductoSP]
		@Nombre				varchar(250),
		@Descripcion					varchar(500),
		@Cantidad					int,
		@Precio			decimal(18, 2),
		@Imagen				varchar(250),
		@ConProducto int
AS
BEGIN
		
UPDATE dbo.citas
   SET Nombre =				@Nombre,
       Descripcion =					@Descripcion,
       Cantidad =					@Cantidad, 
       Precio =		    @Precio,
       servicio =			    @servicio,
       Imagen =   @Imagen

	   where ConProducto =			@ConProducto
END
GO