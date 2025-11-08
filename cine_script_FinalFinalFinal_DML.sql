-- CATEGORIAS
INSERT INTO categorias (categoria) VALUES
('Gaseosa'), ('Snack Salado'), ('Golosina'), ('Combo'), ('Bebida Caliente'), ('Bebida Alcohólica (Cerveza)');
GO

-- MARCAS
INSERT INTO marcas (marca) VALUES
('Coca-Cola'), ('Pepsi'), ('Pringles'), ('Arcor'), ('Nestlé'),
('Cinemark (Propia)'), ('Lays'), ('Fanta'), ('Sprite'), ('KitKat'),
('M&Ms'), ('Milka'), ('Cadbury'), ('Bon o Bon'), ('Oreo'),
('Twix'), ('Snickers'), ('Mars'), ('Kinder'), ('Heineken');
GO

-- TIPOS DE PROMOCION
INSERT INTO tipos_promocion (nombre) VALUES 
('Descuento %'), ('Monto fijo'), ('Combo'), ('Promoción semanal'), ('Día especial'), 
('Descuento socio'), ('Descuento por edad');
GO

-- GENEROS
INSERT INTO generos (genero) VALUES
('Acción'), ('Comedia'), ('Drama'), ('Ciencia Ficción'), ('Terror'),
('Animación'), ('Aventura'), ('Documental'), ('Musical'), ('Romance'),
('Thriller'), ('Fantasía'), ('Misterio'), ('Crimen'), ('Western'),
('Biografía'), ('Guerra'), ('Histórica'), ('Superhéroe'), ('Infantil');
GO

-- CLASIFICACION
INSERT INTO clasificacion (clasificacion) VALUES 
('ATP'), ('7+'), ('13+'), ('16+'), ('18+');
GO

-- ESTADOS DE LAS PELICULAS
INSERT INTO estado_pelicula (estado_pelicula) VALUES
('Estreno'), ('En cartelera'), ('Próximamente');
GO

-- FORMATOS DE PELICULAS
INSERT INTO formatos (formato) VALUES 
('Subtitulada'), ('Doblada');
GO

-- PROYECCIONES
INSERT INTO tipos_proyeccion (tipo_proyeccion) VALUES 
('2D'), ('3D');
GO

-- IDIOMAS
INSERT INTO idiomas (idioma) VALUES 
('Español'), ('Inglés'), ('Francés'), ('Italiano'), ('Alemán'), 
('Mandarín'), ('Portugués'), ('Japonés'), ('Coreano');
GO

-- ESTADOS DE COMPRA
INSERT INTO estados_compra (descripcion) VALUES
('Aprobada'), ('Pendiente de Pago'), ('Rechazada'), ('Cancelada'), ('Reembolsada');
GO

-- FORMAS DE COMPRA
INSERT INTO forma_compra (forma_compra) VALUES
('Online (Web)'), ('Online (App)'), ('Boletería (Presencial)'), ('Terminal de Autoservicio');
GO

-- CONDICIONES
INSERT INTO condiciones (descripcion) VALUES
('Válido Lunes y Martes'), ('Válido solo con Tarjeta Santander'), ('Válido solo compras online'), ('No acumulable con otras promociones'),
('Válido solo con Tarjeta Galicia'), ('Exclusivo Socios CineFan'), ('2x1 Clarin 365'), ('2x1 Club La Nacion'),
('Presentando DNI Estudiantil'), ('Presentando Carnet Jubilado'), ('Válido solo en Salas 4D'), ('Válido solo en Salas IMAX'),
('Exclusivo App Móvil'), ('Pagando con MODO'), ('Pagando con Mercado Pago'), ('Solo funciones de trasnoche'),
('No válido para estrenos'), ('Válido solo para funciones dobladas'), ('Compra mínima $5000'), ('Válido en combo mediano');
GO

-- TIPOS DE CLIENTES
INSERT INTO tipos_cliente (tipo_cliente) VALUES 
('Frecuente'), ('Ocasional'), ('Socio'), ('Menor');
GO

-- BARRIOS
INSERT INTO barrios (descripcion) VALUES
('Alberdi'), ('Alta Córdoba'), ('Alto Verde'), ('Jardín'), ('Nueva Córdoba'),
('Argüello'), ('Bella vista'), ('Centro'), ('Chateau Carreras'), ('Cofico'),
('General Arenales'), ('General Paz'), ('Güemes'), ('Observatorio'), ('San Vicente'),
('San Francisco'), ('Providencia'), ('Poeta Lugones'), ('Ferreira'), ('Bajo Palermo');
GO

-- TIPOS DE CONTACTO
INSERT INTO tipos_contacto (descripcion) VALUES
('Email'), ('Teléfono Celular');
GO

