--🎟️ 1. Rendimiento general

use Piporama_El_Fin

--1.1 Entradas vendidas por día – Muestra cuántas entradas se vendieron y la recaudación total diaria.
CREATE PROCEDURE EntradasRecaudacionXDia
AS
BEGIN
SELECT 
    CAST(f.horario AS date) AS fecha,
    COUNT(e.id_entrada) AS entradas_vendidas,
    SUM(df.precio) AS recaudacion_total
FROM funciones f
JOIN entradas e ON f.id_funcion = e.id_funcion
JOIN detalles_factura df ON df.id_entrada = e.id_entrada
GROUP BY CAST(f.horario AS date)
ORDER BY fecha DESC;
END

EXEC dbo.EntradasRecaudacionXDia

--1.2 Recaudación total por película – Indica qué películas generaron más ingresos.
CREATE PROCEDURE RecaudacionXPelicula
AS
BEGIN
SELECT 
    p.nom_pelicula AS pelicula,
    SUM(df.precio) AS recaudacion_total,
    COUNT(e.id_entrada) AS entradas_vendidas
FROM peliculas p
JOIN funciones f ON f.id_pelicula = p.id_pelicula
JOIN entradas e ON e.id_funcion = f.id_funcion
JOIN detalles_factura df ON df.id_entrada = e.id_entrada
WHERE df.id_entrada IS NOT NULL
GROUP BY p.nom_pelicula
ORDER BY recaudacion_total DESC
END

EXEC dbo.RecaudacionXPelicula

----------------------------------------PENDIENTEEEEEEE---------------------------------------------------
--1.3 Promedio de entradas vendidas por función – 
--Permite ver qué tan ocupadas están las funciones, comparando el promedio de entradas vendidas por función.
CREATE PROCEDURE PromedioEntradasPorSala
AS
BEGIN
SELECT 
    s.nom_sala,
    COUNT(DISTINCT f.id_funcion) AS funciones,
    COUNT(e.id_entrada) AS entradas_vendidas,
    s.cant_butacas,
    ROUND(
        COALESCE(
            (COUNT(e.id_entrada) * 100.0) / 
            NULLIF((COUNT(DISTINCT f.id_funcion) * s.cant_butacas), 0),
        0), 2) AS ocupacion_promedio
FROM salas s
LEFT JOIN funciones f ON s.id_sala = f.id_sala
LEFT JOIN entradas e ON e.id_funcion = f.id_funcion
GROUP BY s.nom_sala, s.cant_butacas
ORDER BY s.nom_sala;
END

EXEC dbo.PromedioEntradasPorSala

select *
from sala_butacas

--🍿 2. Películas y salas

--Objetivo: Evaluar el rendimiento de las películas y la ocupación de las salas.
--Consultas incluidas:

--2.1 Películas más vistas – Muestra las 5 películas con mayor cantidad de entradas vendidas.
ALTER PROCEDURE PeliculasMasVistas
as
begin
SELECT TOP 5 
    p.nom_pelicula,
    COUNT(en.id_entrada) AS total_entradas
FROM peliculas p
JOIN funciones fu ON p.id_pelicula = fu.id_pelicula
JOIN entradas en ON en.id_funcion = fu.id_funcion
GROUP BY p.nom_pelicula
ORDER BY total_entradas DESC;
end

exec dbo.PeliculasMasVistas

--🕒 3. Operaciones y horarios

--Objetivo: Conocer la distribución de funciones y la programación del cine.
--Consultas incluidas:

--3.1 Cantidad de funciones por franja horaria – Muestra cuántas funciones se proyectan en cada parte del día (mañana, tarde, noche, madrugada).
CREATE OR ALTER PROCEDURE FuncionesXHorario
AS
BEGIN
SELECT 
    CASE 
        WHEN DATEPART(HOUR, fu.horario) BETWEEN 10 AND 13 THEN 'Mañana'
        WHEN DATEPART(HOUR, fu.horario) BETWEEN 14 AND 18 THEN 'Tarde'
        WHEN DATEPART(HOUR, fu.horario) BETWEEN 19 AND 23 THEN 'Noche'
        ELSE 'Madrugada'
    END AS franja_horaria,
    COUNT(fu.id_funcion) AS cantidad_funciones
FROM funciones fu
GROUP BY 
    CASE 
        WHEN DATEPART(HOUR, fu.horario) BETWEEN 10 AND 13 THEN 'Mañana'
        WHEN DATEPART(HOUR, fu.horario) BETWEEN 14 AND 18 THEN 'Tarde'
        WHEN DATEPART(HOUR, fu.horario) BETWEEN 19 AND 23 THEN 'Noche'
        ELSE 'Madrugada'
    END;
END
EXEC dbo.FuncionesXHorario

--Agregar funciones entre las 10 y 13

--3.2 Próximas funciones (desde hoy) – Lista todas las funciones programadas desde la fecha actual, incluyendo película, sala, horario, idioma y tipo de proyección.
CREATE PROCEDURE ProximasFunciones
AS 
BEGIN
SELECT 
    p.nom_pelicula,
    s.nom_sala,
    fu.horario,
    i.idioma,
    tp.tipo_proyeccion
