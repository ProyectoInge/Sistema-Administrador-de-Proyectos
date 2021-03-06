
use proyectoDB;



	drop table Ejecucion;
	drop table NecesitaDe;
	drop table CasoPrueba;
	drop table SePrueba;
	drop table Requerimientos;
	drop table DisenoPrueba;
	drop table MiembroPertenece;
	drop table RecursosHumanos;
	drop table ProyectoPruebas;
	drop table Oficina;



create table Oficina(
	id_oficina			int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre_oficina		varchar(64) NOT NULL,
	telefono			varchar(16),
	telefono2			varchar(16),
	nom_representante	varchar(64)
);


create table ProyectoPruebas(
	id_proyecto			int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	id_oficina			int NOT NULL FOREIGN KEY REFERENCES Oficina(id_oficina),
	fecha_inicio		datetime,
	fecha_asignacion	datetime,
	fecha_final			datetime,
	nombre_sistema		varchar(64) NOT NULL,
	obj_general			varchar(256),
	nombre_proyecto		varchar(64),
	estado				varchar(32),
	eliminado			bit NOT NULL
);

create table RecursosHumanos(
	id_rh				int IDENTITY(1,1) NOT NULL,
	username			varchar(64) NOT NULL PRIMARY KEY,
	cedula				varchar(16)  NOT NULL,
	id_proyecto			int FOREIGN KEY REFERENCES ProyectoPruebas(id_proyecto),
	telefono			varchar(16),
	nombre				varchar(64) NOT NULL,
	contrasena			varchar(256) NOT NULL,
	correo				varchar(64) NOT NULL,
	rol					varchar(64),
	es_administrador	bit NOT NULL,
	sesion_iniciada		bit NOT NULL
);

create table MiembroPertenece(
	username			varchar(64) NOT NULL FOREIGN KEY REFERENCES RecursosHumanos(username),
	id_proyecto			int NOT NULL FOREIGN KEY REFERENCES ProyectoPruebas(id_proyecto),
	rol					varchar(64) NOT NULL,
	PRIMARY KEY(username, id_proyecto)
);

create table DisenoPrueba(
	id_diseno			int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	id_proyecto			int NOT NULL FOREIGN KEY REFERENCES ProyectoPruebas(id_proyecto),
	nombre_diseno		varchar(64) NOT NULL,
	fecha_inicio		date		NOT NULL,
	tecnica_prueba		varchar(64),
	tipo_prueba			varchar(64) NOT NULL,
	nivel_prueba		varchar(64)
);

create table Requerimientos(
	id_requerimiento	int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre				varchar(64) NOT NULL,
	a_probar			bit			NOT NULL
);

create table SePrueba(
	id_diseno			int IDENTITY(1,1) NOT NULL FOREIGN KEY REFERENCES DisenoPrueba(id_diseno),
	id_requerimiento	int NOT NULL FOREIGN KEY REFERENCES Requerimientos(id_requerimiento),
	criterio_aceptacion varchar(256) NOT NULL,
	proposito			varchar(128) NOT NULL,
	procedimiento		varchar(512) NOT NULL,
	PRIMARY KEY(id_diseno, id_requerimiento)
);

create table CasoPrueba(
	id_caso				int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	proposito			varchar(256),
	datos_entrada		varchar(128),
	flujo_central		varchar(512),
	resultado_esperado	varchar(512)
);

create table NecesitaDe(
	id_requerimientos	int NOT NULL FOREIGN KEY REFERENCES Requerimientos(id_requerimiento),
	id_caso				int NOT NULL FOREIGN KEY REFERENCES CasoPrueba(id_caso),
	precondiciones		varchar(512),
	variables			varchar(512),
	restricciones		varchar(512),
	PRIMARY KEY(id_requerimientos, id_caso)
);

create table Ejecucion(
	num_ejecucion		int NOT NULL,
	id_caso				int NOT NULL FOREIGN KEY REFERENCES CasoPrueba(id_caso),
	tipo_no_conformidad varchar(64),
	desc_no_conformidad varchar(256),
	justificacion		varchar(512),
	resultados			varchar(512),
	estado				bit NOT NULL,
	fecha_ultima_ejec	date,
	incidencias			varchar(512)
);
