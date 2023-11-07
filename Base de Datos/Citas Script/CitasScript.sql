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



