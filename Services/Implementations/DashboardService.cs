using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repository;
        public DashboardService(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SP_EntradasRecaudacionXDiaResult>> GetEntradasRecaudaciónXDia(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return await _repository.GetEntradasRecaudaciónXDia(fechaInicio,fechaFin);
        }

        public async Task<IEnumerable<SP_RecaudacionXPeliculaResult>> GetRecaudaciónTotalXPelícula(DateTime? fechaInicio, DateTime? fechaFin, int? recaudacion)
        {
            return await _repository.GetRecaudaciónTotalXPelícula(fechaInicio, fechaFin, recaudacion); 
        }

        public async Task<IEnumerable<SP_PromedioEntradasPorSalaResult>> GetPromedioEntradasVendidasXSala(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return await _repository.GetPromedioEntradasVendidasXSala(fechaInicio,fechaFin);
        }

        public async Task<IEnumerable<SP_FuncionesXHorarioResult>> GetCantidadFuncionesPorFranjaHoraria()
        {
            return await _repository.GetCantidadFuncionesPorFranjaHoraria();
        }

        public async Task<IEnumerable<SP_ProximasFuncionesResult>> GetPróximasFunciones()
        {
            return await _repository.GetPróximasFunciones();
        }

        public async Task<IEnumerable<SP_ClientesFrecuentesResult>> GetClientesFrecuentes(DateTime? fechaInicio, DateTime? fechaFin, int? compra)
        {
            return await _repository.GetClientesFrecuentes(fechaInicio,fechaFin,compra);
        }

        public async Task<IEnumerable<SP_ConsumiblesMasVendidosResult>> GetProductosMásVendidos(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return await _repository.GetProductosMásVendidos(fechaInicio,fechaFin);
        }

        public async Task<IEnumerable<SP_TotalEntradasVendidasResult>> GetTotalEntradasVendidas()
        {
            return await _repository.GetTotalEntradasVendidas();
        }

        public async Task<IEnumerable<SP_RecaudacionTotalResult>> GetRecaudacionTotal()
        {
            return await _repository.GetRecaudacionTotal();
        }

        public async Task<IEnumerable<SP_PeliculasEnCarteleraResult>> GetPeliculasEnCartelera()
        {
            return await _repository.GetPeliculasEnCartelera();
        }

        public async Task<IEnumerable<SP_TotalClientesRegistradosResult>> GetTotalClientesRegistrados()
        {
            return await _repository.GetTotalClientesRegistrados();
        }
    }
}