-- CONSUMIBLES
INSERT INTO consumibles (id_categoria, nom_consumible, id_marca, pre_unitario) VALUES
(1, 'Coca-Cola 500ml', 1, 1800), (1, 'Agua Mineral 500ml', 1, 1500), (2, 'Pochoclo Salado (Mediano)', 6, 2500),
(2, 'Pochoclo Dulce (Grande)', 6, 3000), (2, 'Nachos con Queso', 6, 2800), (2, 'Pringles Originales', 3, 2200),
(3, 'Chocolate Cofler', 4, 1200), (1, 'Pepsi 500ml', 2, 1800), (1, 'Fanta 500ml', 8, 1750), (1, 'Sprite 500ml', 9, 1750),
(2, 'Lays Clásicas 100g', 7, 1600), (3, 'KitKat 40g', 5, 1300), (3, 'M&Ms 50g', 11, 1400), (3, 'Milka Oreo 100g', 12, 1900),
(3, 'Bon o Bon 30g', 4, 800), (3, 'Oreo 110g', 15, 1000), (5, 'Café Espresso', 5, 1100), (5, 'Té (Varios sabores)', 5, 900),
(6, 'Cerveza Heineken 473ml', 20, 2100), (2, 'Papas Fritas (Snack)', 6, 2000);
GO

-- COMBOS
INSERT INTO combos (nom_combo) VALUES
('Combo Pareja (2 Gaseosas G + Pochoclo G)'), ('Combo Individual (1 Gaseosa M + Pochoclo M)'), ('Combo Nachos (Nachos + Gaseosa G)'),
('Combo Amigos (4 Gaseosas M + 2 Pochoclos G)'), ('Combo Kids (Gaseosa S + Pochoclo S + Juguete)'), ('Combo Hot Dog (Pancho + Gaseosa M)'),
('Combo Café (Café + 2 Medialunas)'), ('Combo Cerveza (2 Cervezas + Papas)'), ('Combo Saludable (Agua + Ensalada)'),
('Combo Familiar (2G + 2M + Pochoclo G + Golosina)'), ('Combo Película (Vaso Película + Gaseosa G)'), ('Combo Socio (Upgrade Gaseosa + Pochoclo M)'),
('Combo Estudiante (Gaseosa M + Pochoclo M)'), ('Combo Jubilado (Café + Porción Torta)'), ('Combo 2x1 Nachos'),
('Combo Recarga Pochoclo'), ('Combo Recarga Gaseosa'), ('Combo Mixto (Pochoclo Salado/Dulce G + 2 Gaseosas G)'),
('Combo Golosinas (3 Golosinas a elección)'), ('Combo IMAX (Pochoclo G + Gaseosa G + Lentes 3D)');
GO

-- DETALLES_COMBO
INSERT INTO detalles_combo (id_combo, id_consumible, cantidad, pre_unitario) VALUES
(1, 1, 2, 1700), (1, 4, 1, 2900), -- Combo Pareja (2 Coca, 1 Pochoclo G)
(2, 1, 1, 1700), (2, 3, 1, 2400), -- Combo Individual (1 Coca, 1 Pochoclo M)
(3, 1, 1, 1700), (3, 5, 1, 2700), -- Combo Nachos (1 Coca, 1 Nachos)
(4, 1, 4, 1700), (4, 4, 2, 2900), -- Combo Amigos
(5, 1, 1, 1500), (5, 3, 1, 2000), -- Combo Kids
(6, 1, 1, 1700), (6, 20, 1, 1900), -- Combo Hot Dog (Coca + Pancho (usamos ID papas como placeholder))
(7, 17, 1, 1100), (7, 18, 2, 450), -- Combo Café (Café + 2 Tés (usamos Tés como medialunas))
(8, 19, 2, 2100), (8, 20, 1, 2000), -- Combo Cerveza (2 Cervezas + Papas)
(9, 2, 1, 1500), (9, 20, 1, 2000), -- Combo Saludable (Agua + Papas (ensalada placeholder))
(10, 1, 2, 1700), (10, 3, 1, 2400), (10, 7, 1, 1200), -- Combo Familiar
(11, 1, 1, 1800), (11, 3, 1, 2500), -- Combo Película
(12, 1, 1, 1800), (12, 3, 1, 2500), -- Combo Socio
(13, 1, 1, 1800), (13, 3, 1, 2500), -- Combo Estudiante
(14, 17, 1, 1100), (14, 7, 1, 1200), -- Combo Jubilado
(15, 5, 2, 2800), (15, 1, 1, 0), -- Combo 2x1 Nachos
(16, 3, 1, 2000), (16, 4, 0, 0), -- Combo Recarga Pochoclo
(17, 1, 1, 1200), (17, 1, 0, 0), -- Combo Recarga Gaseosa
(18, 4, 1, 3000), (18, 1, 2, 1800), -- Combo Mixto
(19, 7, 1, 1200), (19, 12, 1, 1300), (19, 15, 1, 800), -- Combo Golosinas
(20, 4, 1, 3000), (20, 1, 1, 1800); -- Combo IMAX
GO

