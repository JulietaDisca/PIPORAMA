-- Script SQL Server: CineDB
-- Todas las PK creadas con CONSTRAINT y con IDENTITY para los id que sean primary key

CREATE DATABASE PIPORAMA;
GO

USE PIPORAMA;
GO

-- TABLAS DE CATEGORIZACIÓN Y REFERENCIA

CREATE TABLE categorias (
    id_categoria INT IDENTITY(1,1) NOT NULL,
    categoria VARCHAR(50),
    CONSTRAINT PK_categorias PRIMARY KEY (id_categoria)
);

CREATE TABLE marcas (
    id_marca INT IDENTITY(1,1) NOT NULL,
    marca VARCHAR(50),
    CONSTRAINT PK_marcas PRIMARY KEY (id_marca)
);

CREATE TABLE tipos_promocion (
    id_tipo_promo INT IDENTITY(1,1) NOT NULL,
    nombre VARCHAR(50),
    CONSTRAINT PK_tipos_promocion PRIMARY KEY (id_tipo_promo)
);

CREATE TABLE generos (
    id_genero INT IDENTITY(1,1) NOT NULL,
    genero VARCHAR(50),
    CONSTRAINT PK_generos PRIMARY KEY (id_genero)
);

CREATE TABLE clasificacion (
    id_clasificacion INT IDENTITY(1,1) NOT NULL,
    clasificacion VARCHAR(10),
    CONSTRAINT PK_clasificacion PRIMARY KEY (id_clasificacion)
);

CREATE TABLE estado_pelicula (
    id_estado_peli INT IDENTITY(1,1) NOT NULL,
    estado_pelicula VARCHAR(50),
    CONSTRAINT PK_estado_pelicula PRIMARY KEY (id_estado_peli)
);

CREATE TABLE formatos (
    id_formato INT IDENTITY(1,1) NOT NULL,
    formato VARCHAR(20),
    CONSTRAINT PK_formatos PRIMARY KEY (id_formato)
);

CREATE TABLE tipos_proyeccion (
    id_tipo_proyeccion INT IDENTITY(1,1) NOT NULL,
    tipo_proyeccion VARCHAR(20),
    CONSTRAINT PK_tipos_proyeccion PRIMARY KEY (id_tipo_proyeccion)
);

CREATE TABLE idiomas (
    id_idioma INT IDENTITY(1,1) NOT NULL,
    idioma VARCHAR(20),
    CONSTRAINT PK_idiomas PRIMARY KEY (id_idioma)
);

CREATE TABLE estados_compra (
    id_estado_compra INT IDENTITY(1,1) NOT NULL,
    descripcion VARCHAR(50),
    CONSTRAINT PK_estados_compra PRIMARY KEY (id_estado_compra)
);

CREATE TABLE forma_compra (
    id_forma_compra INT IDENTITY(1,1) NOT NULL,
    forma_compra VARCHAR(30),
    CONSTRAINT PK_forma_compra PRIMARY KEY (id_forma_compra)
);

CREATE TABLE condiciones (
    id_condicion INT IDENTITY(1,1) NOT NULL,
    descripcion VARCHAR(100),
    CONSTRAINT PK_condiciones PRIMARY KEY (id_condicion)
);

CREATE TABLE tipos_cliente (
    id_tipo_cliente INT IDENTITY(1,1) NOT NULL,
    tipo_cliente VARCHAR(30),
    CONSTRAINT PK_tipos_cliente PRIMARY KEY (id_tipo_cliente)
);

CREATE TABLE barrios (
    id_barrio INT IDENTITY(1,1) NOT NULL,
    descripcion VARCHAR(60),
    CONSTRAINT PK_barrios PRIMARY KEY (id_barrio)
);

CREATE TABLE tipos_contacto (
    id_tipo_contacto INT IDENTITY(1,1) NOT NULL,
    descripcion VARCHAR(30),
    CONSTRAINT PK_tipos_contacto PRIMARY KEY (id_tipo_contacto)
);

