use proyectoDB;


DROP PROCEDURE INSERTAR_RH
DROP PROCEDURE MODIFICAR_RH
DROP PROCEDURE ELIMINAR_RH
DROP PROCEDURE CONSULTAR_RH
DROP PROCEDURE CONSULTAR_RECURSOS_DISPONIBLES
DROP PROCEDURE CONSULTAR_CONTRASENA



GO
CREATE PROCEDURE INSERTAR_RH
	@username varchar(64), @cedula varchar(16), @id_proyecto int, @telefono varchar(16), @nombre varchar(64), @hashed varchar(256), @correo varchar(64), @rol varchar(64), @admin bit
AS
	INSERT INTO RecursosHumanos
		(username, cedula, id_proyecto, telefono, nombre, contrasena, correo, rol, es_administrador)
	VALUES
		(@username, @cedula, @id_proyecto, @telefono, @nombre, @hashed, @correo, @rol, @admin)
GO


GO
CREATE PROCEDURE MODIFICAR_RH
	@username varchar(64), @cedula varchar(16), @id_proyecto int, @telefono varchar(16), @nombre varchar(64), @hashed varchar(256), @correo varchar(64), @rol varchar(64), @admin bit
AS
	UPDATE RecursosHumanos
		SET cedula = @cedula, id_proyecto = @id_proyecto, telefono = @telefono, nombre = @nombre, contrasena = @hashed, correo = @correo, rol = @rol, es_administrador = @admin
		WHERE username = @username
GO


GO
CREATE PROCEDURE ELIMINAR_RH
	@username varchar(64)
AS
	DELETE FROM RecursosHumanos
	WHERE username = @username
GO



GO
CREATE PROCEDURE CONSULTAR_RH
	@username varchar(64)
AS
	SELECT	RecursosHumanos.cedula,
			RecursosHumanos.id_proyecto,
			RecursosHumanos.telefono,
			RecursosHumanos.nombre,
			RecursosHumanos.correo,
			RecursosHumanos.rol,
			RecursosHumanos.es_administrador
	FROM	RecursosHumanos
	WHERE	RecursosHumanos.username = @username
GO

GO
CREATE PROCEDURE CONSULTAR_RECURSOS_DISPONIBLES
	AS BEGIN
	SELECT	RecursosHumanos.nombre,
			RecursosHumanos.username
	FROM	RecursosHumanos
	END
GO


GO
CREATE PROCEDURE CONSULTAR_CONTRASENA
	@username varchar(64)
AS BEGIN
	SELECT contrasena
	FROM RecursosHumanos
	WHERE username = @username
   END
GO

GO
CREATE PROCEDURE CAMBIAR_CONTRASENA
	@username varchar(64), @nueva_contrasena varchar(64)
	AS
		UPDATE RecursosHumanos
			SET contrasena = @nueva_contrasena
			WHERE username = @username
GO
