using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice;

namespace TP_ProgramaciónII_PIPORAMA.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;
        public InvoiceService(IInvoiceRepository repository)
        {
            _repository = repository;
        }
        public Task<bool> AddInvoice(InvoiceDTO invoice)
        {
            var newInvoice = new Factura
            {
                IdClienteNavigation = new Cliente
                {
                    DniCliente = invoice.Client.ClientDni,
                    NomCliente = invoice.Client.ClientName,
                    ApeCliente = invoice.Client.ClientSurname
                },
                IdEmpleadoNavigation = new Empleado
                {
                    DniEmpleado = invoice.Employee.EmployeeDni,
                    NomEmpleado = invoice.Employee.EmployeeName,
                    ApeEmpleado = invoice.Employee.EmployeeSurname
                },
                Fecha = invoice.InvoiceDate,
                IdMedioPago = invoice.PaymentMethod.IdPaymentMethod,
                IdFormaCompra = invoice.PurchaseForm.IdFPurchaseForm,
                IdEstadoCompra = invoice.PurchaseStatus.IdPurchaseStatus,
                DetallesFacturas = invoice.DetailInvoices?.Select(df => new DetallesFactura
                {
                    IdConsumible = df.Consumable?.IdConsumable,
                    IdCombo = df.Combo?.IdCombo,
                    IdEntrada = df.Ticket?.TicketID,
                    IdPromocion = df.Promotion?.IdPromotion,
                    Precio = df.Price
                }).ToList(),
                Activo = true
            };
            return _repository.AddInvoice(newInvoice);
        }

        public Task<bool> DeleteInvoice(int id)
        {
            try
            { 
                return _repository.DeleteInvoice(id);
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
                Client = new ClientInvoiceDTO
                {
                    ClientDni = invoice.IdClienteNavigation.DniCliente,
                    ClientName = invoice.IdClienteNavigation.NomCliente,
                    ClientSurname = invoice.IdClienteNavigation.ApeCliente
                },
                Employee = new EmployeeInvoiceDTO
                {
                    EmployeeDni = invoice.IdEmpleadoNavigation!.DniEmpleado,
                    EmployeeName = invoice.IdEmpleadoNavigation.NomEmpleado,
                    EmployeeSurname = invoice.IdEmpleadoNavigation.ApeEmpleado
                },
                InvoiceDate = invoice.Fecha,
                PaymentMethod = new PaymentMethodDTO
                {
                    IdPaymentMethod = invoice.IdMedioPagoNavigation!.IdMedioPago,
                    PaymentMethod = invoice.IdMedioPagoNavigation.MedioPago
                },
                PurchaseForm = new PurchaseFormDTO
                {
                    IdFPurchaseForm = invoice.IdFormaCompraNavigation!.IdFormaCompra,
                    PurchaseForm = invoice.IdFormaCompraNavigation.FormaCompra1
                },
                PurchaseStatus = new PurchaseStatusDTO
                {
                    IdPurchaseStatus = invoice.IdEstadoCompraNavigation!.IdEstadoCompra,
                    Description = invoice.IdEstadoCompraNavigation.Descripcion
                },
                DetailInvoices = invoice.DetallesFacturas.Select(df => new DetailInvoiceDTO
                {
                    DetailInvoiceId = df.IdDetalle,
                    Price = df.Precio,
                    Consumable = df.IdConsumibleNavigation is not null ? new ConsumableDTO
                    {
                        IdConsumable = df.IdConsumibleNavigation.IdConsumible,
                        Name = df.IdConsumibleNavigation.NomConsumible,
                        Price = df.IdConsumibleNavigation.PreUnitario
                    } : null,
                    Combo = df.IdComboNavigation is not null ? new ComboDTO
                    {
                        IdCombo = df.IdComboNavigation.IdCombo,
                        Name = df.IdComboNavigation.NomCombo,
                        Consumables = df.IdComboNavigation.DetallesCombos.Select(dc => new ConsumableDTO
                        {
                            IdConsumable = dc.IdConsumibleNavigation.IdConsumible,
                            Name = dc.IdConsumibleNavigation.NomConsumible
                        }).ToList()
                    } : null,
                    Ticket = df.IdEntradaNavigation is not null ? new TicketDTO
                    {
                        TicketID = df.IdEntradaNavigation.IdEntrada,
                        Seat = new SeatDTO
                        {
                            SeatId = df.IdEntradaNavigation.IdButaca,
                            SeatNumber = df.IdEntradaNavigation.IdButacaNavigation.NumButaca,
                            SeatRow = df.IdEntradaNavigation.IdButacaNavigation.FilaButaca
                        }
                        ,
                        Function = new FunctionDTO
                        {
                            FunctionId = df.IdEntradaNavigation.IdFuncionNavigation.IdFuncion,
                            FunctionDate = df.IdEntradaNavigation.IdFuncionNavigation.Horario,
                            Film = new FilmDTO
                            {
                                FilmId = df.IdEntradaNavigation.IdFuncionNavigation.IdPeliculaNavigation.IdPelicula,
                                Title = df.IdEntradaNavigation.IdFuncionNavigation.IdPeliculaNavigation.NomPelicula
                            },
                            Room = new RoomDTO
                            {
                                RoomId = df.IdEntradaNavigation.IdFuncionNavigation.IdSalaNavigation.IdSala,
                                RoomName = df.IdEntradaNavigation.IdFuncionNavigation.IdSalaNavigation.NomSala
                            }
                        },
                    } : null,
                    Promotion = df.IdPromocionNavigation is not null ? new PromotionDTO
                    {
                        IdPromotion = df.IdPromocionNavigation.IdPromocion,
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