-- TABLAS PRINCIPALES

CREATE TABLE consumibles (
    id_consumible INT IDENTITY(1,1) NOT NULL,
    id_categoria INT NOT NULL,
    nom_consumible VARCHAR(80),
    id_marca INT NOT NULL,
    pre_unitario INT,
    CONSTRAINT PK_consumibles PRIMARY KEY (id_consumible),
    CONSTRAINT FK_consumibles_categoria FOREIGN KEY (id_categoria) REFERENCES categorias(id_categoria),
    CONSTRAINT FK_consumibles_marca FOREIGN KEY (id_marca) REFERENCES marcas(id_marca)
);

CREATE TABLE combos (
    id_combo INT IDENTITY(1,1) NOT NULL,
    nom_combo VARCHAR(60),
    CONSTRAINT PK_combos PRIMARY KEY (id_combo)
);

CREATE TABLE detalles_combo (
    id_detalle INT IDENTITY(1,1) NOT NULL,
    id_combo INT NOT NULL,
    id_consumible INT NOT NULL,
    cantidad INT,
    pre_unitario INT,
    CONSTRAINT PK_detalles_combo PRIMARY KEY (id_detalle),
    CONSTRAINT FK_detalles_combo_combo FOREIGN KEY (id_combo) REFERENCES combos(id_combo),
    CONSTRAINT FK_detalles_combo_consumible FOREIGN KEY (id_consumible) REFERENCES consumibles(id_consumible)
);

CREATE TABLE peliculas (
    id_pelicula INT IDENTITY(1,1) NOT NULL,
    nom_pelicula VARCHAR(100),
    id_genero INT NOT NULL,
    id_clasificacion INT NOT NULL,
    id_estado_peli INT NOT NULL,
    CONSTRAINT PK_peliculas PRIMARY KEY (id_pelicula),
    CONSTRAINT FK_peliculas_genero FOREIGN KEY (id_genero) REFERENCES generos(id_genero),
    CONSTRAINT FK_peliculas_clasificacion FOREIGN KEY (id_clasificacion) REFERENCES clasificacion(id_clasificacion),
    CONSTRAINT FK_peliculas_estado FOREIGN KEY (id_estado_peli) REFERENCES estado_pelicula(id_estado_peli)
);

CREATE TABLE salas (
    id_sala INT IDENTITY(1,1) NOT NULL,
    nom_sala VARCHAR(40),
    cant_butacas INT,
    CONSTRAINT PK_salas PRIMARY KEY (id_sala)
);

CREATE TABLE butacas (
    id_butaca INT IDENTITY(1,1) NOT NULL,
    num_butaca INT,
    fila_butaca VARCHAR(2),
    activa BIT,
    CONSTRAINT PK_butacas PRIMARY KEY (id_butaca)
);

CREATE TABLE sala_butacas (
    id_sala_butacas INT IDENTITY(1,1) NOT NULL,
    id_butaca INT NOT NULL,
    id_sala INT NOT NULL,
    CONSTRAINT PK_sala_butacas PRIMARY KEY (id_sala_butacas),
    CONSTRAINT FK_sala_butacas_butaca FOREIGN KEY (id_butaca) REFERENCES butacas(id_butaca),
    CONSTRAINT FK_sala_butacas_sala FOREIGN KEY (id_sala) REFERENCES salas(id_sala)
);