-- PELICULAS
INSERT INTO peliculas (nom_pelicula, id_genero, id_clasificacion, id_estado_peli) VALUES
('Barbie', 2, 2, 2), -- PG
('Oppenheimer', 16, 4, 2), -- R
('The Super Mario Bros. Movie', 6, 1, 2), -- G
('Guardians of the Galaxy Vol. 3', 19, 3, 2), -- PG-13
('Fast X', 1, 3, 2), -- PG-13
('Spider-Man: Across the Spider-Verse', 6, 2, 2), -- PG
('Wonka', 10, 2, 2), -- PG
('Mission: Impossible – Dead Reckoning Part One', 1, 3, 2), -- PG-13
('John Wick: Chapter 4', 1, 4, 2), -- R
('Dune: Part Two', 4, 3, 1), -- PG-13
('Inside Out 2', 6, 1, 1), -- G
('Deadpool & Wolverine', 19, 4, 1), -- R
('Godzilla x Kong: The New Empire', 1, 3, 2), -- PG-13
('Kung Fu Panda 4', 6, 2, 2), -- PG
('Kingdom of the Planet of the Apes', 4, 3, 2), -- PG-13
('A Quiet Place: Day One', 5, 3, 1), -- PG-13
('The Garfield Movie', 6, 1, 2), -- G
('Beetlejuice Beetlejuice', 12, 3, 1), -- PG-13
('Gladiator 2', 1, 4, 3), -- R (Próximamente)
('Wicked', 12, 2, 3); -- PG (Próximamente)
GO

-- SALAS
INSERT INTO salas (nom_sala, cant_butacas) VALUES
('Sala 01 - 2D', 150), 
('Sala 02 - 2D', 150), 
('Sala 03 - 2D', 120), 
('Sala 04 - 2D', 120), 
('Sala 05 - 3D', 200),
('Sala 06 - 3D', 200), 
('Sala 07 - 2D', 80), 
('Sala 08 - 2D', 250), 
('Sala 09 - 3D', 100), 
('Sala 10 - 2D', 130),
('Sala 11 - 2D', 90), 
('Sala 12 - 2D', 90), 
('Sala 13 - 3D', 110), 
('Sala 14 - 2D', 150), 
('Sala 15 - 2D', 150),
('Sala 16 - 3D', 200), 
('Sala 17 - 2D', 80), 
('Sala 18 - 2D', 120), 
('Sala 19 - 2D', 120), 
('Sala 20 - 3D', 100);
GO

-- BUTACAS
INSERT INTO butacas (num_butaca, fila_butaca, activa) VALUES
(1, 'A', 1), (2, 'A', 1), (3, 'A', 1), (4, 'A', 1), (5, 'A', 1),
(6, 'A', 1), (7, 'A', 1), (8, 'A', 1), (9, 'A', 1), (10, 'A', 1),
(1, 'B', 1), (2, 'B', 1), (3, 'B', 1), (4, 'B', 1), (5, 'B', 1),
(6, 'B', 1), (7, 'B', 1), (8, 'B', 1), (9, 'B', 1), (10, 'B', 1),
(1, 'C', 1), (2, 'C', 1), (3, 'C', 1), (4, 'C', 1), (5, 'C', 1),
(6, 'C', 1), (7, 'C', 1), (8, 'C', 1), (9, 'C', 1), (10, 'C', 1),
(1, 'D', 1), (2, 'D', 1), (3, 'D', 1), (4, 'D', 1), (5, 'D', 1),
(6, 'D', 1), (7, 'D', 1), (8, 'D', 1), (9, 'D', 1), (10, 'D', 1),
(1, 'E', 1), (2, 'E', 1), (3, 'E', 1), (4, 'E', 1), (5, 'E', 1),
(6, 'E', 1), (7, 'E', 1), (8, 'E', 1), (9, 'E', 1), (10, 'E', 1),
(1, 'F', 1), (2, 'F', 1), (3, 'F', 1), (4, 'F', 1), (5, 'F', 1),
(6, 'F', 1), (7, 'F', 1), (8, 'F', 1), (9, 'F', 1), (10, 'F', 1),
(1, 'G', 1), (2, 'G', 1), (3, 'G', 1), (4, 'G', 1), (5, 'G', 1),
(6, 'G', 1), (7, 'G', 1), (8, 'G', 1), (9, 'G', 1), (10, 'G', 1),
(1, 'H', 1), (2, 'H', 1), (3, 'H', 1), (4, 'H', 1), (5, 'H', 1),
(6, 'H', 1), (7, 'H', 1), (8, 'H', 1), (9, 'H', 1), (10, 'H', 1),
(1, 'I', 1), (2, 'I', 1), (3, 'I', 1), (4, 'I', 1), (5, 'I', 1),
(6, 'I', 1), (7, 'I', 1), (8, 'I', 1), (9, 'I', 1), (10, 'I', 1),
(1, 'J', 1), (2, 'J', 1), (3, 'J', 1), (4, 'J', 1), (5, 'J', 1),
(6, 'J', 1), (7, 'J', 1), (8, 'J', 1), (9, 'J', 1), (10, 'J', 1);
GO

