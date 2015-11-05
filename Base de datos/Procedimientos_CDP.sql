use proyectoDB

DROP PROCEDURE CONSULTAR_CASOS_DISPONIBLES

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