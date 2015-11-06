use proyectoDB

DROP PROCEDURE INSERTAR_CP
DROP PROCEDURE ELIMINAR_CP
DROP PROCEDURE MODIFICAR_CP
DROP PROCEDURE CONSULTAR_CP
DROP PROCEDURE CONSULTAR_CASOS_DISPONIBLES



GO
CREATE PROCEDURE INSERTAR_CP
	@id_caso int, @id_diseno_asociado int, @proposito varchar(256), @flujo varchar(256)
AS
	INSERT INTO CasoPrueba
		(id_caso, id_diseno_asociado, proposito, flujo)
	VALUES
		(@id_caso, @id_diseno_asociado, @proposito, @flujo)
GO

GO
CREATE PROCEDURE ELIMINAR_CP
	@id_caso int
AS
	DELETE FROM CasoPrueba
	WHERE id_caso = @id_caso
GO

GO
CREATE PROCEDURE MODIFICAR_CP
	@id_caso int, @id_diseno_asociado int, @proposito varchar(256), @flujo varchar(256)
AS
	UPDATE CasoPrueba
		SET proposito = @proposito, flujo_central = @flujo
		WHERE id_caso = @id_caso
GO

GO
CREATE PROCEDURE CONSULTAR_CP
	@id_caso int
AS
	SELECT CasoPrueba.id_caso,
		   CasoPrueba.proposito,
		   CasoPrueba.datos_entrada,
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