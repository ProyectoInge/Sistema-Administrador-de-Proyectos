use proyectoDB
DROP PROCEDURE FILTRAR_PROYECTOS





GO
CREATE PROCEDURE FILTRAR_PROYECTOS
	@filtro_id_oficina varchar(16), @filtro_despues_de datetime, @filtro_antes_de datetime, @filtro_nombre_sistema varchar(64), @filtro_estado varchar(64)
AS
DECLARE @SQLCommand nvarchar(1024)
SET @SQLCommand = 'SELECT *FROM ProyectoPruebas WHERE ' --los espacios importan

IF @filtro_id_oficina != ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_id_oficina+char(39)+' = ProyectoPruebas.id_oficina AND ';	
IF @filtro_despues_de != ''
SET @SQLCommand = @SQLCommand+Convert(varchar(16),@filtro_despues_de,10)+' <= ProyectoPruebas.fecha_inicio AND '; --datetime styles : http://www.w3schools.com/sql/func_convert.asp
IF @filtro_antes_de != ''
SET @SQLCommand = @SQLCommand+Convert(varchar(16),@filtro_antes_de,10)+' <= ProyectoPruebas.fecha_final AND ';
IF @filtro_nombre_sistema != ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_nombre_sistema+char(39)+' = ProyectoPruebas.nombre_sistema AND ';
IF @filtro_estado != ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_estado+char(39)+' = ProyectoPruebas.estado AND';
SET @SQLCommand = @SQLCommand+' 0=0 ';  --se podrá mejorar?
PRINT(@SQLCommand)
GO

execute FILTRAR_PROYECTOS '', '', '', '',''						--Sin filtro
execute FILTRAR_PROYECTOS '1', '', '', '','Finalizado'
execute FILTRAR_PROYECTOS '1', '', '', 'HIP HOP','Finalizado'


DECLARE @date1 datetime, @date2 datetime
SET @date1= '09-30-2015'
SET @date2= '09-02-2015'
execute FILTRAR_PROYECTOS '', @date1, '', '',''			--Filtro entre dos fechas

execute FILTRAR_PROYECTOS '', '', '', '',''						--Sin filtro



SELECT *FROM ProyectoPruebas WHERE 09-30-2015 < ProyectoPruebas.fecha_inicio AND  0=0
