use proyectoDB;

DROP PROCEDURE INSERTAR_REQUERIMIENTO
DROP PROCEDURE MODIFICAR_REQUERIMIENTO
DROP PROCEDURE ELIMINAR_REQUERIMIENTO
DROP PROCEDURE CONSULTAR_REQUERIMIENTO
DROP PROCEDURE CONSULTAR_REQUERIMIENTOS_DISPONIBLES
DROP PROCEDURE ASOCIAR_REQUERIMIENTO

GO
CREATE PROCEDURE INSERTAR_REQUERIMIENTO
	@id_requerimiento int, @nombre varchar(64), @criterio_aceptacion varchar(256)
AS
	INSERT INTO Requerimientos
		(nombre, criterio_aceptacion)
	VALUES
		(@nombre, @criterio_aceptacion)
GO

GO
CREATE PROCEDURE MODIFICAR_REQUERIMIENTO
	@id_requerimiento int, @nombre varchar(64), @criterio_aceptacion varchar(256)
AS
	UPDATE Requerimientos
		SET nombre = @nombre,
			criterio_aceptacion = @criterio_aceptacion
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
	SELECT Requerimientos.nombre,
		   Requerimientos.criterio_aceptacion
	FROM Requerimientos
	WHERE @id_requerimiento = id_requerimiento
GO

GO
CREATE PROCEDURE CONSULTAR_REQUERIMIENTOS_DISPONIBLES
AS BEGIN
	SELECT Requerimientos.id_requerimiento,
			Requerimientos.nombre,
			Requerimientos.criterio_aceptacion
	FROM Requerimientos
	END
GO

GO
CREATE PROCEDURE ASOCIAR_REQUERIMIENTO
	@id_diseno int, @id_requerimiento int, @proposito varchar(128), @procedimiento varchar(512)
AS
	INSERT INTO SePrueba
		(id_diseno, id_requerimiento, proposito, procedimiento)
	VALUES
		(@id_diseno, @id_requerimiento, @proposito, @procedimiento)
GO