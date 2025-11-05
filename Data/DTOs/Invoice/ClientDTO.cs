namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice
{
    public class ClientDTO
    {
        public int Codigo { get; set; }
        public string DniCliente { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int IdTipoCliente { get; set; }
        public int IdBarrio { get; set; }
        public bool Activo { get; set; }
        public ContactDTO Contacto { get; set; }
    }
}
