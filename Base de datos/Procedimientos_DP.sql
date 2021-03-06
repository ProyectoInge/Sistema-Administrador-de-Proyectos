use proyectoDB;

DROP PROCEDURE INSERTAR_DP
DROP PROCEDURE MODIFICAR_DP
DROP PROCEDURE ELIMINAR_DP
DROP PROCEDURE CONSULTAR_DP
DROP PROCEDURE CONSULTAR_DISENOS_DISPONIBLES

GO 
CREATE PROCEDURE INSERTAR_DP
	@id_diseno int, @id_proyecto int, @nombre_diseno varchar(64), @fecha_inicio date, @tecnica_prueba varchar(64), @nivel_prueba varchar(64)
AS
	INSERT INTO DisenoPrueba
		(id_proyecto, nombre_diseno, fecha_inicio, tecnica_prueba, nivel_prueba)
	VALUES
		(@id_proyecto, @nombre_diseno, @fecha_inicio, @tecnica_prueba, @nivel_prueba)
GO

GO
CREATE PROCEDURE MODIFICAR_DP
	@id_diseno int, @id_proyecto int, @nombre_diseno varchar(64), @fecha_inicio date, @tecnica_prueba varchar(64), @nivel_prueba varchar(64)
AS
	UPDATE DisenoPrueba
		SET id_proyecto = @id_proyecto, nombre_diseno = @nombre_diseno, fecha_inicio = @fecha_inicio, tecnica_prueba = @tecnica_prueba, nivel_prueba = @nivel_prueba
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
			DisenoPrueba.nivel_prueba
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
			DisenoPrueba.nivel_prueba
	FROM DisenoPrueba
	END
GO