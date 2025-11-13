--🎟️ 1. Rendimiento general

use PIPORAMA
GO
--1.1 Entradas vendidas por día – Muestra cuántas entradas se vendieron y la recaudación total diaria.
CREATE OR ALTER PROCEDURE SP_EntradasRecaudacionXDia
@fecha_inicio datetime = NULL,
@fecha_fin datetime = NULL
AS
BEGIN
SELECT 
    CAST(fac.fecha AS date) AS fecha,
    COUNT(e.id_entrada) AS entradas_vendidas,
    CONVERT(VARCHAR, CONVERT(VARCHAR, CAST(SUM(df.precio) AS MONEY), 1)) AS recaudacion_total
FROM funciones f
JOIN entradas e ON f.id_funcion = e.id_funcion
JOIN detalles_factura df ON df.id_entrada = e.id_entrada
join facturas fac on fac.id_factura= df.id_factura
where
(@fecha_inicio is null or @fecha_fin is null or fac.fecha between @fecha_inicio and dateadd(day,1,@fecha_fin))
GROUP BY CAST(fac.fecha AS date)
ORDER BY fecha ASC;
END
GO

--1.2 Recaudación total por película – Indica qué películas generaron más ingresos.
CREATE OR ALTER PROCEDURE SP_RecaudacionXPelicula
@pelicula INT = null
AS
BEGIN
IF (@pelicula is null)
begin
        SELECT 
            p.nom_pelicula AS pelicula,
            CONVERT(VARCHAR, CONVERT(VARCHAR, CAST(SUM(df.precio) AS MONEY), 1)) AS recaudacion_total,
            COUNT(e.id_entrada) AS entradas_vendidas
        FROM peliculas p
            JOIN funciones f ON f.id_pelicula = p.id_pelicula
            JOIN entradas e ON e.id_funcion = f.id_funcion
            JOIN detalles_factura df ON df.id_entrada = e.id_entrada
        WHERE df.id_entrada IS NOT NULL
        GROUP BY p.nom_pelicula
        ORDER BY recaudacion_total DESC
end
else
begin
        SELECT 
            p.nom_pelicula AS pelicula,
            CONVERT(VARCHAR, CONVERT(VARCHAR, CAST(SUM(df.precio) AS MONEY), 1)) AS recaudacion_total,
            COUNT(e.id_entrada) AS entradas_vendidas
        FROM peliculas p
            JOIN funciones f ON f.id_pelicula = p.id_pelicula
            JOIN entradas e ON e.id_funcion = f.id_funcion
            JOIN detalles_factura df ON df.id_entrada = e.id_entrada
        WHERE df.id_entrada IS NOT NULL and P.id_pelicula = @pelicula
        GROUP BY p.nom_pelicula
        ORDER BY recaudacion_total DESC
end
END
GO


--1.3 Promedio de entradas vendidas por función – 
--Permite ver qué tan ocupadas están las funciones, comparando el promedio de entradas vendidas por función.
CREATE OR ALTER PROCEDURE SP_PromedioEntradasPorSala
@fecha_inicio datetime = NULL,
@fecha_fin datetime = NULL
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
WHERE 
(@fecha_inicio is null or @fecha_fin is null or f.horario between @fecha_inicio and dateadd(day,1,@fecha_fin))
GROUP BY s.nom_sala, s.cant_butacas
ORDER BY s.nom_sala;
END
GO


--🍿 2. Películas y salas

--Objetivo: Evaluar el rendimiento de las películas y la ocupación de las salas.
--Consultas incluidas:

--2.1 Películas más vistas – Muestra las 5 películas con mayor cantidad de entradas vendidas.
CREATE OR ALTER PROCEDURE SP_PeliculasMasVistas
@fecha_inicio datetime = NULL,
@fecha_fin datetime = NULL
as
begin
SELECT TOP 5 
    p.nom_pelicula,
    COUNT(en.id_entrada) AS total_entradas
FROM peliculas p
JOIN funciones fu ON p.id_pelicula = fu.id_pelicula
JOIN entradas en ON en.id_funcion = fu.id_funcion
where 
(@fecha_inicio is null or @fecha_fin is null or fu.horario between @fecha_inicio and dateadd(day,1,@fecha_fin))
GROUP BY p.nom_pelicula
ORDER BY total_entradas DESC;
end
GO

--🕒 3. Operaciones y horarios

--Objetivo: Conocer la distribución de funciones y la programación del cine.
--Consultas incluidas:


--Primero creamos una vista
CREATE OR ALTER VIEW FuncionesXHorario
AS
SELECT CASE 
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
    END
GO

--3.1 Cantidad de funciones por franja horaria – Muestra cuántas funciones se proyectan en cada parte del día (mañana, tarde, noche, madrugada).
CREATE OR ALTER PROCEDURE SP_FuncionesXHorario
AS
begin
SELECT 
    CASE
        WHEN franja_horaria = 'Madrugada' THEN 1
        WHEN franja_horaria = 'Mañana' THEN 2
        WHEN franja_horaria = 'Tarde' THEN 3
        ELSE 4
    END AS orden,
    vista.franja_horaria,
    vista.cantidad_funciones
