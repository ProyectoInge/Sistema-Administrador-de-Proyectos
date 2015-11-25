use proyectoDB

select * from RecursosHumanos
execute INSERTAR_RH 'root',			'1-1111-1111',	NULL,	'11111111',	'administrador',	'ufyMBp0H3KKtohFM+oP4AkyTqZmdheF+Wifbk9Xu7p0BlE++','administrador@root.com',		NULL,	1
execute INSERTAR_RH 'batman',		'3-2211-4455',	NULL,	'22778833',	'Bruce Wayne',		'Lj1VUb1pd2hoUt3LVImdfRwXtR138Y9YZE4Jz/du74GEm6w2',	'imbatman@batman.com',			NULL,	1
execute INSERTAR_RH 'fabo49',		'1-1573-0081',	NULL,	'85713975',	'Fabian Rodriguez',	'CQ3NYEWgoGEyKGFZ1pV+9btYQzvl8RQczodm65/Ib13JcRXo',	'farodriguez.49@gmail.com',		NULL,	1
execute INSERTAR_RH 'goku',			'2-8833-1100',	NULL,	'99882211',	'Kakaroto',			'emFFzibmzd2VGMKO9p4AxZ4DpKMZzoj18giMWatl0yS5KzDl',	'songoku@namek.com',			NULL,	1
execute INSERTAR_RH 'KN13',			'5-2211-9988',	NULL,	'88776633',	'Keylor Navas',		'rr+4+Fe+r7bi4/60vAjaTxMAos4VzE7dyOivCLbE70LLqkjE',	'keylor.navas@realmadrid.com',	NULL,	1
execute INSERTAR_RH 'monical.94',	'1-1571-0088',	NULL,	'86793013',	'Monica Calderon',	'J4WOvG5U8ieG/szds8pYqyuSqueIXvcI/cmovc7owxNA+ROV',	'monical_94@hotmail.com',		NULL,	1
execute INSERTAR_RH 'ramon',		'1-1111-1111',	NULL,	'22602556',	'Don Ramon',		'o+QvU/qB+AAai7Xrv4gsL/lg4+9aWXDpH4R9Kjk+qdiQqiBU',	'ramon@vecindad.com',			NULL,	1
execute INSERTAR_RH 'sabogol',		'3-2211-4455',	NULL,	'88771122',	'Alvaro Saborio',	'uBuAwDV6kMIg955nFxRx0xw7wkm9eTSWUK1fODqRTWmyVJ9+',	'sabo@sele.com',				NULL,	1
execute INSERTAR_RH 'slyjose',		'1-1549-0003',	NULL,	'87107648',	'Jose Ure�a',		'pm2Gz+4j7brvixNVxbuiA8dGJqRscqDXWPualhW551BNE4HV',	'jpurena14@hotmail.com',		NULL,	1

select * from Oficina
INSERT INTO Oficina VALUES ('Oficina1', '25110000','25112355','Vladimir Rodr�guez')
INSERT INTO Oficina VALUES ('Oficina2', '29960800','28010745','Adolfo Guti�rrez')
INSERT INTO Oficina VALUES ('Oficina3', '25178600','25110045','Teodoro Picado')
INSERT INTO Oficina VALUES ('Oficina4', '26895000','22610075','Felipe Gonz�lez')
INSERT INTO Oficina VALUES ('Oficina5', '22491220','22910005','Sanders Jim�nez')

select * from ProyectoPruebas
execute INSERTAR_PYP 9898, 1, '08-31-2015', '08-31-2015', '12-31-2015', 'HIP HOP', 'Bla', 'Proyecto 1', 'Asignado'
execute INSERTAR_PYP 9898, 2, '08-31-2015', '08-31-2015', '12-31-2015', 'HIP HOP', 'Bla', 'Proyecto 2', 'Asignado'
execute INSERTAR_PYP 9898, 3, '08-31-2015', '08-31-2015', '12-31-2015', 'HIP HOP', 'Bla', 'Proyecto 3', 'Asignado'

execute INSERTAR_RH 'usuario',		'1-1111-1111',  2,		'22780989', 'Usuario',			'CZPDpurUqsbm0QLlCtDOxqCtgd5b+sUh0+X5R6DmxrK+eg9F', 'usuario@usuario.com',		'Usuario',	0
execute INSERTAR_RH 'kefds',		'1-115580434',  1,		'77777777',	'Kevin Delgado',	'4/bVsJ4mkhdoK6vOu3M5dN60TnhFNGqBtu43Yt1P2co8lgGL',	'kremlin@urss.ru',				'Usuario',	0

select * from DisenoPrueba
execute INSERTAR_DP 0, 1, 'Dise�o 1', '09-12-2015', 'bla', 'bla', 'bla', 'root', 'ambiente de prueba', 'criterio 1, criterio 2...'
execute INSERTAR_DP 0, 1, 'Dise�o 2', '08-31-2015', 'bla', 'bla', 'bla', 'root', 'ambiente de prueba', 'criterio 1, criterio 2...'
execute INSERTAR_DP 0, 1, 'Dise�o 3', '11-28-2015', 'bla', 'bla', 'bla', 'root', 'ambiente de prueba', 'criterio 1, criterio 2...'
execute INSERTAR_DP 0, 3, 'Dise�o 4', '11-28-2015', 'bla', 'bla', 'bla', 'root', 'ambiente de prueba', 'criterio 1, criterio 2...'
execute INSERTAR_DP 0, 2, 'Dise�o 5', '11-28-2015', 'bla', 'bla', 'bla', 'root', 'ambiente de prueba', 'criterio 1, criterio 2...'

select * from Requerimientos
execute INSERTAR_REQUERIMIENTO 'RH_I', 'Requerimiento 1', 'Criterio 1, Criterio 2'
execute INSERTAR_REQUERIMIENTO 'RH_M', 'Requerimiento 2', 'Criterio 1, Criterio 2'
execute INSERTAR_REQUERIMIENTO 'DP_I', 'Requerimiento 3', 'Criterio 1, Criterio 2'
execute INSERTAR_REQUERIMIENTO 'DP_E', 'Requerimiento 4', 'Criterio 1, Criterio 2'

select * from CasoPrueba
execute INSERTAR_CP  1, 'Unitaria#1', 'A,B,C'
execute INSERTAR_CP  1, 'Unitaria#2', 'A,B,C'
execute INSERTAR_CP  1, 'Unitaria#3', 'A,B,C'
execute INSERTAR_CP  2, 'Unitaria#1', 'A,B,C'
execute INSERTAR_CP  2, 'Unitaria#2', 'A,B,C'
execute INSERTAR_CP  2, 'Unitaria#3', 'A,B,C'
