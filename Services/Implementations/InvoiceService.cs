using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice;
using Microsoft.EntityFrameworkCore;
using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly PIPORAMAContext _context;

        private readonly IInvoiceRepository _repository;
        private readonly IClientRepository _clientRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public InvoiceService(IInvoiceRepository repository, IClientRepository clientRepository, IEmployeeRepository employeeRepository,PIPORAMAContext context)
        {
            _repository = repository;
            _clientRepository = clientRepository;
            _employeeRepository = employeeRepository;
            _context = context;
        }
        public async Task<bool> AddInvoice(InvoiceDTO invoice)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.DniCliente == invoice.DniClient);
            if(cliente is null)
            {
                throw new Exception($"Cliente no encontrado con DNI: {invoice.DniClient}");
            }
            var empleado = await _employeeRepository.GetEmployeeByDni(invoice.DniEmployee);
            if(empleado is null)
            {
                throw new Exception($"Empleado no encontrado con DNI: {invoice.DniEmployee}");
            }
            var medioPago = await _repository.GetPaymentMethodByName(invoice.PaymentMethod);
            if(medioPago is null)
            {
                throw new Exception($"Medio de pago no encontrado: {invoice.PaymentMethod}");
            }
            var formaCompra = await _repository.GetPurchaseFormByName(invoice.PurchaseForm);
            if(formaCompra is null)
            {
                throw new Exception($"Forma de compra no encontrada: {invoice.PurchaseForm}");
            }
            var estadoCompra = await _repository.GetPurchaseStatusByName(invoice.PurchaseStatus);
            if(estadoCompra is null)
            {
                throw new Exception($"Estado de compra no encontrado: {invoice.PurchaseStatus}");
            }
            var detalles = new List<DetallesFactura>();

            if (invoice.DetailInvoices != null)
            {
                foreach (var df in invoice.DetailInvoices)
                {
                    var consumible = df.Consumable is not null ? await _repository.GetConsumableByName(df.Consumable) : null;
                    var combo = df.Combo is not null ? await _repository.GetComboByName(df.Combo) : null;
                    var promocion = df.Promotion is not null ? await _repository.GetPromotionByName(df.Promotion.Description) : null;

                    Entrada? entrada = null;
                    if (df.Ticket is not null)
                    {
                        var seat = await _repository.GetSeatByRowNumber(df.Ticket.Seat.SeatRow, df.Ticket.Seat.SeatNumber);
                        if (seat is null)
                        {
                            throw new Exception($"Butaca no encontrada: row={df.Ticket.Seat.SeatRow}, number={df.Ticket.Seat.SeatNumber}");
                        }

                        var movie = await _repository.GetMovieByTitle(df.Ticket.Function.Film);
                        if (movie is null)
                        {
                            throw new Exception($"Pelicula no encontrada: {df.Ticket.Function.Film}");
                        }

                        var room = await _repository.GetRoomByName(df.Ticket.Function.Room);
                        if (room is null)
                        {
                            throw new Exception($"Sala no encontrada: {df.Ticket.Function.Room}");
                        }

                        var function = await _repository.GetFunctionByMovieRoomDateAsync(movie.IdPelicula, room.IdSala, df.Ticket.Function.FunctionDate);

                        if (function is null)
                        {
                            throw new Exception($"Funcion no encontrada para peliculaId={movie.IdPelicula}, salaId={room.IdSala}, horario={df.Ticket.Function.FunctionDate}");
                        }

                        entrada = new Entrada
                        {
                            IdButacaNavigation = seat,
                            IdButaca = seat.IdButaca,
                            IdFuncionNavigation = function,
                            IdFuncion = function.IdFuncion
                        };
                    }

                    var detalle = new DetallesFactura
                    {
                        IdConsumibleNavigation = consumible,
                        IdConsumible = consumible is not null ? consumible.IdConsumible : null,
                        IdComboNavigation = combo,
                        IdCombo = combo is not null ? combo.IdCombo : null,
                        IdPromocionNavigation = promocion,
                        IdPromocion = promocion is not null ? promocion.IdPromocion : null,
                        IdEntradaNavigation = entrada,
                        Precio = df.Price
                    };

                    detalles.Add(detalle);
                }
            }

            var newInvoice = new Factura
            {
                IdClienteNavigation = cliente,
                IdCliente = cliente.IdCliente,
                IdEmpleadoNavigation = empleado,
                IdEmpleado = empleado.IdEmpleado,
                Fecha = invoice.InvoiceDate,
                IdMedioPagoNavigation = medioPago,
                IdMedioPago = medioPago.IdMedioPago,
                IdFormaCompraNavigation = formaCompra,
                IdFormaCompra = formaCompra.IdFormaCompra,
                IdEstadoCompraNavigation = estadoCompra,
                IdEstadoCompra = estadoCompra.IdEstadoCompra,
                DetallesFacturas = detalles,
                Activo = true
            };

            return await _repository.AddInvoice(newInvoice);
        }

        public async Task<bool> DeleteInvoice(int id)
        {
            try
            { 
                return await _repository.DeleteInvoice(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la factura. ", ex);
            }
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoices()
        {
            try
            {
                IEnumerable<Factura> invoices = await _repository.GetAllInvoices();
                IEnumerable<InvoiceDTO> invoicesDTO = invoices.Select(invoice => MappingDTO(invoice));
                return invoicesDTO;
            }
        
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las facturas. ", ex);
            }
        }
        public InvoiceDTO MappingDTO(Factura invoice)
        {
            var invoiceDTO = new InvoiceDTO
            {
                InvoiceId = invoice.IdFactura,
                DniClient = invoice.IdClienteNavigation!.DniCliente,
                DniEmployee = invoice.IdEmpleadoNavigation!.DniEmpleado,
                InvoiceDate = invoice.Fecha,
                PaymentMethod = invoice.IdMedioPagoNavigation!.MedioPago,
                PurchaseForm = invoice.IdFormaCompraNavigation!.FormaCompra1,
                PurchaseStatus = invoice.IdEstadoCompraNavigation!.Descripcion,
                DetailInvoices = invoice.DetallesFacturas.Select(df => new DetailInvoiceDTO
                {
                    Price = df.Precio,
                    Consumable = df.IdConsumibleNavigation is not null ? df.IdConsumibleNavigation.NomConsumible : null,
                    Combo = df.IdComboNavigation is not null ? df.IdComboNavigation.NomCombo : null,
                    Ticket = df.IdEntradaNavigation is not null ? new TicketDTO
                    {
                        Seat = new SeatDTO
                        {
                            SeatNumber = df.IdEntradaNavigation.IdButacaNavigation.NumButaca,
                            SeatRow = df.IdEntradaNavigation.IdButacaNavigation.FilaButaca
                        }
                        ,
                        Function = new FunctionDTO
                        {
                            FunctionDate = df.IdEntradaNavigation.IdFuncionNavigation.Horario,
                            Film =  df.IdEntradaNavigation.IdFuncionNavigation.IdPeliculaNavigation.NomPelicula,
                            Room =  df.IdEntradaNavigation.IdFuncionNavigation.IdSalaNavigation.NomSala
                        },
                    } : null,
                    Promotion = df.IdPromocionNavigation is not null ? new PromotionDTO
                    {
                        Description = df.IdPromocionNavigation.Descripcion,
                        DiscountPercentage = df.IdPromocionNavigation.ValorDescuento
                    } : null
                }).ToList()
                    ,
                IsActive = invoice.Activo
            };
            return invoiceDTO;
        }

        public async Task<InvoiceDTO?> GetInvoiceById(int id)
        {
            try
            {
                var invoice = await _repository.GetInvoiceById(id);
                if (invoice is null)
                {
                    return null;
                }
                return MappingDTO(invoice);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la factura por ID", ex);
            }
        }
    }
}
