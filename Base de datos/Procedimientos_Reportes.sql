use proyectoDB
DROP PROCEDURE FILTRAR_PROYECTOS
DROP PROCEDURE FILTRAR_DISENOS
DROP PROCEDURE FILTRAR_EJECUCIONES

GO
CREATE PROCEDURE FILTRAR_EJECUCIONES
	@filtro_responsable varchar(64), @filtro_despues_de varchar(64), @filtro_id_disenos varchar(64)
AS
DECLARE @SQLCommand nvarchar(512)
SET @SQLCommand = 'SELECT *FROM Ejecucion WHERE ' --los espacios importan
IF @filtro_responsable != ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_responsable+char(39)+' = Ejecucion.responsable AND ';
IF @filtro_despues_de != ''
SET @SQLCommand = @SQLCommand+'Cast('+char(39)+Convert(varchar(16),@filtro_despues_de,10)+char(39)+' as datetime) <= Ejecucion.fecha_ultima_ejec AND '; 
IF @filtro_id_disenos != ''
SET @SQLCommand = @SQLCommand+' Ejecucion.id_proyecto IN ('+@filtro_id_disenos+') AND ';
SET @SQLCommand = @SQLCommand+' 0=0 ';  --se podrá mejorar?
EXECUTE(@SQLCommand)
GO

execute FILTRAR_EJECUCIONES '','',''
execute FILTRAR_EJECUCIONES 'kefds','',''
execute FILTRAR_EJECUCIONES '','',''

DECLARE @date1 datetime
SET @date1= '08-01-2016'
execute FILTRAR_EJECUCIONES '',@date1,''


GO
CREATE PROCEDURE FILTRAR_DISENOS
	@filtro_tecnica_de_prueba varchar(64), @filtro_tipo_de_prueba varchar(64), @filtro_nivel_de_prueba varchar(64), @filtro_responsable varchar(64), @filtro_despues_de datetime, @filtro_antes_de datetime, @filtro_id_proyectos varchar(64)
AS
DECLARE @SQLCommand nvarchar(2048)
SET @SQLCommand = 'SELECT *FROM DisenoPrueba WHERE ' --los espacios importan
IF @filtro_tecnica_de_prueba != ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_tecnica_de_prueba+char(39)+' = DisenoPrueba.tecnica_prueba AND';
IF @filtro_tipo_de_prueba!= ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_tipo_de_prueba+char(39)+' = DisenoPrueba.tipo_prueba AND';
IF @filtro_nivel_de_prueba!= ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_nivel_de_prueba+char(39)+' = DisenoPrueba.nivel_prueba AND ';
IF @filtro_responsable != ''
SET @SQLCommand = @SQLCommand+char(39)+@filtro_responsable+char(39)+' = DisenoPrueba.username_responsable AND';
IF @filtro_despues_de != ''
SET @SQLCommand = @SQLCommand+'Cast('+char(39)+Convert(varchar(16),@filtro_despues_de,10)+char(39)+' as datetime) <= DisenoPrueba.fecha_inicio AND '; 
IF @filtro_antes_de != ''
SET @SQLCommand = @SQLCommand+'Cast('+char(39)+Convert(varchar(16),@filtro_antes_de,10)+char(39)+' as datetime) >= DisenoPrueba.fecha_inicio AND ';
IF @filtro_id_proyectos != ''
SET @SQLCommand = @SQLCommand+' DisenoPrueba.id_proyecto IN ('+@filtro_id_proyectos+') AND ';
SET @SQLCommand = @SQLCommand+' 0=0 ';  --se podrá mejorar?
EXECUTE(@SQLCommand)
GO

-- Casos de prueba 
GO
CREATE PROCEDURE FILTRAR_CASOS
	@id_disenos_pruebas varchar(64)
AS
DECLARE @SQLCommand nvarchar(2048)
SET @SQLCommand = 'SELECT * FROM CasoPrueba WHERE '
IF @id_disenos_pruebas != ''
SET @SQLCommand = @SQLCommand+'id_diseno IN (' + @id_disenos_pruebas + ') AND ';
SET @SQLCommand = @SQLCommand+' 0=0 ';
EXECUTE(@SQLCommand)
GO

SELECT * FROM CasoPrueba 

DROP PROCEDURE FILTRAR_CASOS

EXECUTE FILTRAR_CASOS '3'

--PRUEBAS FILTRO Diseno

execute FILTRAR_DISENOS '','','','','','',''						--Sin filtro
execute FILTRAR_DISENOS '','','','','','','7'
execute FILTRAR_DISENOS 'Caja Negra','','','','','',''
execute FILTRAR_DISENOS 'Caja Negra','Funcional','','','','',''
execute FILTRAR_DISENOS '','','De integración','kefds','','',''

DECLARE @date1 datetime, @date2 datetime
SET @date1= '08-30-2015'
SET @date2= '12-10-2015'
execute FILTRAR_DISENOS '','','','',@date1,@date2,''



GO
CREATE PROCEDURE FILTRAR_PROYECTOS
	@filtro_id_oficina int, @filtro_despues_de datetime, @filtro_antes_de datetime, @filtro_estado varchar(64),  @filtro_miembro varchar(64)
AS
DECLARE @SQLCommand nvarchar(2048)

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
execute FILTRAR_PROYECTOS -1, '', '', '',''					--Sin filtro
execute FILTRAR_PROYECTOS 1, '', '', 'Finalizado',''
execute FILTRAR_PROYECTOS -1, '', '', '','kefds'	

DECLARE @date1 datetime, @date2 datetime
SET @date1= '08-30-2015'
SET @date2= '12-10-2015'
execute FILTRAR_PROYECTOS -1, NULL, @date2, '',''			--Filtro entre dos fechas