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

        public async Task<IEnumerable<EntradasRecaudacionXDiaResult>> GetEntradasRecaudaciónXDia()
        {
            return await _repository.GetEntradasRecaudaciónXDia();
        }

        public async Task<IEnumerable<RecaudacionXPeliculaResult>> GetRecaudaciónTotalXPelícula()
        {
            return await _repository.GetRecaudaciónTotalXPelícula(); 
        }

        public async Task<IEnumerable<PromedioEntradasPorSalaResult>> GetPromedioEntradasVendidasXSala()
        {
            return await _repository.GetPromedioEntradasVendidasXSala();
        }

        public async Task<IEnumerable<PeliculasMasVistasResult>> GetPelículasMásVistas()
        {
            return await _repository.GetPelículasMásVistas();
        }

        public async Task<IEnumerable<FuncionesXHorarioResult>> GetCantidadFuncionesPorFranjaHoraria()
        {
            return await _repository.GetCantidadFuncionesPorFranjaHoraria();
        }

        public async Task<IEnumerable<ProximasFuncionesResult>> GetPróximasFunciones()
        {
            return await _repository.GetPróximasFunciones();
        }

        public async Task<IEnumerable<ClientesFrecuentesResult>> GetClientesFrecuentes()
        {
            return await _repository.GetClientesFrecuentes();
        }

        public async Task<IEnumerable<ConsumiblesMasVendidosResult>> GetProductosMásVendidos()
        {
            return await _repository.GetProductosMásVendidos();
        }

        public async Task<IEnumerable<RecaudacónTotalCombosResult>> GetRecaudacionTotalCombos()
        {
            return await _repository.GetRecaudacionTotalCombos();
        }

        public async Task<IEnumerable<TotalEntradasVendidasResult>> GetTotalEntradasVendidas()
        {
            return await _repository.GetTotalEntradasVendidas();
        }

        public async Task<IEnumerable<RecaudacionTotalResult>> GetRecaudacionTotal()
        {
            return await _repository.GetRecaudacionTotal();
        }

        public async Task<IEnumerable<PeliculasEnCarteleraResult>> GetPeliculasEnCartelera()
        {
            return await _repository.GetPeliculasEnCartelera();
        }

        public async Task<IEnumerable<TotalClientesRegistradosResult>> GetTotalClientesRegistrados()
        {
            return await _repository.GetTotalClientesRegistrados();
        }
    }
}
