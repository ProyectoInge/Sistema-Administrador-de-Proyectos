

DROP PROCEDURE ELIMINAR_EP

GO
CREATE PROCEDURE ELIMINAR_EP
	@id_diseno int, @num_ejec int
AS
	DELETE FROM Ejecucion
	WHERE id_diseno = @id_diseno AND num_ejecucion = @num_ejec
GO