using System.ComponentModel.DataAnnotations;

namespace PruebaExpress.DTOs
{
    public class EmpresaRequest
    {
        [Required]
        [StringLength(80)]
        public string NombreEmpresa { get; set; } = null!;

        [Required]
        [StringLength(80)]
        public string Direccion { get; set; } = null!;
    }
}