-- SALA_BUTACAS
INSERT INTO sala_butacas (id_butaca, id_sala) VALUES
(1, 1), (11, 1), (21, 1), (31, 1), (41, 1), -- Sala 1
(2, 2), (12, 2), (22, 2), (32, 2), (42, 2), -- Sala 2
(3, 3), (13, 3), (23, 3), (33, 3), (43, 3), -- Sala 3
(4, 4), (14, 4), (24, 4), (34, 4), (44, 4), -- Sala 4
(5, 5), (15, 5), (25, 5), (35, 5), (45, 5), -- Sala 5
(6, 6), (16, 6), (26, 6), (36, 6), (46, 6), -- Sala 6
(7, 7), (17, 7), (27, 7), (37, 7), (47, 7), -- Sala 7
(8, 8), (18, 8), (28, 8), (38, 8), (48, 8), -- Sala 8
(9, 9), (19, 9), (29, 9), (39, 9), (49, 9), -- Sala 9
(10, 10), (20, 10), (30, 10), (40, 10), (50, 10), -- Sala 10
(51, 11), (61, 11), (71, 11), (81, 11), (91, 11), -- Sala 11
(52, 12), (62, 12), (72, 12), (82, 12), (92, 12), -- Sala 12
(53, 13), (63, 13), (73, 13), (83, 13), (93, 13), -- Sala 13
(54, 14), (64, 14), (74, 14), (84, 14), (94, 14), -- Sala 14
(55, 15), (65, 15), (75, 15), (85, 15), (95, 15), -- Sala 15
(56, 16), (66, 16), (76, 16), (86, 16), (96, 16), -- Sala 16
(57, 17), (67, 17), (77, 17), (87, 17), (97, 17), -- Sala 17
(58, 18), (68, 18), (78, 18), (88, 18), (98, 18), -- Sala 18
(59, 19), (69, 19), (79, 19), (89, 19), (99, 19), -- Sala 19
(60, 20), (70, 20), (80, 20), (90, 20), (100, 20); -- Sala 20
GO

-- 20 FUNCIONES
INSERT INTO funciones (id_pelicula, horario, id_tipo_proyeccion, id_sala, id_formato, id_idioma, precio) VALUES
(1, '2025-10-21 18:00:00', 1, 1, 1, 1,1200), -- Barbie, Sala 1 (2D), Doblada, Español
(2, '2025-10-21 17:30:00', 2, 8, 2, 2,1200), -- Oppenheimer, Sala 8 (IMAX), Subtitulada, Inglés
(3, '2025-10-21 16:00:00', 2, 5, 1, 1,1200), -- Super Mario, Sala 5 (3D), Doblada, Español
(4, '2025-10-21 19:00:00', 1, 9, 2, 2,1200), -- Guardians 3, Sala 9 (D-BOX), Subtitulada, Inglés
(5, '2025-10-21 22:00:00', 1, 2, 2, 2,1200), -- Fast X, Sala 2 (2D), Subtitulada, Inglés
(6, '2025-10-21 18:30:00', 2, 6, 1, 1,1200), -- Spider-Verse, Sala 6 (3D), Doblada, Español
(7, '2025-10-21 17:00:00', 1, 3, 1, 1,1200), -- Wonka, Sala 3 (2D), Doblada, Español
(8, '2025-10-21 21:30:00', 1, 8, 2, 2,1200), -- Mission Impossible, Sala 8 (IMAX), Subtitulada, Inglés
(9, '2025-10-21 22:30:00', 1, 4, 2, 2,1200), -- John Wick 4, Sala 4 (2D), Subtitulada, Inglés
(10, '2025-10-21 20:00:00', 2, 7, 2, 2,1200), -- Dune 2, Sala 7 (4D), Subtitulada, Inglés
(11, '2025-10-21 15:00:00', 1, 11, 1, 1,1200), -- Inside Out 2, Sala 11 (2D Comfort), Doblada, Español
(12, '2025-10-21 22:15:00', 1, 12, 2, 2,1200), -- Deadpool 3, Sala 12 (2D Comfort), Subtitulada, Inglés
(13, '2025-10-21 19:45:00', 2, 13, 2, 2,1200), -- Godzilla x Kong, Sala 13 (3D Comfort), Subtitulada, Inglés
(14, '2025-10-21 16:30:00', 1, 14, 1, 1,1200), -- Kung Fu Panda 4, Sala 14 (2D), Doblada, Español
(15, '2025-10-21 20:30:00', 1, 15, 2, 2,1200), -- Planet of the Apes, Sala 15 (2D), Subtitulada, Inglés
(16, '2025-10-21 22:45:00', 1, 18, 2, 2,1200), -- A Quiet Place, Sala 18 (2D), Subtitulada, Inglés
(17, '2025-10-21 15:30:00', 1, 19, 1, 1,1200), -- Garfield, Sala 19 (2D), Doblada, Español
(18, '2025-10-21 21:00:00', 2, 20, 2, 2,1200), -- Beetlejuice 2, Sala 20 (D-BOX), Subtitulada, Inglés
(1, '2025-10-21 20:45:00', 1, 1, 1, 1,1200), -- Barbie (Otra función), Sala 1 (2D), Doblada, Español
(10, '2025-10-21 23:00:00', 2, 7, 2, 2,1200); -- Dune 2 (Trasnoche), Sala 7 (4D), Subtitulada, Inglés
GO

