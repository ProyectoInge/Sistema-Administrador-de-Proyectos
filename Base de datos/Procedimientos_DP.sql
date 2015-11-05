use proyectoDB;

DROP PROCEDURE INSERTAR_DP
DROP PROCEDURE MODIFICAR_DP
DROP PROCEDURE ELIMINAR_DP
DROP PROCEDURE CONSULTAR_DP
DROP PROCEDURE CONSULTAR_DISENOS_DISPONIBLES
DROP PROCEDURE SOLICITAR_REQUERIMIENTOS_ASOCIADOS
DROP PROCEDURE SOLICITAR_REQUERIMIENTOS_NO_ASOCIADOS
DROP PROCEDURE SOLICITAR_DISENOS_ASOCIADOS_PROYECTO

GO 
CREATE PROCEDURE INSERTAR_DP
	@id_diseno int, @id_proyecto int, @nombre_diseno varchar(64), @fecha_inicio date, @tecnica_prueba varchar(64), @tipo_prueba varchar(64), @nivel_prueba varchar(64), @username_responsable varchar(64)
AS
	INSERT INTO DisenoPrueba
		(id_proyecto, nombre_diseno, fecha_inicio, tecnica_prueba, tipo_prueba, nivel_prueba, username_responsable)
	VALUES
		(@id_proyecto, @nombre_diseno, @fecha_inicio, @tecnica_prueba, @tipo_prueba, @nivel_prueba, @username_responsable)
GO

GO
CREATE PROCEDURE MODIFICAR_DP
	@id_diseno int, @id_proyecto int, @nombre_diseno varchar(64), @fecha_inicio date, @tecnica_prueba varchar(64), @nivel_prueba varchar(64), @username_responsable varchar(64)
AS
	UPDATE DisenoPrueba
		SET id_proyecto = @id_proyecto, nombre_diseno = @nombre_diseno, fecha_inicio = @fecha_inicio, tecnica_prueba = @tecnica_prueba, nivel_prueba = @nivel_prueba, username_responsable = @username_responsable
		WHERE id_diseno = @id_diseno
GO

GO
CREATE PROCEDURE ELIMINAR_DP
	@id_diseno int
AS
	DELETE FROM DisenoPrueba
	WHERE id_diseno = @id_diseno
GO

GO
CREATE PROCEDURE CONSULTAR_DP
	@id_diseno int
AS
	SELECT	DisenoPrueba.id_proyecto,
			DisenoPrueba.nombre_diseno,
			DisenoPrueba.fecha_inicio,
			DisenoPrueba.tecnica_prueba,
			DisenoPrueba.nivel_prueba,
			DisenoPrueba.username_responsable
	FROM DisenoPrueba
	WHERE id_diseno = @id_diseno
GO

GO
CREATE PROCEDURE CONSULTAR_DISENOS_DISPONIBLES
AS BEGIN
	SELECT	DisenoPrueba.id_diseno,
			DisenoPrueba.id_proyecto,
			DisenoPrueba.nombre_diseno,
			DisenoPrueba.fecha_inicio,
			DisenoPrueba.tecnica_prueba,
			DisenoPrueba.nivel_prueba,
			DisenoPrueba.username_responsable
	FROM DisenoPrueba
	END
GO

GO
CREATE PROCEDURE SOLICITAR_REQUERIMIENTOS_ASOCIADOS
	@id_diseno int
AS
	SELECT Requerimientos.nombre,
			Requerimientos.id_requerimiento
	FROM Requerimientos
	WHERE id_requerimiento IN (
		SELECT SePrueba.id_requerimiento
		FROM SePrueba
		WHERE id_diseno = @id_diseno)
GO

GO
CREATE PROCEDURE SOLICITAR_DISENOS_ASOCIADOS_PROYECTO
	@id_proyecto int
AS
	SELECT DisenoPrueba.id_diseno,
		   DisenoPrueba.nombre_diseno
	FROM DisenoPrueba
	WHERE id_proyecto = @id_proyecto
GO

GO
CREATE PROCEDURE SOLICITAR_REQUERIMIENTOS_NO_ASOCIADOS
	@id_diseno int
AS
	SELECT Requerimientos.nombre,
			Requerimientos.id_requerimiento
	FROM Requerimientos
	WHERE id_requerimiento IN (
		SELECT SePrueba.id_requerimiento
		FROM SePrueba
		WHERE id_diseno != @id_diseno)
GO
