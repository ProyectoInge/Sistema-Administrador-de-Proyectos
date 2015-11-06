use proyectoDB

DROP PROCEDURE INSERTAR_CP
DROP PROCEDURE INSERTAR_DATO_CP
DROP PROCEDURE ELIMINAR_CP
DROP PROCEDURE BORRAR_DATO_CASO
DROP PROCEDURE MODIFICAR_CP
DROP PROCEDURE CONSULTAR_CP
DROP PROCEDURE CONSULTAR_CASOS_DISPONIBLES
DROP PROCEDURE ASOCIAR_CASO_CON_REQUERIMIENTO
DROP PROCEDURE CONSULTAR_ENTRADA_DATOS



GO
CREATE PROCEDURE INSERTAR_CP
	@id_diseno_asociado int, @proposito varchar(256), @flujo varchar(256)
AS
	DECLARE @id_caso varchar(24)
	SET @id_caso = 'D'+CONVERT(varchar(24),@id_diseno_asociado) +'CP'+CONVERT(varchar(24), (SELECT COUNT(*)+1
	FROM CasoPrueba
	WHERE CasoPrueba.id_diseno = @id_diseno_asociado))
	INSERT INTO CasoPrueba
		(id_caso, id_diseno, proposito, flujo_central)
	VALUES
		(@id_caso, @id_diseno_asociado, @proposito, @flujo)
GO

GO
CREATE PROCEDURE INSERTAR_DATO_CP
	@id_caso_prueba int, @entrada_de_datos varchar(256) , @estado_datos varchar(24), @resultado_esperado varchar(256)
AS

	INSERT INTO DatosCasoDePrueba
		(id_caso_prueba, entrada_de_datos, estado_datos, resultado_esperado)
	VALUES
		(@id_caso_prueba, @entrada_de_datos, @estado_datos, @resultado_esperado)
GO

GO
CREATE PROCEDURE ELIMINAR_CP
	@id_caso varchar(24)
AS
	DELETE FROM CasoPrueba
	WHERE id_caso = @id_caso
GO

GO
CREATE PROCEDURE MODIFICAR_CP
	@id_caso varchar(24), @id_diseno_asociado int, @proposito varchar(256), @flujo varchar(256)
AS
	UPDATE CasoPrueba
		SET proposito = @proposito, flujo_central = @flujo
		WHERE id_caso = @id_caso
GO

GO
CREATE PROCEDURE BORRAR_DATO_CASO
	@id_caso varchar(24)
AS
	DELETE FROM DatosCasoDePrueba
	WHERE @id_caso = id_caso_prueba
GO

GO
CREATE PROCEDURE CONSULTAR_CP
	@id_caso varchar(24)
AS
	SELECT CasoPrueba.id_caso,
		   CasoPrueba.proposito,
		   CasoPrueba.flujo_central
	FROM
			CasoPrueba
	WHERE
			id_caso = @id_caso
GO

GO
CREATE PROCEDURE CONSULTAR_CASOS_DISPONIBLES
	@id_diseno int
AS
	SELECT CasoPrueba.id_caso,
			CasoPrueba.proposito,
			CasoPrueba.flujo_central
	FROM CasoPrueba
	WHERE CasoPrueba.id_diseno = @id_diseno;
GO

GO
	CREATE PROCEDURE ASOCIAR_CASO_CON_REQUERIMIENTO
		@id_caso_prueba varchar(24), @id_requerimiento int
	AS
	INSERT INTO NecesitaDe
			(id_requerimiento, id_caso)
	VALUES
		(@id_requerimiento, @id_caso_prueba)
GO

GO
	CREATE PROCEDURE CONSULTAR_ENTRADA_DATOS
		@id_caso_prueba varchar(24)
	AS
		SELECT entrada_de_datos, estado_datos, resultado_esperado
		FROM DatosCasoDePrueba
		WHERE DatosCasoDePrueba.id_caso_prueba = @id_caso_prueba
GO


/* TO DO ARREGLAR SPRINT 2
GO
CREATE PROCEDURE INSERTAR_CP
	@id_diseno_asociado int, @proposito varchar(256), @flujo varchar(256)
AS
	DECLARE @id_caso varchar(24)
	SET @id_caso = CONVERT(varchar(24), (SELECT COUNT(*)+1
	FROM CasoPrueba
	WHERE CasoPrueba.id_diseno = @id_diseno_asociado))
	INSERT INTO CasoPrueba
		(id_caso, id_diseno, proposito, flujo_central)
	VALUES
		(@id_caso, @id_diseno_asociado, @proposito, @flujo)
GO
*/