-- PROMOCIONES
INSERT INTO promociones (descripcion, vigencia_desde, vigencia_hasta, valor_descuento, activo, id_tipo_promo) VALUES
('25% OFF Santander', '2025-01-01', '2025-12-31', 25.00, 1, 1),
('2x1 Lunes y Martes', '2025-01-01', '2025-12-31', 0, 1, 2),
('Promo App 10% OFF', '2025-06-01', '2025-11-30', 10.00, 1, 1),
('2x1 Clarin 365', '2025-01-01', '2025-12-31', 0, 1, 2),
('2x1 Club La Nacion', '2025-01-01', '2025-12-31', 0, 1, 2),
('Descuento Estudiante (Jueves)', '2025-03-01', '2025-12-15', 30.00, 1, 1),
('Descuento Jubilado (Diario)', '2025-01-01', '2025-12-31', 40.00, 1, 1),
('$1000 Descuento MODO', '2025-10-01', '2025-10-31', 1000.00, 1, 3),
('Combo Especial "Dune 2"', '2025-03-01', '2025-04-01', 0, 0, 4), -- Inactiva
('Combo "Inside Out 2" Familiar', '2025-06-15', '2025-08-15', 0, 1, 4),
('15% OFF Tarjeta Galicia', '2025-01-01', '2025-12-31', 15.00, 1, 1),
('500 Puntos CineFan Bienvenida', '2025-01-01', '2025-12-31', 500, 1, 5),
('Upgrade Pochoclo Socio CineFan', '2025-01-01', '2025-12-31', 0, 1, 5),
('20% OFF Salas 4D (Miércoles)', '2025-01-01', '2025-12-31', 20.00, 1, 1),
('10% OFF Trasnoche (Viernes y Sábado)', '2025-01-01', '2025-12-31', 10.00, 1, 1),
('2x1 Salas IMAX (Martes)', '2025-01-01', '2025-12-31', 0, 1, 2),
('20% OFF Pagando con NaranjaX', '2025-10-01', '2025-11-30', 20.00, 1, 1),
('Recarga Combo Lunes', '2025-01-01', '2025-12-31', 0, 1, 4),
('10% OFF Compra Web (No Socios)', '2025-01-01', '2025-12-31', 10.00, 1, 1),
('$2000 Descuento AMEX', '2025-11-01', '2025-11-30', 2000.00, 1, 3);
GO

-- 40 ENTRADAS PARA 20 FUNCIONES
INSERT INTO entradas (id_funcion, id_butaca) VALUES
(1, 1), (1, 11), -- F1 (Barbie): Butacas A1, B1 (Sala 1)
(2, 8), (2, 18), -- F2 (Oppenheimer): Butacas A8, B8 (Sala 8)
(3, 5), (3, 15), -- F3 (Mario): Butacas A5, B5 (Sala 5)
(4, 9), (4, 19), -- F4 (Guardians): Butacas A9, B9 (Sala 9)
(5, 2), (5, 12), -- F5 (Fast X): Butacas A2, B2 (Sala 2)
(6, 6), (6, 16), -- F6 (Spider-Verse): Butacas A6, B6 (Sala 6)
(7, 3), (7, 13), -- F7 (Wonka): Butacas A3, B3 (Sala 3)
(8, 28), (8, 38), -- F8 (Mission Imp): Butacas C8, D8 (Sala 8)
(9, 4), (9, 14), -- F9 (John Wick): Butacas A4, B4 (Sala 4)
(10, 7), (10, 17), -- F10 (Dune 2): Butacas A7, B7 (Sala 7)
(11, 51), (11, 61), -- F11 (Inside Out 2): Butacas F1, G1 (Sala 11)
(12, 52), (12, 62), -- F12 (Deadpool 3): Butacas F2, G2 (Sala 12)
(13, 53), (13, 63), -- F13 (Godzilla): Butacas F3, G3 (Sala 13)
(14, 54), (14, 64), -- F14 (Kung Fu Panda): Butacas F4, G4 (Sala 14)
(15, 55), (15, 65), -- F15 (Planet Apes): Butacas F5, G5 (Sala 15)
(16, 58), (16, 68), -- F16 (Quiet Place): Butacas F8, G8 (Sala 18)
(17, 59), (17, 69), -- F17 (Garfield): Butacas F9, G9 (Sala 19)
(18, 60), (18, 70), -- F18 (Beetlejuice): Butacas F10, G10 (Sala 20)
(19, 21), (19, 31), -- F19 (Barbie 2): Butacas C1, D1 (Sala 1)
(20, 27), (20, 37); -- F20 (Dune 2 2): Butacas C7, D7 (Sala 7)
GO

-- 20 PROMOCIONES_ENTRADAS
INSERT INTO promociones_entradas (id_promocion, id_tipo_proyeccion) VALUES
(1, 1), (1, 2), -- Santander (Todas las proyecciones)
(2, 1), -- 2x1 (Solo 2D)
(3, 1), (3, 2), -- App (Todas)
(6, 1), (6, 2), -- Estudiante (2D y 3D)
(7, 1) -- Jubilado (2D)
GO

-- 20 PROMOCIONES_CONDICIONES
INSERT INTO promociones_condiciones (id_promocion, id_condicion) VALUES
(1, 2), (2, 1), (3, 3), (4, 7), (5, 8), (6, 9), (7, 10), (8, 14), (9, 12), (10, 4),
(11, 5), (12, 6), (13, 6), (14, 11), (15, 16), (16, 12), (17, 3), (18, 1), (19, 3), (20, 3);
GO

-- MEDIOS DE PAGO
INSERT INTO medios_pago (medio_pago) VALUES 
('Tarjeta de crédito'), ('Efectivo'), ('Débito'), ('Transferencia'), ('MercadoPago'), ('Paypal');
GO