FROM funciones fu
JOIN peliculas p ON p.id_pelicula = fu.id_pelicula
JOIN salas s ON s.id_sala = fu.id_sala
JOIN idiomas i ON i.id_idioma = fu.id_idioma
JOIN tipos_proyeccion tp ON tp.id_tipo_proyeccion = fu.id_tipo_proyeccion
WHERE fu.horario >= GETDATE()
ORDER BY fu.horario;
END


--NO HAY PROXIMAS FUNCIONES
EXEC dbo.ProximasFunciones

--Insertar funciones futuras
INSERT INTO funciones (id_pelicula, horario, id_sala, id_formato, id_idioma, id_tipo_proyeccion)
VALUES (1, DATEADD(day, 1, CAST(GETDATE() AS datetime)), 2, 1, 1, 1);


--👥 4. Clientes y comportamiento

--Objetivo: Analizar el comportamiento y fidelidad de los clientes.
--Consultas incluidas:

--4.1 Clientes frecuentes – Muestra los clientes que realizaron más de 5 compras de entradas.
CREATE PROCEDURE ClientesFrecuentes
AS
BEGIN
SELECT 
    c.nom_cliente,
    c.ape_cliente,
    COUNT(e.id_entrada) AS total_compras
FROM clientes c
JOIN facturas f ON f.id_cliente = c.id_cliente
JOIN detalles_factura df ON df.id_factura = f.id_factura
JOIN entradas e ON e.id_entrada = df.id_entrada
GROUP BY c.nom_cliente, c.ape_cliente
HAVING COUNT(e.id_entrada) > 5
ORDER BY total_compras DESC;
END

EXEC dbo.ClientesFrecuentes

--A



--4.2 Gasto promedio por cliente – Calcula cuánto gasta en promedio cada cliente en sus compras.
/*SELECT 
    c.nom_cliente,
    c.ape_cliente,
    ROUND(AVG(df.precio), 2) AS gasto_promedio
FROM clientes c
JOIN facturas f ON f.id_cliente = c.id_cliente
JOIN detalles_factura df ON df.id_factura = f.id_factura
JOIN entradas e ON e.id_entrada = df.id_entrada
GROUP BY c.nom_cliente, c.ape_cliente
ORDER BY gasto_promedio DESC;*/



--🍔 5. Confitería y combos

--Objetivo: Evaluar el rendimiento de los productos y combos ofrecidos en la confitería.
--Consultas incluidas:

--5.1 Productos más vendidos TOP 5 – Indica cuáles son los consumibles con mayor cantidad de ventas y su ingreso total.
CREATE PROCEDURE ConsumiblesMasVendidos
AS
BEGIN
SELECT TOP 5 
    co.nom_consumible,
    SUM(dc.cantidad) AS total_vendido,
    SUM(dc.cantidad * dc.pre_unitario) AS ingresos_generados
FROM consumibles co
JOIN detalles_combo dc ON co.id_consumible = dc.id_consumible
GROUP BY co.nom_consumible
ORDER BY total_vendido DESC;
END

EXEC dbo.ConsumiblesMasVendidos

select *
from consumibles


--5.2 Recaudación total por combos – Muestra los combos que más recaudaron en el período analizado.
CREATE PROCEDURE RecaudacónTotalCombos
AS 
BEGIN
SELECT TOP 3
    c.nom_combo,
	count(df.id_combo),
    SUM(df.precio) AS recaudacion_total
FROM combos c
JOIN detalles_factura df ON df.id_combo = c.id_combo
GROUP BY c.nom_combo
ORDER BY recaudacion_total DESC
END

EXEC dbo.RecaudacónTotalCombos


--💼 6. KPIs para tarjetas del dashboard
--Objetivo: Presentar indicadores clave de gestión de forma visual y resumida.
--Indicadores sugeridos:

--🎟️ Total de entradas vendidas: Cantidad total de tickets emitidos.
CREATE PROCEDURE TotalEntradasVendidas
AS
BEGIN
SELECT COUNT(e.id_entrada) 'Entradas Vendidas' 
FROM entradas e;
END

EXEC dbo.TotalEntradasVendidas

--💰 Recaudación total: Suma total de las ventas registradas.
CREATE PROCEDURE RecaudacionTotal
AS
BEGIN
SELECT SUM(precio) 'Recaudacion Total'
FROM detalles_factura;
END

EXEC dbo.RecaudacionTotal


--🎬 Películas activas: Cantidad de películas actualmente en cartelera.
CREATE PROCEDURE PeliculasEnCartelera
AS
BEGIN
SELECT COUNT(p.id_pelicula) 'Peliculas Cartelera'
FROM peliculas p
WHERE id_estado_peli = (SELECT ep.id_estado_peli
						FROM estado_pelicula ep
						WHERE estado_pelicula = 'En cartelera');
END

EXEC dbo.PeliculasEnCartelera


--👥 Clientes registrados: Total de clientes en la base de datos.
CREATE PROCEDURE TotalClientesRegistrados
AS
BEGIN
SELECT COUNT(c.id_cliente) 'Clientes Registrados' 
FROM clientes c;
END

EXEC dbo.TotalClientesRegistrados