FROM dbo.FuncionesXHorario as vista
ORDER BY 1;
end
GO

--3.2 Próximas funciones (desde hoy) – Lista todas las funciones programadas desde la fecha actual, incluyendo película, sala, horario, idioma y tipo de proyección.
CREATE OR ALTER PROCEDURE SP_ProximasFunciones
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
GO


--👥 4. Clientes y comportamiento

--Objetivo: Analizar el comportamiento y fidelidad de los clientes.
--Consultas incluidas:

--4.1 Clientes frecuentes – Muestra los clientes que realizaron más de 5 compras de entradas.
CREATE OR ALTER PROCEDURE SP_ClientesFrecuentes
    @fecha_inicio DATETIME = NULL,
    @fecha_fin DATETIME = NULL,
    @compra INT = NULL
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
    WHERE 
        (@fecha_inicio IS NULL OR @fecha_fin IS NULL OR f.fecha BETWEEN @fecha_inicio AND dateadd(day,1,@fecha_fin))
    GROUP BY c.nom_cliente, c.ape_cliente
    HAVING 
        (@compra IS NULL OR COUNT(e.id_entrada) > @compra)
    ORDER BY total_compras DESC;
END
GO


--🍔 5. Confitería y combos

--Objetivo: Evaluar el rendimiento de los productos y combos ofrecidos en la confitería.
--Consultas incluidas:

--5.1 Productos más vendidos TOP 5 – Indica cuáles son los consumibles con mayor cantidad de ventas y su ingreso total.
CREATE OR ALTER PROCEDURE SP_ConsumiblesMasVendidos
@fecha_inicio datetime = NULL,
@fecha_fin datetime = NULL
AS
BEGIN
SELECT TOP 5 
    co.nom_consumible,
    count(df.id_consumible),
    CONVERT(VARCHAR, CONVERT(VARCHAR, CAST(sum(df.precio) AS MONEY), 1)) as total_vendido
FROM detalles_factura df
join consumibles co on co.id_consumible=df.id_consumible
join facturas f on f.id_factura=df.id_factura
where
(@fecha_inicio is null or @fecha_fin is null or f.fecha between @fecha_inicio and dateadd(day,1,@fecha_fin))
GROUP BY co.nom_consumible
ORDER BY sum(df.precio) DESC;
END
GO

--5.2 Recaudación total por combos – Muestra los combos que más recaudaron en el período analizado.
CREATE OR ALTER PROCEDURE SP_RecaudacónTotalCombos
@fecha_inicio datetime = NULL,
@fecha_fin datetime = NULL
AS 
BEGIN
SELECT TOP 5
    c.nom_combo,
	count(df.id_combo),
    CONVERT(VARCHAR, CONVERT(VARCHAR, CAST(SUM(df.precio) AS MONEY), 1)) AS recaudacion_total
FROM combos c
JOIN detalles_factura df ON df.id_combo = c.id_combo
join facturas f on f.id_factura=df.id_factura
where
(@fecha_inicio is null or @fecha_fin is null or f.fecha between @fecha_inicio and dateadd(day,1,@fecha_fin))
GROUP BY c.nom_combo
ORDER BY recaudacion_total DESC
END
GO


--💼 6. KPIs para tarjetas del dashboard
--Objetivo: Presentar indicadores clave de gestión de forma visual y resumida.
--Indicadores sugeridos:

--🎟️ Total de entradas vendidas: Cantidad total de tickets emitidos.
CREATE OR ALTER PROCEDURE SP_TotalEntradasVendidas
AS
BEGIN
SELECT COUNT(e.id_entrada) 'Entradas Vendidas' 
FROM entradas e;
END
GO

--💰 Recaudación total: Suma total de las ventas registradas.
CREATE OR ALTER PROCEDURE SP_RecaudacionTotal
AS
BEGIN
SELECT CONVERT(VARCHAR, CONVERT(VARCHAR, CAST(SUM(precio) AS MONEY), 1)) 'Recaudacion Total'
FROM detalles_factura;
END
GO


--🎬 Películas activas: Cantidad de películas actualmente en cartelera.
CREATE OR ALTER PROCEDURE SP_PeliculasEnCartelera
AS
BEGIN
SELECT COUNT(p.id_pelicula) 'Peliculas Cartelera'
FROM peliculas p
WHERE id_estado_peli = (SELECT ep.id_estado_peli
						FROM estado_pelicula ep
						WHERE estado_pelicula = 'En cartelera');
END
GO


--👥 Clientes registrados: Total de clientes en la base de datos.
CREATE OR ALTER PROCEDURE SP_TotalClientesRegistrados
AS
BEGIN
SELECT COUNT(c.id_cliente) 'Clientes Registrados' 
FROM clientes c;
END
GO
