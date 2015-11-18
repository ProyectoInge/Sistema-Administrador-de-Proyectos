

DROP PROCEDURE ELIMINAR_EP;
DROP PROCEDURE ELIMINAR_RESULTADO;

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