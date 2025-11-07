using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Implementations
{
    public class DashboardRepository : IDashboardRepository
    {
        private PIPORAMAContext _context;
        public DashboardRepository(PIPORAMAContext context)
        {
            _context = context;
        }

        //1.1
        public async Task<IEnumerable<EntradasRecaudacionXDiaResult>> GetEntradasRecaudaciónXDia()
        {
            return await _context.Procedures.EntradasRecaudacionXDiaAsync();
        }

        //1.2
        public async Task<IEnumerable<RecaudacionXPeliculaResult>> GetRecaudaciónTotalXPelícula()
        {
            return await _context.Procedures.RecaudacionXPeliculaAsync();
        }

        //1.3
        public async Task<IEnumerable<PromedioEntradasPorSalaResult>> GetPromedioEntradasVendidasXSala()
        {
            return await _context.Procedures.PromedioEntradasPorSalaAsync();
        }

        //2.1
        public async Task<IEnumerable<PeliculasMasVistasResult>> GetPelículasMásVistas()
        {
            return await _context.Procedures.PeliculasMasVistasAsync();
        }

        //3.1
        public async Task<IEnumerable<FuncionesXHorarioResult>> GetCantidadFuncionesPorFranjaHoraria()
        {
            return await _context.Procedures.FuncionesXHorarioAsync();
        }

        //3.2
        public async Task<IEnumerable<ProximasFuncionesResult>> GetPróximasFunciones()
        {
            return await _context.Procedures.ProximasFuncionesAsync();
        }

        //4.1
        public async Task<IEnumerable<ClientesFrecuentesResult>> GetClientesFrecuentes()
        {
            return await _context.Procedures.ClientesFrecuentesAsync();
        }

        //5.1
        public async Task<IEnumerable<ConsumiblesMasVendidosResult>> GetProductosMásVendidos()
        {
            return await _context.Procedures.ConsumiblesMasVendidosAsync();
        }

        //5.2
        public async Task<IEnumerable<RecaudacónTotalCombosResult>> GetRecaudacionTotalCombos()
        {
            return await _context.Procedures.RecaudacónTotalCombosAsync();
        }

        //6.1
        public async Task<IEnumerable<TotalEntradasVendidasResult>> GetTotalEntradasVendidas()
        {
            return await _context.Procedures.TotalEntradasVendidasAsync();
        }

        //6.2
        public async Task<IEnumerable<RecaudacionTotalResult>> GetRecaudacionTotal()
        {
            return await _context.Procedures.RecaudacionTotalAsync();
        }

        //6.3
        public async Task<IEnumerable<PeliculasEnCarteleraResult>> GetPeliculasEnCartelera()
        {
            return await _context.Procedures.PeliculasEnCarteleraAsync();
        }

        //6.4
        public async Task<IEnumerable<TotalClientesRegistradosResult>> GetTotalClientesRegistrados()
        {
            return await _context.Procedures.TotalClientesRegistradosAsync();
        }

    }
}