-- CONTACTOS
INSERT INTO contactos (descripcion, id_tipo_contacto) VALUES
('juan.perez@email.com', 1), ('1155443322', 2), ('maria.gomez@email.com', 1), ('1166778899', 2), ('ldiaz@email.com', 1),
('ana.fernandez@email.com', 1), ('1122334455', 2), ('msuarez@email.com', 1), ('cgonzalez@email.com', 1), ('1199887766', 2),
('rlopez@email.com', 1), ('lmartinez@email.com', 1), ('dsanchez@email.com', 1), ('fromero@email.com', 1), ('1133445566', 2),
('vtorres@email.com', 1), ('mruiz@email.com', 1), ('jalvarez@email.com', 1), ('gramirez@email.com', 1), ('1165432109', 2),
('csanchez@cine.com', 1), ('ralvarez@cine.com', 1), ('mgutierrez@cine.com', 1), ('jperez@cine.com', 1), ('slopez@cine.com', 1),
('adiaz@cine.com', 1), ('mfernandez@cine.com', 1), ('dgonzalez@cine.com', 1), ('prodriguez@cine.com', 1), ('lgarcia@cine.com', 1),
('efernandez@cine.com', 1), ('jtorres@cine.com', 1), ('vruiz@cine.com', 1), ('hramirez@cine.com', 1), ('nalvarez@cine.com', 1),
('fmoreno@cine.com', 1), ('lgimenez@cine.com', 1), ('sromero@cine.com', 1), ('rcastro@cine.com', 1), ('mmedina@cine.com', 1),
('3884567237',2);
GO

INSERT INTO roles (descripcion) VALUES
('Administrador'), ('Empleado');
GO

-- 20 CLIENTES
INSERT INTO clientes (dni_cliente, nom_cliente, ape_cliente, id_tipo_cliente, id_barrio, id_contacto, activo) VALUES
('44950713','Juan', 'Perez', 2, 1, 1,1), ('12345678','Maria', 'Gomez', 1, 3, 3,1), ('43427843','Lucas', 'Diaz', 1, 2, 5,1), ('13475246','Ana', 'Fernandez', 2, 1, 6,1),
('71420647','Martin', 'Suarez', 1, 5, 8,1), ('20733765','Carla', 'Gonzalez', 3, 7, 9,1), ('23754165','Roberto', 'Lopez', 1, 4, 11,1), ('11427346','Lucia', 'Martinez', 2, 6, 12,1),
('30457214','Diego', 'Sanchez', 4, 10, 13,1), ('71246547','Florencia', 'Romero', 1, 12, 14,1), ('14253678','Valeria', 'Torres', 4, 9, 16,1), ('12045714','Matias', 'Ruiz', 1, 11, 17,1),
('12345679','Jorge', 'Alvarez', 2, 15, 18,1), ('12345675','Gabriela', 'Ramirez', 1, 18, 19,1), ('12345674','Agustin', 'Benitez', 1, 20, 2,1),
('12345670','Sofia', 'Acosta', 2, 1, 4,1), ('12345676','Micaela', 'Medina', 1, 3, 7,1), ('12345673','Pedro', 'Castro', 3, 8, 10,1), ('12345672','Julieta', 'Herrera', 1, 14, 15,1),
('12345677','Pablo', 'Gimenez', 1, 17, 20,1);
GO

-- 21 EMPLEADOS
INSERT INTO empleados (dni_empleado, nom_empleado, ape_empleado, usuario, contrasenia, id_barrio, id_contacto, id_rol, activo) VALUES
('98765432','Carlos', 'Sanchez', 'carlos.sanchez', 'carlos1@2!saN', 7, 21,2,1), 
('98765437','Romina', 'Alvarez', 'romina.alvarez', 'romina2@4!Alv', 8, 22,2,1), 
('88765432','Mariano', 'Gutierrez', 'mariano.gutierrez', 'mariano@76!gUt', 1, 23,2,1), 
('20765432','Javier', 'Perez', 'javier.perez', 'javier3@2!Per', 2, 24,2,1),
('98765433','Silvia', 'Lopez', 'silvia.lopez', 'silvia3@9!lOp', 3, 25,2,1), 
('98765438','Adrian', 'Diaz', 'adrian.diaz', 'adrian8@2!Diz', 5, 26,2,1), 
('78765432','Marcela', 'Fernandez', 'marcela.fernandez', 'marcela@2!Fer', 6, 27,2,1), 
('19765432','Daniel', 'Gonzalez', 'daniel.gonzalez', 'daniel2@2!GoN', 10, 28,2,1),
('98765434','Paola', 'Rodriguez', 'paola.rodriguez', 'paola4@3!roD',11, 29,2,1), 
('98765439','Lucas', 'Garcia', 'lucas.garcia', 'lucas9@3!GAR', 13, 30,2,1), 
('68765432','Esteban', 'Fernandez', 'esteban.fernandez', 'esteban@2!FER', 14, 31,2,1), 
('18765432','Juana', 'Torres', 'juana.torres', 'juana2@3!ToR', 16, 32,2,1),
('98765435','Victor', 'Ruiz', 'victor.ruiz', 'victor@5!RUi', 18, 33,2,1), 
('98765430','Hernan', 'Ramirez', 'hernan.ramirez', 'hernan@03!RaM',19, 34,2,1), 
('58765432','Natalia', 'Alvarez', 'natalia.alvarez', 'natalia@2!ALV', 20, 35,2,1), 
('28765432','Facundo', 'Moreno', 'facundo.moreno', 'facundo@3!Mor', 4, 36,2,1),
('98765436','Lorena', 'Gimenez', 'lorena.gimenez', 'lorena@6!giM', 9, 37,2,1), 
('98765431','Sebastian', 'Romero', 'sebastian.romero', 'sebastian@1!ROM', 12, 38,2,1), 
('48765432','Ricardo', 'Castro', 'ricardo.castro', 'ricardo@5!CaS', 15, 39,2,1), 
('38765432','Monica', 'Medina', 'monica.medina', 'monica@4!MeD', 17, 40,2,1),
('44948403', 'Juan Manuel', 'Torrejón', 'juan.torrejon', 'JuaneteCosmic',20,41,1,1);
GO


