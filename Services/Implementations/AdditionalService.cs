using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Additional;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;
using System.Linq;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;

namespace TP_ProgramaciónII_PIPORAMA.Services.Implementations
{
    public class AdditionalService : IAdditionalService
    {
        private readonly IAdditionalRepository _repository;
        public AdditionalService(IAdditionalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Barrio>> GetAllBarrios()
        {
            return await _repository.GetAllBarrios();
        }

        public async Task<IEnumerable<ComboDTO>> GetAllCombos()
        {
            return await _repository.GetAllCombos();
            
        }

        public async Task<IEnumerable<Consumible>> GetAllConsumibles()
        {
            return await _repository.GetAllConsumibles();
        }

        public async Task<IEnumerable<EstadosCompra>> GetAllEstadosCompra()
        {
            return await _repository.GetAllEstadosCompra();
        }

        public async Task<IEnumerable<FormaCompra>> GetAllFormasCompra()
        {
            return await _repository.GetAllFormasCompra();
        }

        public async Task<IEnumerable<FunctionDTO>> GetAllFunciones()
        {
            var funciones = await _repository.GetAllFunciones();
            var funcionesDTO = new List<FunctionDTO>();

            foreach (var funcion in funciones)
            {
                var dto = new FunctionDTO
                {   
                    IdFuncion = funcion.IdFuncion,
                    FunctionDate = funcion.Horario,
                    Film = funcion.IdPeliculaNavigation?.NomPelicula ?? string.Empty,
                    Room = funcion.IdSalaNavigation?.NomSala ?? string.Empty,
                    Precio = funcion.Precio ?? 0
                };
                funcionesDTO.Add(dto);
            }

            return funcionesDTO;
        }

        public async Task<IEnumerable<MediosPago>> GetAllMediosPago()
        {
            return await _repository.GetAllMediosPago();
        }

        public async Task<IEnumerable<FilmDTO>> GetAllPeliculas()
        {
            var peliculas = await _repository.GetAllPeliculas();
            var peliculasDTO = new List<FilmDTO>();
            foreach (var pelicula in peliculas)
            {
                var dto = new FilmDTO
                {
                    Film = pelicula.NomPelicula
                };
                peliculasDTO.Add(dto);
            }
            return peliculasDTO;
        }

        public async Task<IEnumerable<Promocione>> GetAllPromociones()
        {
            return await _repository.GetAllPromociones();
        }

        public async Task<IEnumerable<Sala>> GetAllSalas()
        {
            return await _repository.GetAllSalas();
        }

        public async Task<IEnumerable<RoomSeatDTO>> GetAllSalasButacas()
        {
            var salasButacas = await _repository.GetAllSalasButacas();
            var gruposPorSala = salasButacas
                .Where(sb => sb != null)
                .GroupBy(sb => sb.IdSala);

            var salasButacasDTO = new List<RoomSeatDTO>();

            foreach (var grupo in gruposPorSala)
            {
                var primer = grupo.FirstOrDefault();

                var roomName = primer?.IdSalaNavigation?.NomSala ?? string.Empty;

                var seats = grupo
                    .Where(g => g.IdButacaNavigation != null)
                    .Select(g => new SeatDTO
                    {
                        SeatNumber = g.IdButacaNavigation?.NumButaca,
                        SeatRow = g.IdButacaNavigation?.FilaButaca
                    })
                    .DistinctBy(s => (s.SeatRow, s.SeatNumber))
                    .ToList();

                var dto = new RoomSeatDTO
                {
                    Room = new RoomDTO { Name = roomName },
                    Seats = seats
                };

                salasButacasDTO.Add(dto);
            }

            return salasButacasDTO;
        }

        public async Task<IEnumerable<TiposCliente>> GetAllTipoClientes()
        {
            return await _repository.GetAllTipoClientes();
        }

        public async Task<IEnumerable<TiposContacto>> GetAllTipoContactos()
        {
            return await _repository.GetAllTipoContactos();
        }

        public async Task<IEnumerable<Role>> GetAllEmpleadosRoles()
        {
            return await _repository.GetAllEmpleadosRoles();
        }
    }
}
