use proyectoDB

DROP PROCEDURE ELIMINAR_EP;
DROP PROCEDURE ELIMINAR_RESULTADO;
DROP PROCEDURE INSERTAR_EP;
DROP PROCEDURE INSERTAR_RESULTADO;
DROP PROCEDURE CONSULTAR_EJECUCION;
DROP PROCEDURE CONSULTAR_RESULTADOS;
DROP PROCEDURE CONSULTAR_EJECUCIONES;

GO
CREATE PROCEDURE ELIMINAR_EP
	@id_diseno int, @num_ejecucion int
AS
	DELETE FROM Ejecucion
	WHERE id_diseno = @id_diseno AND num_ejecucion = @num_ejecucion
GO

GO
CREATE PROCEDURE ELIMINAR_RESULTADO
	@id_diseno int, @num_ejecucion int, @num_resultado int
AS
	DELETE FROM Resultados
	WHERE id_diseno = @id_diseno AND num_ejecucion = @num_ejecucion  AND num_resultado = @num_resultado
GO

GO
CREATE PROCEDURE INSERTAR_EP
	@responsable varchar(64), @id_diseno int, @fecha_ultima_ejec datetime, @incidencias varchar(512)
AS
	INSERT INTO Ejecucion
		(responsable, id_diseno, fecha_ultima_ejec, incidencias)
	VALUES
		 (@responsable, @id_diseno, @fecha_ultima_ejec, @incidencias)
GO

GO
CREATE PROCEDURE INSERTAR_RESULTADO
	@id_diseno int, @num_ejecucion int, @estado varchar(32), @tipo_no_conformidad varchar(64), @id_caso varchar(64), @desc_no_conformidad varchar(256), @justificacion varchar(512), @ruta_imagen varchar(512)
AS
	INSERT INTO Resultados
		(id_diseno, num_ejecucion, estado, tipo_no_conformidad, id_caso, desc_no_conformidad, justificacion, ruta_imagen)
	VALUES
		(@id_diseno, @num_ejecucion, @estado, @tipo_no_conformidad, @id_caso, @desc_no_conformidad, @justificacion, @ruta_imagen)
GO

GO
CREATE PROCEDURE CONSULTAR_EJECUCION
	@numero_ejecucion int
AS
	SELECT *
	FROM Ejecucion
	WHERE num_ejecucion = @numero_ejecucion
GO

GO
CREATE PROCEDURE CONSULTAR_RESULTADOS
	@numero_ejecucion int
AS
	SELECT *
	FROM Resultados
	WHERE num_ejecucion = @numero_ejecucion
GO

GO
CREATE PROCEDURE CONSULTAR_EJECUCIONES
	@id_diseno int
AS
	SELECT *
	FROM Ejecucion
GO