using System.Text.Json.Serialization;
using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice
{
    public class EmployeeDTO
    {
        public int IdEmpleado { get; set; }
        public string DniEmpleado { get; set; }
        public string NomEmpleado { get; set; }
        public string ApeEmpleado { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public bool Activo { get; set; }

        public NeighborhoodDTO Barrio { get; set; }
        public ContactDTO Contacto { get; set; }
        public RoleDTO Rol { get; set; }
    }
}
