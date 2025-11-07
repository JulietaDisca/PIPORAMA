using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<IEnumerable<EntradasRecaudacionXDiaResult>> GetEntradasRecaudaciónXDia();

        Task<IEnumerable<RecaudacionXPeliculaResult>> GetRecaudaciónTotalXPelícula();

        Task<IEnumerable<PromedioEntradasPorSalaResult>> GetPromedioEntradasVendidasXSala();

        Task<IEnumerable<PeliculasMasVistasResult>> GetPelículasMásVistas();

        Task<IEnumerable<FuncionesXHorarioResult>> GetCantidadFuncionesPorFranjaHoraria();

        Task<IEnumerable<ProximasFuncionesResult>> GetPróximasFunciones();

        Task<IEnumerable<ClientesFrecuentesResult>> GetClientesFrecuentes();

        Task<IEnumerable<ConsumiblesMasVendidosResult>> GetProductosMásVendidos();

        Task<IEnumerable<RecaudacónTotalCombosResult>> GetRecaudacionTotalCombos();

        Task<IEnumerable<TotalEntradasVendidasResult>> GetTotalEntradasVendidas();

        Task<IEnumerable<RecaudacionTotalResult>> GetRecaudacionTotal();

        Task<IEnumerable<PeliculasEnCarteleraResult>> GetPeliculasEnCartelera();

        Task<IEnumerable<TotalClientesRegistradosResult>> GetTotalClientesRegistrados();
    }
}
