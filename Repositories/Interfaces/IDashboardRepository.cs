using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces
{
    public interface IDashboardRepository
    {
        //1.1 Entradas vendidas por día – Muestra cuántas entradas se vendieron y la recaudación total diaria.
        Task<IEnumerable<SP_EntradasRecaudacionXDiaResult>> GetEntradasRecaudaciónXDia(DateTime? fechaInicio, DateTime? fechaFin);

        //1.2 Recaudación total por película – Indica qué películas generaron más ingresos.
        Task<IEnumerable<SP_RecaudacionXPeliculaResult>> GetRecaudaciónTotalXPelícula(int? pelicula);

        //1.3. Promedio de entradas vendidas por función** – Permite ver qué tan ocupadas están las funciones, comparando el promedio de entradas vendidas por función.
        Task<IEnumerable<SP_PromedioEntradasPorSalaResult>> GetPromedioEntradasVendidasXSala(DateTime? fechaInicio, DateTime? fechaFin);

        //2.1 Películas más vistas – Muestra las 5 películas con mayor cantidad de entradas vendidas.
        Task<IEnumerable<SP_PeliculasMasVistasResult>> GetPelículasMásVistas(DateTime? fechaInicio, DateTime? fechaFin);

        //3.1 Cantidad de funciones por franja horaria – Muestra cuántas funciones se proyectan en cada parte del día (mañana, tarde, noche, madrugada).
        Task<IEnumerable<SP_FuncionesXHorarioResult>> GetCantidadFuncionesPorFranjaHoraria();

        //3.2 Próximas funciones (desde hoy) – Lista todas las funciones programadas desde la fecha actual, incluyendo película, sala, horario, idioma y tipo de proyección.
        Task<IEnumerable<SP_ProximasFuncionesResult>> GetPróximasFunciones();

        //4.1 Clientes frecuentes – Muestra los clientes que realizaron más de 5 compras de entradas.
        Task<IEnumerable<SP_ClientesFrecuentesResult>> GetClientesFrecuentes(DateTime? fechaInicio, DateTime? fechaFin, int? compra);
      
        //5.1 Productos más vendidos** – Indica cuáles son los consumibles con mayor cantidad de ventas y su ingreso total.
        Task<IEnumerable<SP_ConsumiblesMasVendidosResult>> GetProductosMásVendidos(DateTime? fechaInicio, DateTime? fechaFin);

        //5.2 Recaudación total por combos** – Muestra los combos que más recaudaron en el período analizado.*/
        Task<IEnumerable<SP_RecaudacónTotalCombosResult>> GetRecaudacionTotalCombos(DateTime? fechaInicio, DateTime? fechaFin);

        //6.1 Total de entradas vendidas: Cantidad total de tickets emitidos.
        Task<IEnumerable<SP_TotalEntradasVendidasResult>> GetTotalEntradasVendidas();

        //6.2 Recaudación total: Suma total de las ventas registradas.
        Task<IEnumerable<SP_RecaudacionTotalResult>> GetRecaudacionTotal();

        //6.3 Películas activas: Cantidad de películas actualmente en cartelera.
        Task<IEnumerable<SP_PeliculasEnCarteleraResult>> GetPeliculasEnCartelera();

        //6.4 Clientes registrados: Total de clientes en la base de datos.
        Task<IEnumerable<SP_TotalClientesRegistradosResult>> GetTotalClientesRegistrados();

    }
}
