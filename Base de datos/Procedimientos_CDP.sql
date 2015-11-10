--use proyectoDB
use g1inge

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
	@id_req_asociado varchar(32), @id_diseno_asociado int, @proposito varchar(256), @resultado_esperado varchar(256), @flujo varchar(256)
AS
	DECLARE @id_caso varchar(64)
	SET @id_caso = @id_req_asociado+CONVERT(varchar(24),@id_diseno_asociado)+CONVERT(varchar(24), (SELECT COUNT(*)+1
	FROM CasoPrueba
	WHERE CasoPrueba.id_diseno = @id_diseno_asociado))
	INSERT INTO CasoPrueba
		(id_caso, id_diseno, proposito, resultado_esperado, flujo_central)
	VALUES
		(@id_caso, @id_diseno_asociado, @proposito, @resultado_esperado, @flujo)
GO

GO
CREATE PROCEDURE MODIFICAR_CP
	@id_caso varchar(64), @proposito varchar(256), @resultado_esperado varchar(256), @flujo varchar(256)
AS
	UPDATE CasoPrueba
		SET proposito = @proposito, flujo_central = @flujo, resultado_esperado = @resultado_esperado
		WHERE id_caso = @id_caso
GO

GO
CREATE PROCEDURE ELIMINAR_CP
	@id_caso varchar(64)
AS
	DELETE FROM CasoPrueba
	WHERE id_caso = @id_caso
GO

GO
CREATE PROCEDURE CONSULTAR_CP
	@id_caso varchar(64)
AS
	SELECT CasoPrueba.id_caso,
		   CasoPrueba.proposito,
		   CasoPrueba.resultado_esperado,
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
		   CasoPrueba.resultado_esperado,
		   CasoPrueba.flujo_central
	FROM CasoPrueba
	WHERE CasoPrueba.id_diseno = @id_diseno;
GO

-- Entrada de datos

GO
CREATE PROCEDURE INSERTAR_DATO_CP
	@id_caso_prueba varchar(64), @valor varchar(256) , @tipo varchar(24)
AS
	INSERT INTO DatosCasoDePrueba
		(id_caso_prueba, valor, tipo)
	VALUES
		(@id_caso_prueba, @valor, @tipo)
GO

GO
CREATE PROCEDURE BORRAR_DATO_CASO
	@id_caso varchar(64)
AS
	DELETE FROM DatosCasoDePrueba
	WHERE @id_caso = id_caso_prueba
GO

GO
CREATE PROCEDURE CONSULTAR_ENTRADA_DATOS
	@id_caso_prueba varchar(64)
AS
	SELECT valor, tipo
	FROM DatosCasoDePrueba
	WHERE DatosCasoDePrueba.id_caso_prueba = @id_caso_prueba
GO
