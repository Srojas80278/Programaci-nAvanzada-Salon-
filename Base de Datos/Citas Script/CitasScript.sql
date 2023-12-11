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


--Consultar una cita en especifica para jalar los datos y actualizarlos:
CREATE PROCEDURE ConsultarUnaCita
	@id_cita int
AS
BEGIN
	 SELECT
	  id_cita,
      estilista,
      fecha,
      sede,
      nombre_cliente,
      servicio,
      descripcion_servicio
  FROM citas Where id_cita = @id_cita
END
GO


-- Borrar un registro:

CREATE PROCEDURE BorrarCita_SP
	@id_cita int
AS
BEGIN
DELETE FROM citas Where id_cita = @id_cita
END
GO