-- 20 FACTURAS
INSERT INTO facturas (id_cliente, id_empleado, fecha, id_medio_pago, id_estado_compra, id_forma_compra, activo) VALUES
(1, 1, '2025-10-21 17:30:00', 1, 1, 1,1), -- Cliente 1 (Juan), Empleado 1 (Carlos), Tarjeta de Credito, Aprobada, Web
(2, 1, '2025-10-21 17:00:00', 1, 1, 1,1), -- Cliente 2 (Maria), Empleado 1 (Carlos), Tarjeta de Credito, Aprobada, Web
(3, 2, '2025-10-21 15:30:00', 2, 1, 2,1), -- Cliente 3 (Lucas), Empleado 2 (Romina), Efectivo, Aprobada, App
(4, 2, '2025-10-21 18:30:00', 2, 1, 2,1), -- Cliente 4 (Ana), Empleado 2 (Romina), Efectivo, Aprobada, App
(5, 3, '2025-10-21 21:00:00', 3, 1, 3,1), -- Cliente 5 (Martin), Empleado 3 (Mariano), Débito, Aprobada, Boletería
(6, 3, '2025-10-21 18:00:00', 3, 1, 3,1), -- Cliente 6 (Carla), Empleado 3 (Mariano), Débito, Aprobada, Boletería
(7, 4, '2025-10-21 16:30:00', 4, 1, 4,1), -- Cliente 7 (Roberto), Empleado 4 (Javier), Transferencia, Aprobada, Autoservicio
(8, 4, '2025-10-21 21:00:00', 4, 1, 4,1), -- Cliente 8 (Lucia), Empleado 4 (Javier), Transferencia, Aprobada, Autoservicio
(9, 5, '2025-10-21 22:00:00', 5, 1, 1,1), -- Cliente 9 (Diego), Empleado 5 (Silvia), Mercado Pago, Aprobada, Web
(10, 5, '2025-10-21 19:30:00', 5, 1, 1,1), -- Cliente 10 (Florencia), Empleado 5 (Silvia), Mercado Pago, Aprobada, Web
(11, 6, '2025-10-21 14:30:00', 6, 1, 2,1), -- Cliente 11 (Valeria), Empleado 6 (Adrian), Paypal, Aprobada, App
(12, 6, '2025-10-21 21:45:00', 6, 1, 3,1), -- Cliente 12 (Matias), Empleado 6 (Adrian), Paypal, Aprobada, Boletería
(13, 7, '2025-10-21 19:15:00', 5, 1, 3,1), -- Cliente 13 (Jorge), Empleado 7 (Marcela), Mercado Pago, Aprobada, Boletería
(14, 7, '2025-10-21 16:00:00', 5, 1, 1,1), -- Cliente 14 (Gabriela), Empleado 7 (Marcela), Mercado Pago, Aprobada, Web
(15, 8, '2025-10-21 20:00:00', 4, 1, 3,1), -- Cliente 15 (Agustin), Empleado 8 (Daniel), Transferencia, Aprobada, Boletería
(16, 8, '2025-10-21 22:15:00', 4, 1, 4,1), -- Cliente 16 (Sofia), Empleado 8 (Daniel), Transferencia, Aprobada, Autoservicio
(17, 9, '2025-10-21 15:00:00', 3, 1, 2,1), -- Cliente 17 (Micaela), Empleado 9 (Paola), Débito, Aprobada, App
(18, 9, '2025-10-21 20:30:00', 3, 1, 3,1), -- Cliente 18 (Pedro), Empleado 9 (Paola), Débito, Aprobada, Boletería
(19, 10, '2025-10-21 20:15:00', 2, 1, 1,1), -- Cliente 19 (Julieta), Empleado 10 (Lucas), Efectivo, Aprobada, Web
(20, 10, '2025-10-21 22:30:00', 2, 1, 2,1); -- Cliente 20 (Pablo), Empleado 10 (Lucas), Efectivo, Aprobada, App
GO


