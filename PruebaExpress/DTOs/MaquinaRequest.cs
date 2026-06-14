using System.ComponentModel.DataAnnotations;

namespace PruebaExpress.DTOs
{
    public class MaquinaRequest
    {
        [Required]
        [StringLength(80)]
        public string Nombre { get; set; } = null!;
        [Required]
        public int AñoCreacion { get; set; }
        [Required]
        public int IdEmpresa { get; set; }
    }
}
