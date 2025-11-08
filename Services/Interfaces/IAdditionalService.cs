using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Additional;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Services.Interfaces
{
    public interface IAdditionalService
    {
        Task<IEnumerable<Barrio>> GetAllBarrios();
        Task<IEnumerable<TiposCliente>> GetAllTipoClientes();
        Task<IEnumerable<TiposContacto>> GetAllTipoContactos();
        Task<IEnumerable<Promocione>> GetAllPromociones();
        Task<IEnumerable<RoomSeatDTO>> GetAllSalasButacas();
        Task<IEnumerable<FilmDTO>> GetAllPeliculas();
        Task<IEnumerable<FunctionDTO>> GetAllFunciones();
        Task<IEnumerable<MediosPago>> GetAllMediosPago();
        Task<IEnumerable<EstadosCompra>> GetAllEstadosCompra();
        Task<IEnumerable<FormaCompra>> GetAllFormasCompra();
        Task<IEnumerable<Sala>> GetAllSalas();
        Task<IEnumerable<Consumible>> GetAllConsumibles();
        Task<IEnumerable<ComboDTO>> GetAllCombos();
        Task<IEnumerable<Role>> GetAllEmpleadosRoles();

    }
}
