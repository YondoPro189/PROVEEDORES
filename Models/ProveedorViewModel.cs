using System.ComponentModel.DataAnnotations;

namespace PROVEEDORES.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
    }
}
