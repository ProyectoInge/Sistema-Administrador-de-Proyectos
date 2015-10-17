use proyectoDB

DROP PROCEDURE INSERTAR_PYP
DROP PROCEDURE MODIFICAR_PYP
DROP PROCEDURE ELIMINAR_PYP
DROP PROCEDURE CONSULTAR_PYP
DROP PROCEDURE CONSULTAR_PROYECTOS_DISPONIBLES
DROP PROCEDURE CONSULTAR_OFICINAS_DISPONIBLES


GO
CREATE PROCEDURE INSERTAR_PYP
	@id_proyecto int, @id_oficina int, @fecha_inicio date, @fecha_asignacion date, @fecha_final date, @nombre_sistema varchar(64), @obj_general varchar(256), @nombre_proyecto varchar(64), @estado varchar(32)
AS
	INSERT INTO ProyectoPruebas
		(id_oficina, fecha_inicio, fecha_asignacion, fecha_final, nombre_sistema, obj_general, nombre_proyecto, estado, eliminado)
	VALUES
		(@id_oficina, @fecha_inicio, @fecha_asignacion, @fecha_final, @nombre_sistema, @obj_general, @nombre_proyecto, @estado, 0)

GO

GO
CREATE PROCEDURE MODIFICAR_PYP
	@id_proyecto int, @id_oficina int, @fecha_inicio date, @fecha_asignacion date, @fecha_final date, @nombre_sistema varchar(64), @obj_general varchar(256), @nombre_proyecto varchar(64), @estado varchar(32)
AS
	UPDATE ProyectoPruebas
		SET id_oficina = @id_oficina, fecha_inicio = @fecha_inicio, fecha_final=@fecha_final, nombre_sistema=@nombre_sistema, obj_general=@obj_general, nombre_proyecto=@nombre_proyecto, estado = @estado
		WHERE id_proyecto = @id_proyecto
GO


GO
CREATE PROCEDURE ELIMINAR_PYP
	@id_proyecto int
AS
	UPDATE ProyectoPruebas
		SET eliminado = 1
		WHERE id_proyecto = @id_proyecto
GO


GO
CREATE PROCEDURE CONSULTAR_PYP
	@id_proyecto int
AS
	SELECT	ProyectoPruebas.id_oficina,
			ProyectoPruebas.fecha_inicio,
			ProyectoPruebas.fecha_asignacion,
			ProyectoPruebas.fecha_final,
			ProyectoPruebas.nombre_sistema,
			ProyectoPruebas.obj_general,
			ProyectoPruebas.nombre_proyecto,
			ProyectoPruebas.estado,
			ProyectoPruebas.eliminado
	FROM	ProyectoPruebas
	WHERE	ProyectoPruebas.id_proyecto = @id_proyecto AND ProyectoPruebas.eliminado = 0
GO 

GO
CREATE PROCEDURE CONSULTAR_PROYECTOS_DISPONIBLES
	AS BEGIN
	SELECT	ProyectoPruebas.nombre_proyecto,
			ProyectoPruebas.id_proyecto,
			ProyectoPruebas.estado,
			Oficina.nombre_oficina
	FROM	ProyectoPruebas JOIN Oficina
	ON		ProyectoPruebas.id_oficina = Oficina.id_oficina
	END
GO

GO
CREATE PROCEDURE CONSULTAR_OFICINAS_DISPONIBLES
AS BEGIN
	SELECT	Oficina.id_oficina,
			Oficina.nombre_oficina,
			Oficina.telefono,
			Oficina.telefono2,
			Oficina.nom_representante
	FROM	Oficina
	END
GO