CREATE TABLE funciones (
    id_funcion INT IDENTITY(1,1) NOT NULL,
    id_pelicula INT NOT NULL,
    horario DATETIME,
    id_tipo_proyeccion INT NOT NULL,
    id_sala INT NOT NULL,
    id_formato INT NOT NULL,
    id_idioma INT NOT NULL,
    CONSTRAINT PK_funciones PRIMARY KEY (id_funcion),
    CONSTRAINT FK_funciones_pelicula FOREIGN KEY (id_pelicula) REFERENCES peliculas(id_pelicula),
    CONSTRAINT FK_funciones_tipo_proyeccion FOREIGN KEY (id_tipo_proyeccion) REFERENCES tipos_proyeccion(id_tipo_proyeccion),
    CONSTRAINT FK_funciones_sala FOREIGN KEY (id_sala) REFERENCES salas(id_sala),
    CONSTRAINT FK_funciones_formato FOREIGN KEY (id_formato) REFERENCES formatos(id_formato),
    CONSTRAINT FK_funciones_idioma FOREIGN KEY (id_idioma) REFERENCES idiomas(id_idioma)
);

CREATE TABLE promociones (
    id_promocion INT IDENTITY(1,1) NOT NULL,
    descripcion VARCHAR(120),
    vigencia_desde DATE,
    vigencia_hasta DATE,
    valor_descuento DECIMAL(6,2),
    activo BIT,
    id_tipo_promo INT NOT NULL,
    CONSTRAINT PK_promociones PRIMARY KEY (id_promocion),
    CONSTRAINT FK_promociones_tipo FOREIGN KEY (id_tipo_promo) REFERENCES tipos_promocion(id_tipo_promo)
);

CREATE TABLE entradas (
    id_entrada INT IDENTITY(1,1) NOT NULL,
    id_funcion INT NOT NULL,
    id_butaca INT NOT NULL,
    CONSTRAINT PK_entradas PRIMARY KEY (id_entrada),
    CONSTRAINT FK_entradas_funcion FOREIGN KEY (id_funcion) REFERENCES funciones(id_funcion),
    CONSTRAINT FK_entradas_butaca FOREIGN KEY (id_butaca) REFERENCES butacas(id_butaca)
);

CREATE TABLE promociones_entradas (
    id_promo_entrada INT IDENTITY(1,1) NOT NULL,
    id_promocion INT NOT NULL,
    id_tipo_proyeccion INT NOT NULL,
    CONSTRAINT PK_promociones_entradas PRIMARY KEY (id_promo_entrada),
    CONSTRAINT FK_promociones_entradas_promocion FOREIGN KEY (id_promocion) REFERENCES promociones(id_promocion),
    CONSTRAINT FK_promociones_entradas_tipo_proyeccion FOREIGN KEY (id_tipo_proyeccion) REFERENCES tipos_proyeccion(id_tipo_proyeccion)
);

CREATE TABLE promociones_condiciones (
    id_promo_cond INT IDENTITY(1,1) NOT NULL,
    id_promocion INT NOT NULL,
    id_condicion INT NOT NULL,
    CONSTRAINT PK_promociones_condiciones PRIMARY KEY (id_promo_cond),
    CONSTRAINT FK_promociones_condiciones_promocion FOREIGN KEY (id_promocion) REFERENCES promociones(id_promocion),
    CONSTRAINT FK_promociones_condiciones_condicion FOREIGN KEY (id_condicion) REFERENCES condiciones(id_condicion)
);

CREATE TABLE medios_pago (
    id_medio_pago INT IDENTITY(1,1) NOT NULL,
    medio_pago VARCHAR(40),
    CONSTRAINT PK_medios_pago PRIMARY KEY (id_medio_pago)
);

CREATE TABLE contactos (
    id_contacto INT IDENTITY(1,1) NOT NULL,
    descripcion VARCHAR(50),
    id_tipo_contacto INT NOT NULL,
    CONSTRAINT PK_contactos PRIMARY KEY (id_contacto),
    CONSTRAINT FK_contactos_tipo FOREIGN KEY (id_tipo_contacto) REFERENCES tipos_contacto(id_tipo_contacto)
);

CREATE TABLE roles (
    id_rol INT IDENTITY (1,1) NOT NULL,
    descripcion VARCHAR(20) NOT NULL,
    CONSTRAINT PK_roles PRIMARY KEY (id_rol)
);