-- DETALLES FACTRURA
INSERT INTO detalles_factura (id_factura, precio, id_consumible, id_combo, id_entrada, id_promocion) VALUES
-- Factura 1 (2 Entradas + 1 Combo)
(1, 4000, NULL, NULL, 1, 1), -- Entrada 1 (Barbie) con 25% Santander
(1, 4000, NULL, NULL, 2, 1), -- Entrada 2 (Barbie) con 25% Santander
(1, 6300, NULL, 1, NULL, NULL), -- Combo Pareja
-- Factura 2 (2 Entradas)
(2, 6000, NULL, NULL, 3, NULL), -- Entrada 3 (Oppenheimer)
(2, 6000, NULL, NULL, 4, NULL), -- Entrada 4 (Oppenheimer)
-- Factura 3 (2 Entradas + 2 Consumibles)
(3, 3500, NULL, NULL, 5, 3), -- Entrada 5 (Mario) con 10% App
(3, 3500, NULL, NULL, 6, 3), -- Entrada 6 (Mario) con 10% App
(3, 2500, 3, NULL, NULL, NULL), -- Pochoclo M
(3, 1800, 1, NULL, NULL, NULL), -- Coca-Cola
-- Factura 4 (2 Entradas)
(4, 5000, NULL, NULL, 7, 2), -- Entrada 7 (Guardians) 2x1
(4, 0, NULL, NULL, 8, 2), -- Entrada 8 (Guardians) 2x1 (Gratis)
-- Factura 5 (2 Entradas)
(5, 4000, NULL, NULL, 9, NULL), -- Entrada 9 (Fast X)
(5, 4000, NULL, NULL, 10, NULL), -- Entrada 10 (Fast X)
-- Factura 6 (2 Entradas)
(6, 3500, NULL, NULL, 11, NULL), -- Entrada 11 (Spider-Verse)
(6, 3500, NULL, NULL, 12, NULL), -- Entrada 12 (Spider-Verse)
-- Factura 7 (1 Combo)
(7, 4100, NULL, 2, NULL, NULL), -- Combo Individual
-- Factura 8 (2 Entradas IMAX + Promo MODO)
(8, 6000, NULL, NULL, 13, 8), -- Entrada 13 (Mission Imp) con $1000 MODO
(8, 6000, NULL, NULL, 14, 8), -- Entrada 14 (Mission Imp) con $1000 MODO
-- Factura 9 (2 Entradas)
(9, 4000, NULL, NULL, 15, NULL), -- Entrada 15 (John Wick)
(9, 4000, NULL, NULL, 16, NULL), -- Entrada 16 (John Wick)
-- Factura 10 (2 Entradas 4D + Promo NaranjaX)
(10, 7000, NULL, NULL, 17, 17), -- Entrada 17 (Dune 2) 20% NaranjaX
(10, 7000, NULL, NULL, 18, 17), -- Entrada 18 (Dune 2) 20% NaranjaX
-- Factura 11 (2 Entradas + 1 Consumible)
(11, 3000, NULL, NULL, 19, NULL), -- Entrada 19 (Inside Out 2)
(11, 3000, NULL, NULL, 20, NULL), -- Entrada 20 (Inside Out 2)
(11, 1200, 7, NULL, NULL, NULL), -- Chocolate
-- Factura 12 (2 Entradas)
(12, 4500, NULL, NULL, 21, NULL), -- Entrada 21 (Deadpool 3)
(12, 4500, NULL, NULL, 22, NULL), -- Entrada 22 (Deadpool 3)
-- Factura 13 (2 Entradas)
(13, 5500, NULL, NULL, 23, NULL), -- Entrada 23 (Godzilla)
(13, 5500, NULL, NULL, 24, NULL), -- Entrada 24 (Godzilla)
-- Factura 14 (2 Entradas + Promo Estudiante)
(14, 3000, NULL, NULL, 25, 6), -- Entrada 25 (Kung Fu Panda) 30% Estudiante
(14, 3000, NULL, NULL, 26, 6), -- Entrada 26 (Kung Fu Panda) 30% Estudiante
-- Factura 15 (1 Combo Nachos)
(15, 4400, NULL, 3, NULL, NULL), -- Combo Nachos
-- Factura 16 (2 Entradas + 1 Consumible)
(16, 4000, NULL, NULL, 27, NULL), -- Entrada 27 (Planet Apes)
(16, 4000, NULL, NULL, 28, NULL), -- Entrada 28 (Planet Apes)
(16, 2100, 19, NULL, NULL, NULL), -- Cerveza Heineken
-- Factura 17 (2 Entradas)
(17, 4000, NULL, NULL, 29, NULL), -- Entrada 29 (Quiet Place)
(17, 4000, NULL, NULL, 30, NULL), -- Entrada 30 (Quiet Place)
-- Factura 18 (2 Entradas)
(18, 3000, NULL, NULL, 31, NULL), -- Entrada 31 (Garfield)
(18, 3000, NULL, NULL, 32, NULL), -- Entrada 32 (Garfield)
-- Factura 19 (2 Entradas + Promo AMEX)
(19, 4500, NULL, NULL, 33, 20), -- Entrada 33 (Beetlejuice) $2000 AMEX
(19, 4500, NULL, NULL, 34, 20), -- Entrada 34 (Beetlejuice) $2000 AMEX
-- Factura 20 (2 Entradas 4D + Promo Trasnoche)
(20, 7000, NULL, NULL, 35, 15), -- Entrada 35 (Dune 2) 10% Trasnoche
(20, 7000, NULL, NULL, 36, 15); -- Entrada 36 (Dune 2) 10% Trasnoche
GO


