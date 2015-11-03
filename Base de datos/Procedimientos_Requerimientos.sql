use proyectoDB;

DROP PROCEDURE INSERTAR_REQUERIMIENTO
DROP PROCEDURE MODIFICAR_REQUERIMIENTO
DROP PROCEDURE ELIMINAR_REQUERIMIENTO
DROP PROCEDURE CONSULTAR_REQUERIMIENTO
DROP PROCEDURE CONSULTAR_REQUERIMIENTOS_DISPONIBLES

GO
CREATE PROCEDURE INSERTAR_REQUERIMIENTO
	@id_requerimiento int, @nombre varchar(64)
AS
	INSERT INTO Requerimientos
		(nombre)
	VALUES
		(@nombre)
GO

GO
CREATE PROCEDURE MODIFICAR_REQUERIMIENTO
	@id_requerimiento int, @nombre varchar(64)
AS
	UPDATE Requerimientos
		SET nombre = @nombre
		WHERE id_requerimiento = @id_requerimiento
GO

GO
CREATE PROCEDURE ELIMINAR_REQUERIMIENTO
	@id_requerimiento int
AS
	DELETE FROM Requerimientos
	WHERE @id_requerimiento = id_requerimiento
GO

GO
CREATE PROCEDURE CONSULTAR_REQUERIMIENTO
	@id_requerimiento int
AS
	SELECT Requerimientos.nombre
	FROM Requerimientos
	WHERE Requerimientos.id_requerimiento = id_requerimiento
GO

GO
CREATE PROCEDURE CONSULTAR_REQUERIMIENTOS_DISPONIBLES
AS BEGIN
	SELECT Requerimientos.id_requerimiento,
			Requerimientos.nombre
	FROM Requerimientos
	END
GO