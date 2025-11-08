using Microsoft.EntityFrameworkCore;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Additional;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Implementations
{
    public class AdditionalRepository : IAdditionalRepository
    {
        private PIPORAMAContext _context;
        public AdditionalRepository(PIPORAMAContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Barrio>> GetAllBarrios()
        {
            return await _context.Barrios.ToListAsync();
        }

        public async Task<IEnumerable<SalaButaca>> GetAllSalasButacas()
        {
            return await _context.SalaButacas.Include(sb => sb.IdSalaNavigation).Include(sb => sb.IdButacaNavigation).ToListAsync();
        }

        public async Task<IEnumerable<EstadosCompra>> GetAllEstadosCompra()
        {
            return await _context.EstadosCompras.ToListAsync();
        }

        public async Task<IEnumerable<FormaCompra>> GetAllFormasCompra()
        {
            return await _context.FormaCompras.ToListAsync();
        }

        public async Task<IEnumerable<Funcione>> GetAllFunciones()
        {
            return await _context.Funciones.Include(f => f.IdPeliculaNavigation).Include(f=> f.IdSalaNavigation).ToListAsync();
        }

        public async Task<IEnumerable<MediosPago>> GetAllMediosPago()
        {
            return await _context.MediosPagos.ToListAsync();
        }

        public async Task<IEnumerable<Pelicula>> GetAllPeliculas()
        {
            return await _context.Peliculas.ToListAsync();
        }

        public async Task<IEnumerable<Promocione>> GetAllPromociones()
        {
            return await _context.Promociones.ToListAsync();
        }

        public async Task<IEnumerable<TiposCliente>> GetAllTipoClientes()
        {
            return await _context.TiposClientes.ToListAsync();
        }

        public async Task<IEnumerable<TiposContacto>> GetAllTipoContactos()
        {
            return await _context.TiposContactos.ToListAsync();
        }


        public async Task<IEnumerable<Sala>> GetAllSalas()
        {
            return await _context.Salas.ToListAsync();
        }

        public async Task<IEnumerable<Consumible>> GetAllConsumibles()
        {
            return await _context.Consumibles.ToListAsync();
        }

        public async Task<IEnumerable<ComboDTO>> GetAllCombos()
        {
            return await _context.Combos
                .Select(c => new ComboDTO
                {
                    NomCombo = c.NomCombo,
                    PrecioCombo = c.DetallesCombos.Sum(dc => dc.PreUnitario * dc.Cantidad)
                })
                .ToListAsync();

        }
        public async Task<IEnumerable<Role>> GetAllEmpleadosRoles()
        {
            return await _context.Roles.ToListAsync();

        }
    }
}
