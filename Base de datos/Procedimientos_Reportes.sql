use proyectoDB

DROP PROCEDURE FILTRAR_PROYECTOS
DROP PROCEDURE FILTRAR_DISENOS

--EN CONSTRUCCIÓN
GO
CREATE PROCEDURE FILTRAR_DISENOS
	@filtro_id_proyecto int, @filtro_id_requerimiento int, @filtro_nivel_de_prueba varchar(64), @filtro_tipo_de_prueba varchar(64), @filtro_tecnica_de_prueba varchar(64), @filtro_responsable varchar(64)
AS
DECLARE @SQLCommand nvarchar(1024)
SET @SQLCommand = 'SELECT *FROM DisenoPrueba WHERE ' --los espacios importan

IF @filtro_id_requerimiento != ''
SET @SQLCommand = 'SELECT DisenoPrueba.*, SePrueba.id_requerimiento FROM DisenoPrueba JOIN SePrueba ON DisenoPrueba.id_diseno = SePrueba.id_diseno WHERE '+char(39)+Convert(varchar(64),@filtro_id_requerimiento)+char(39)+' = SePrueba.id_requerimiento AND ';
ELSE
SET @SQLCommand = 'SELECT *FROM DisenoPrueba WHERE ' --los espacios importan
IF @filtro_id_proyecto > -1
SET @SQLCommand = @SQLCommand+char(39)+Convert(varchar(16),@filtro_id_proyecto)+char(39)+' = DisenoPrueba.id_proyecto AND ';	--SI NO VIENE id_proyecto enviar un -1 NO un ""
IF @filtro_nivel_de_prueba!= ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_nivel_de_prueba+char(39)+' = DisenoPrueba.nivel_prueba AND ';
IF @filtro_tipo_de_prueba!= ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_tipo_de_prueba+char(39)+' = DisenoPrueba.tipo_prueba AND';
IF @filtro_tecnica_de_prueba != ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_tecnica_de_prueba+char(39)+' = DisenoPrueba.tecnica_prueba AND';
IF @filtro_responsable != ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_responsable+char(39)+' = DisenoPrueba.username_responsable AND';
SET @SQLCommand = @SQLCommand+' 0=0 ';  --se podrá mejorar?
EXECUTE(@SQLCommand)
GO


Select * from DisenoPrueba
SELECT *FROM SePrueba

execute FILTRAR_DISENOS -1, -1, '', '','',''						--Sin filtro
execute FILTRAR_DISENOS -1, -1, '','', '', 'kefds'
execute FILTRAR_DISENOS -1, 'DP_E', '', '', '',''		




--EN CONSTRUCCIÓN






GO
CREATE PROCEDURE FILTRAR_PROYECTOS
	@filtro_id_oficina int, @filtro_despues_de datetime, @filtro_antes_de datetime, @filtro_estado varchar(64),  @filtro_miembro varchar(64)
AS
DECLARE @SQLCommand nvarchar(1024)

IF @filtro_miembro != ''
SET @SQLCommand = 'SELECT ProyectoPruebas.*,  RecursosHumanos.nombre FROM ProyectoPruebas JOIN RecursosHumanos ON ProyectoPruebas.id_proyecto = RecursosHumanos.id_proyecto WHERE '+char(39)+Convert(varchar(64),@filtro_miembro)+char(39)+' = RecursosHumanos.username AND ';
ELSE
SET @SQLCommand = 'SELECT *FROM ProyectoPruebas WHERE ' --los espacios importan
IF @filtro_id_oficina > -1
SET @SQLCommand = @SQLCommand+char(39)+Convert(varchar(16),@filtro_id_oficina)+char(39)+' = ProyectoPruebas.id_oficina AND ';	--SI NO VIENE id_oficina enviar un -1 NO un ""
IF @filtro_despues_de != ''
SET @SQLCommand = @SQLCommand+'Cast('+char(39)+Convert(varchar(16),@filtro_despues_de,10)+char(39)+' as datetime) <= ProyectoPruebas.fecha_inicio AND '; 
IF @filtro_antes_de != ''
SET @SQLCommand = @SQLCommand+'Cast('+char(39)+Convert(varchar(16),@filtro_antes_de,10)+char(39)+' as datetime) >= ProyectoPruebas.fecha_final AND ';
IF @filtro_estado != ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_estado+char(39)+' = ProyectoPruebas.estado AND';
SET @SQLCommand = @SQLCommand+' 0=0 ';  --se podrá mejorar?
EXECUTE(@SQLCommand)
GO

--PRUEBAS FILTRO PROYECTO
execute FILTRAR_PROYECTOS -1, '', '', '',''						--Sin filtro
execute FILTRAR_PROYECTOS 1, '', '', 'Finalizado','kefds'
execute FILTRAR_PROYECTOS -1, '', '', '','kefds'		


DECLARE @date1 datetime, @date2 datetime
SET @date1= '08-30-2015'
SET @date2= '12-10-2015'
execute FILTRAR_PROYECTOS -1, '', @date2, '',''			--Filtro entre dos fechas

sELECT * FROM RecursosHumanos

