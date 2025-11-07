using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces
{
    public interface IDashboardRepository
    {
        //1.1 Entradas vendidas por día – Muestra cuántas entradas se vendieron y la recaudación total diaria.
        Task<IEnumerable<EntradasRecaudacionXDiaResult>> GetEntradasRecaudaciónXDia();

        //1.2 Recaudación total por película – Indica qué películas generaron más ingresos.
        Task<IEnumerable<RecaudacionXPeliculaResult>> GetRecaudaciónTotalXPelícula();

        //1.3. Promedio de entradas vendidas por función** – Permite ver qué tan ocupadas están las funciones, comparando el promedio de entradas vendidas por función.
        Task<IEnumerable<PromedioEntradasPorSalaResult>> GetPromedioEntradasVendidasXSala();

        //2.1 Películas más vistas – Muestra las 5 películas con mayor cantidad de entradas vendidas.
        Task<IEnumerable<PeliculasMasVistasResult>> GetPelículasMásVistas();

        //3.1 Cantidad de funciones por franja horaria – Muestra cuántas funciones se proyectan en cada parte del día (mañana, tarde, noche, madrugada).
        Task<IEnumerable<FuncionesXHorarioResult>> GetCantidadFuncionesPorFranjaHoraria();

        //3.2 Próximas funciones (desde hoy) – Lista todas las funciones programadas desde la fecha actual, incluyendo película, sala, horario, idioma y tipo de proyección.
        Task<IEnumerable<ProximasFuncionesResult>> GetPróximasFunciones();

        //4.1 Clientes frecuentes – Muestra los clientes que realizaron más de 5 compras de entradas.
        Task<IEnumerable<ClientesFrecuentesResult>> GetClientesFrecuentes();
      
        //5.1 Productos más vendidos** – Indica cuáles son los consumibles con mayor cantidad de ventas y su ingreso total.
        Task<IEnumerable<ConsumiblesMasVendidosResult>> GetProductosMásVendidos();

        //5.2 Recaudación total por combos** – Muestra los combos que más recaudaron en el período analizado.*/
        Task<IEnumerable<RecaudacónTotalCombosResult>> GetRecaudacionTotalCombos();

        //6.1 Total de entradas vendidas: Cantidad total de tickets emitidos.
        Task<IEnumerable<TotalEntradasVendidasResult>> GetTotalEntradasVendidas();

        //6.2 Recaudación total: Suma total de las ventas registradas.
        Task<IEnumerable<RecaudacionTotalResult>> GetRecaudacionTotal();

        //6.3 Películas activas: Cantidad de películas actualmente en cartelera.
        Task<IEnumerable<PeliculasEnCarteleraResult>> GetPeliculasEnCartelera();

        //6.4 Clientes registrados: Total de clientes en la base de datos.
        Task<IEnumerable<TotalClientesRegistradosResult>> GetTotalClientesRegistrados();

    }
}
