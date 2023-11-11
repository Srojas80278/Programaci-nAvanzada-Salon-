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

-- Procedimiento almacenado para iniciar sesión
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