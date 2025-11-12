using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<FuncionesXHorarioResult>> GetCantidadFuncionesPorFranjaHoraria()
        {
            return await _context.Procedures.FuncionesXHorarioAsync();
        }

        public async Task<IEnumerable<ClientesFrecuentesResult>> GetClientesFrecuentes()
        {
            return await _context.Procedures.ClientesFrecuentesAsync();
        }

        public async Task<IEnumerable<EntradasRecaudacionXDiaResult>> GetEntradasRecaudaciónXDia()
        {
            return await _context.Procedures.EntradasRecaudacionXDiaAsync();
        }

        public async Task<IEnumerable<PeliculasEnCarteleraResult>> GetPeliculasEnCartelera()
        {
            return await _context.Procedures.PeliculasEnCarteleraAsync();
        }

        public async Task<IEnumerable<PeliculasMasVistasResult>> GetPelículasMásVistas()
        {
            return await _context.Procedures.PeliculasMasVistasAsync();
        }

        public async Task<IEnumerable<ConsumiblesMasVendidosResult>> GetProductosMásVendidos()
        {
            return await _context.Procedures.ConsumiblesMasVendidosAsync();
        }

        public async Task<IEnumerable<PromedioEntradasPorSalaResult>> GetPromedioEntradasVendidasXSala()
        {
            return await _context.Procedures.PromedioEntradasPorSalaAsync();
        }

        public async Task<IEnumerable<ProximasFuncionesResult>> GetPróximasFunciones()
        {
            return await _context.Procedures.ProximasFuncionesAsync();
        }

        public async Task<IEnumerable<RecaudacionTotalResult>> GetRecaudacionTotal()
        {
            return await _context.Procedures.RecaudacionTotalAsync();
        }

        public async Task<IEnumerable<RecaudacónTotalCombosResult>> GetRecaudacionTotalCombos()
        {
            return await _context.Procedures.RecaudacónTotalCombosAsync();
        }

        public async Task<IEnumerable<RecaudacionXPeliculaResult>> GetRecaudaciónTotalXPelícula()
        {
            return await _context.Procedures.RecaudacionXPeliculaAsync();
        }

        public async Task<IEnumerable<TotalClientesRegistradosResult>> GetTotalClientesRegistrados()
        {
            return await _context.Procedures.TotalClientesRegistradosAsync();
        }

        public async Task<IEnumerable<TotalEntradasVendidasResult>> GetTotalEntradasVendidas()
        {
            return await _context.Procedures.TotalEntradasVendidasAsync();
        }


    }
}