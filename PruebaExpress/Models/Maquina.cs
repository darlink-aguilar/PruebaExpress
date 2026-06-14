using PruebaApiExpress.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaExpress.Models
{
    [Table("Maquinas")]  
    public class Maquina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Nombre { get; set; } = null!; // El = null! es para decirle a C# que este campo no es nulo, aunque no le asignemos un valor por defecto

        [Required]
        public int AñoCreacion { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")] // Esta es la propiedad de navegación que establece la relación entre
                                  // Maquina y Empresa, indicando que IdEmpresa es la clave foránea que
                                  // se relaciona con la tabla Empresas
        public Empresa Empresa { get; set; } = null!;
    }
}
