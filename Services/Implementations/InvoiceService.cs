using TP_ProgramaciónII_PIPORAMA.Data.DTOs;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

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
                    PaymentMethod = f.IdMedioPagoNavigation.MedioPago,
                    InvoiceOrigin = f.IdFormaCompraNavigation.FormaCompra1
                }).ToList();
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
                    PaymentMethod = invoice.IdMedioPagoNavigation.MedioPago,
                    InvoiceOrigin = invoice.IdFormaCompraNavigation.FormaCompra1
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la factura por ID", ex);
            }
        }
    }
}
