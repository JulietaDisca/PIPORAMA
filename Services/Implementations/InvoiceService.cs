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
            throw new NotImplementedException();
        }

        public Task<bool> DeleteInvoice(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoices()
        {
            try
            {
                IEnumerable<Factura> invoices = await _repository.GetAllInvoices();
                return invoices.Select(f => new InvoiceDTO
                { 
                    InvoiceId = f.IdFactura,
                    Client = new ClientDTO
                    {
                        Codigo = f.IdClienteNavigation!.IdCliente,
                        Nombre = f.IdClienteNavigation.NomCliente,
                        Apellido = f.IdClienteNavigation.ApeCliente,
                        IdTipoCliente = f.IdClienteNavigation.IdTipoCliente,
                        IdBarrio = f.IdClienteNavigation.IdBarrio,
                        IdContacto = f.IdClienteNavigation.IdContacto
                    },
                    Employee = new EmployeeDTO
                    {
                        IdEmpleado = f.IdEmpleadoNavigation!.IdEmpleado,
                        NomEmpleado = f.IdEmpleadoNavigation.NomEmpleado,
                        ApeEmpleado = f.IdEmpleadoNavigation.ApeEmpleado,
                        IdBarrio = f.IdEmpleadoNavigation.IdBarrio,
                        IdContacto = f.IdEmpleadoNavigation.IdContacto
                    },
                    InvoiceDate = f.Fecha,
                    PaymentMethod = new PaymentMethodDTO
                    {
                        IdPaymentMethod = f.IdMedioPagoNavigation!.IdMedioPago,
                        PaymentMethod = f.IdMedioPagoNavigation.MedioPago
                    },
                    PurchaseForm = new PurchaseFormDTO
                    {
                        IdFPurchaseForm= f.IdFormaCompraNavigation!.IdFormaCompra,
                        PurchaseForm =  f.IdFormaCompraNavigation.FormaCompra1
                    },
                    PurchaseStatus = new PurchaseStatusDTO
                    {
                        IdPurchaseStatus = f.IdEstadoCompraNavigation!.IdEstadoCompra,
                        Description = f.IdEstadoCompraNavigation.Descripcion
                    },
                    DetailInvoices = f.DetallesFacturas.Select(df => new DetailInvoiceDTO
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
                                Name = dc.IdConsumibleNavigation.NomConsumible,
                                Price = dc.IdConsumibleNavigation.PreUnitario
                            }).ToList()
                        } : null,
                        Ticket = df.IdEntradaNavigation is not null ? new TicketDTO
                        {
                            TicketID = df.IdEntradaNavigation.IdEntrada,
                            FunctionID = df.IdEntradaNavigation.IdFuncion,
                            SeatID = df.IdEntradaNavigation.IdButaca,
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
                                FilmId = df.IdEntradaNavigation.IdFuncionNavigation.IdPelicula,
                                RoomId = df.IdEntradaNavigation.IdFuncionNavigation.IdSala,
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
                            DiscountPercentage = df.IdPromocionNavigation.ValorDescuento,
                            StartDate = df.IdPromocionNavigation.VigenciaDesde,
                            EndDate = df.IdPromocionNavigation.VigenciaHasta
                        } : null
                    }).ToList()
                    ,
                    IsActive = f.Activo
                }
                ).ToList();

            }
        
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las facturas", ex);
            }
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
                return new InvoiceDTO
                { 
                    InvoiceId = invoice.IdFactura,
                    Client = new ClientDTO
                    {
                        Codigo = invoice.IdClienteNavigation!.IdCliente,
                        Nombre = invoice.IdClienteNavigation.NomCliente,
                        Apellido = invoice.IdClienteNavigation.ApeCliente,
                        IdTipoCliente = invoice.IdClienteNavigation.IdTipoCliente,
                        IdBarrio = invoice.IdClienteNavigation.IdBarrio,
                        IdContacto = invoice.IdClienteNavigation.IdContacto
                    },
                    Employee = new EmployeeDTO
                    {
                        IdEmpleado = invoice.IdEmpleadoNavigation!.IdEmpleado,
                        NomEmpleado = invoice.IdEmpleadoNavigation.NomEmpleado,
                        ApeEmpleado = invoice.IdEmpleadoNavigation.ApeEmpleado,
                        IdBarrio = invoice.IdEmpleadoNavigation.IdBarrio,
                        IdContacto = invoice.IdEmpleadoNavigation.IdContacto
                    },
                    InvoiceDate = invoice.Fecha,
                    PaymentMethod = new PaymentMethodDTO
                    {
                        IdPaymentMethod = invoice.IdMedioPagoNavigation!.IdMedioPago,
                        PaymentMethod = invoice.IdMedioPagoNavigation.MedioPago
                    },
                    PurchaseForm = new PurchaseFormDTO
                    {
                        IdFPurchaseForm= invoice.IdFormaCompraNavigation!.IdFormaCompra,
                        PurchaseForm =  invoice.IdFormaCompraNavigation.FormaCompra1
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
                                Name = dc.IdConsumibleNavigation.NomConsumible,
                                Price = dc.IdConsumibleNavigation.PreUnitario
                            }).ToList()
                        } : null,
                        Ticket = df.IdEntradaNavigation is not null ? new TicketDTO
                        {
                            TicketID = df.IdEntradaNavigation.IdEntrada,
                            FunctionID = df.IdEntradaNavigation.IdFuncion,
                            SeatID = df.IdEntradaNavigation.IdButaca,
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
                                FilmId = df.IdEntradaNavigation.IdFuncionNavigation.IdPelicula,
                                RoomId = df.IdEntradaNavigation.IdFuncionNavigation.IdSala,
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
                            DiscountPercentage = df.IdPromocionNavigation.ValorDescuento,
                            StartDate = df.IdPromocionNavigation.VigenciaDesde,
                            EndDate = df.IdPromocionNavigation.VigenciaHasta
                        } : null
                    }).ToList()
                    ,
                    IsActive = invoice.Activo
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la factura por ID", ex);
            }
        }
    }
}
