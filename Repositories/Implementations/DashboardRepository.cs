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

        public async Task<IEnumerable<SP_FuncionesXHorarioResult>> GetCantidadFuncionesPorFranjaHoraria()
        {
            return await _context.Procedures.SP_FuncionesXHorarioAsync();
        }

        public async Task<IEnumerable<SP_ClientesFrecuentesResult>> GetClientesFrecuentes(DateTime? fechaInicio, DateTime? fechaFin, int? compra)
        {
            return await _context.Procedures.SP_ClientesFrecuentesAsync(fechaInicio,fechaFin,compra);
        }

        public async Task<IEnumerable<SP_EntradasRecaudacionXDiaResult>> GetEntradasRecaudaciónXDia(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return await _context.Procedures.SP_EntradasRecaudacionXDiaAsync(fechaInicio, fechaFin);
        }

        public async Task<IEnumerable<SP_PeliculasEnCarteleraResult>> GetPeliculasEnCartelera()
        {
            return await _context.Procedures.SP_PeliculasEnCarteleraAsync();
        }

        public async Task<IEnumerable<SP_PeliculasMasVistasResult>> GetPelículasMásVistas(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return await _context.Procedures.SP_PeliculasMasVistasAsync(fechaInicio,fechaFin);
        }

        public async Task<IEnumerable<SP_ConsumiblesMasVendidosResult>> GetProductosMásVendidos(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return await _context.Procedures.SP_ConsumiblesMasVendidosAsync(fechaInicio,fechaFin);
        }

        public async Task<IEnumerable<SP_PromedioEntradasPorSalaResult>> GetPromedioEntradasVendidasXSala(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return await _context.Procedures.SP_PromedioEntradasPorSalaAsync(fechaInicio,fechaFin);
        }

        public async Task<IEnumerable<SP_ProximasFuncionesResult>> GetPróximasFunciones()
        {
            return await _context.Procedures.SP_ProximasFuncionesAsync();
        }

        public async Task<IEnumerable<SP_RecaudacionTotalResult>> GetRecaudacionTotal()
        {
            return await _context.Procedures.SP_RecaudacionTotalAsync();
        }

        public async Task<IEnumerable<SP_RecaudacónTotalCombosResult>> GetRecaudacionTotalCombos(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return await _context.Procedures.SP_RecaudacónTotalCombosAsync(fechaInicio,fechaFin);
        }

        public async Task<IEnumerable<SP_RecaudacionXPeliculaResult>> GetRecaudaciónTotalXPelícula(int? pelicula)
        {
            return await _context.Procedures.SP_RecaudacionXPeliculaAsync(pelicula);
        }

        public async Task<IEnumerable<SP_TotalClientesRegistradosResult>> GetTotalClientesRegistrados()
        {
            return await _context.Procedures.SP_TotalClientesRegistradosAsync();
        }

        public async Task<IEnumerable<SP_TotalEntradasVendidasResult>> GetTotalEntradasVendidas()
        {
            return await _context.Procedures.SP_TotalEntradasVendidasAsync();
        }


    }
}