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
SET @SQLCommand = @SQLCommand+'Cast('+char(39)+Convert(varchar(16),@filtro_despues_de,10)+char(39)+' as datetime) <= ProyectoPruebas.fecha_inicio AND '; 
IF @filtro_antes_de != ''
SET @SQLCommand = @SQLCommand+'Cast('+char(39)+Convert(varchar(16),@filtro_antes_de,10)+char(39)+' as datetime) <= ProyectoPruebas.fecha_final AND ';
IF @filtro_nombre_sistema != ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_nombre_sistema+char(39)+' = ProyectoPruebas.nombre_sistema AND ';
IF @filtro_estado != ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_estado+char(39)+' = ProyectoPruebas.estado AND';
SET @SQLCommand = @SQLCommand+' 0=0 ';  --se podrá mejorar?
EXECUTE(@SQLCommand)
GO

execute FILTRAR_PROYECTOS '', '', '', '',''						--Sin filtro
execute FILTRAR_PROYECTOS '1', '', '', '','Finalizado'
execute FILTRAR_PROYECTOS '1', '', '', 'HIP HOP','Finalizado'


DECLARE @date1 datetime, @date2 datetime
SET @date1= '08-30-2015'
SET @date2= '12-10-2015'
execute FILTRAR_PROYECTOS '', @date1, @date2, '',''			--Filtro entre dos fechas