CREATE TABLE clientes (
    id_cliente INT IDENTITY(1,1) NOT NULL,
    dni_cliente varchar(8) not null,
    nom_cliente VARCHAR(80),
    ape_cliente VARCHAR(40),
    id_tipo_cliente INT NOT NULL,
    id_barrio INT NOT NULL,
    id_contacto INT NOT NULL,
    activo bit not null,
    CONSTRAINT PK_clientes PRIMARY KEY (id_cliente),
    CONSTRAINT FK_clientes_tipo FOREIGN KEY (id_tipo_cliente) REFERENCES tipos_cliente(id_tipo_cliente),
    CONSTRAINT FK_clientes_barrio FOREIGN KEY (id_barrio) REFERENCES barrios(id_barrio),
    CONSTRAINT FK_clientes_contacto FOREIGN KEY (id_contacto) REFERENCES contactos(id_contacto)
);

CREATE TABLE empleados (
    id_empleado INT IDENTITY(1,1) NOT NULL,
    dni_empleado varchar(8) not null,
    nom_empleado VARCHAR(80),
    ape_empleado VARCHAR(40),
	usuario VARCHAR(30) not null,
	contrasenia VARCHAR(30) not null,
    id_barrio INT NOT NULL,
    id_contacto INT NOT NULL,
    id_rol INT NOT NULL,
    activo bit not null,
    CONSTRAINT PK_empleados PRIMARY KEY (id_empleado),
    CONSTRAINT FK_empleados_barrio FOREIGN KEY (id_barrio) REFERENCES barrios(id_barrio),
    CONSTRAINT FK_empleados_contacto FOREIGN KEY (id_contacto) REFERENCES contactos(id_contacto),
    CONSTRAINT FK_empleados_roles FOREIGN KEY (id_rol) REFERENCES roles(id_rol)
);

CREATE TABLE facturas (
    id_factura INT IDENTITY(1,1) NOT NULL,
    id_cliente INT NOT NULL,
    id_empleado INT NOT NULL,
    fecha DATETIME,
    id_medio_pago INT NOT NULL,
    id_estado_compra INT NOT NULL,
    id_forma_compra INT NOT NULL,
    activo bit not null,
    CONSTRAINT PK_facturas PRIMARY KEY (id_factura),
    CONSTRAINT FK_facturas_cliente FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
    CONSTRAINT FK_facturas_empleado FOREIGN KEY (id_empleado) REFERENCES empleados(id_empleado),
    CONSTRAINT FK_facturas_medio_pago FOREIGN KEY (id_medio_pago) REFERENCES medios_pago(id_medio_pago),
    CONSTRAINT FK_facturas_estado_compra FOREIGN KEY (id_estado_compra) REFERENCES estados_compra(id_estado_compra),
    CONSTRAINT FK_facturas_forma_compra FOREIGN KEY (id_forma_compra) REFERENCES forma_compra(id_forma_compra)
);

CREATE TABLE detalles_factura (
    id_detalle INT IDENTITY(1,1) NOT NULL,
    id_factura INT NOT NULL,
    precio FLOAT,
    id_consumible INT NULL,
    id_combo INT NULL,
    id_entrada INT NULL,
    id_promocion INT NULL,
    CONSTRAINT PK_detalles_factura PRIMARY KEY (id_detalle),
    CONSTRAINT FK_detalles_factura_factura FOREIGN KEY (id_factura) REFERENCES facturas(id_factura),
    CONSTRAINT FK_detalles_factura_consumible FOREIGN KEY (id_consumible) REFERENCES consumibles(id_consumible),
    CONSTRAINT FK_detalles_factura_combo FOREIGN KEY (id_combo) REFERENCES combos(id_combo),
    CONSTRAINT FK_detalles_factura_entrada FOREIGN KEY (id_entrada) REFERENCES entradas(id_entrada),
    CONSTRAINT FK_detalles_factura_promocion FOREIGN KEY (id_promocion) REFERENCES promociones(id_promocion)
);