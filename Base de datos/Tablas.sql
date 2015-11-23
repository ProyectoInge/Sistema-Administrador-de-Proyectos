use proyectoDB;
--use g1inge

	drop table Resultados;
	drop table Ejecucion;
	drop table DatosCasoDePrueba;
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
	id_oficina			int NOT NULL FOREIGN KEY REFERENCES Oficina(id_oficina) ON DELETE CASCADE,
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
	id_proyecto			int FOREIGN KEY REFERENCES ProyectoPruebas(id_proyecto) ON DELETE SET NULL,
	telefono			varchar(16),
	nombre				varchar(64) NOT NULL,
	contrasena			varchar(256) NOT NULL,
	correo				varchar(64) NOT NULL,
	rol					varchar(64),
	es_administrador	bit NOT NULL,
	sesion_iniciada		bit NOT NULL
);

create table MiembroPertenece(
	username			varchar(64) NOT NULL FOREIGN KEY REFERENCES RecursosHumanos(username) ON DELETE CASCADE,
	id_proyecto			int NOT NULL FOREIGN KEY REFERENCES ProyectoPruebas(id_proyecto) ON DELETE CASCADE,
	rol					varchar(64) NOT NULL,
	PRIMARY KEY(username, id_proyecto)
);

create table DisenoPrueba(
	id_diseno			int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	id_proyecto			int NOT NULL FOREIGN KEY REFERENCES ProyectoPruebas(id_proyecto) ON DELETE CASCADE,
	nombre_diseno		varchar(64) NOT NULL,
	fecha_inicio		date		NOT NULL,
	tecnica_prueba		varchar(64),
	tipo_prueba			varchar(64) NOT NULL,
	nivel_prueba		varchar(64),
	username_responsable varchar(64) FOREIGN KEY REFERENCES RecursosHumanos(username) ON DELETE SET NULL,
	ambiente			varchar(128),
	proposito			varchar(128) NOT NULL,
	procedimiento		varchar(512) NOT NULL,
	criterio_aceptacion varchar(256)
);

create table Requerimientos(
	id_requerimiento	varchar(32) NOT NULL PRIMARY KEY,
	nombre				varchar(64) NOT NULL,
	criterio_aceptacion varchar(256) NOT NULL,
);

create table SePrueba(
	id_diseno			int NOT NULL FOREIGN KEY REFERENCES DisenoPrueba(id_diseno) ON DELETE CASCADE,
	id_requerimiento	varchar(32) NOT NULL FOREIGN KEY REFERENCES Requerimientos(id_requerimiento) ON DELETE CASCADE,
	PRIMARY KEY(id_diseno, id_requerimiento)
);

create table CasoPrueba(
	id_caso				varchar(64) NOT NULL PRIMARY KEY,
	id_diseno			int NOT NULL FOREIGN KEY REFERENCES DisenoPrueba(id_diseno) ON DELETE CASCADE,
	id_requerimiento	varchar(32) NOT NULL FOREIGN KEY REFERENCES Requerimientos(id_requerimiento) ON DELETE CASCADE,
	proposito			varchar(256),
	resultado_esperado  varchar(256),
	flujo_central		varchar(512)
);


create table DatosCasoDePrueba(
	id_dato int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	id_caso_prueba varchar(64) NOT NULL FOREIGN KEY REFERENCES CasoPrueba(id_caso) ON DELETE CASCADE,
	valor varchar(256), 
	tipo varchar(24)
);

create table Ejecucion(
	num_ejecucion		int IDENTITY(1,1) NOT NULL,
	responsable			varchar(64) FOREIGN KEY REFERENCES RecursosHumanos(username) ON DELETE SET NULL,
	id_diseno			int NOT NULL FOREIGN KEY REFERENCES DisenoPrueba(id_diseno),
	fecha_ultima_ejec	datetime,
	incidencias			varchar(512),
	PRIMARY KEY(id_diseno, num_ejecucion)
);

create table Resultados(
	num_resultado		int IDENTITY(1,1) NOT NULL,
	id_diseno			int NOT NULL, --FOREIGN KEY REFERENCES Ejecucion(id_diseno),
	num_ejecucion		int NOT NULL, --FOREIGN KEY REFERENCES Ejecucion(num_ejecucion),
	estado				varchar(32),
	tipo_no_conformidad varchar(64),
	id_caso				varchar(64) NOT NULL FOREIGN KEY REFERENCES CasoPrueba(id_caso) ON DELETE CASCADE,
	desc_no_conformidad varchar(256),
	justificacion		varchar(512),
	ruta_imagen			varchar(512),
	CONSTRAINT			fk_ejecucion	
	FOREIGN KEY(id_diseno, num_ejecucion) REFERENCES Ejecucion(id_diseno, num_ejecucion) ON DELETE CASCADE,
	PRIMARY KEY			(num_resultado, id_diseno, num_ejecucion)
);