using PruebaExpress.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaApiExpress.Models
{
    [Table("Empresas")] // Le decimos a EF que la tabla ya la creamos
    public class Empresa
    {
        [Key] // Llave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Esto significa que el Id aumenta automaticamente
        public int Id { get; set; }

        [Required] // No nula
        [StringLength(80)] // Maximo 80 caracteres
        public string NombreEmpresa { get; set; } = null!;

        [Required] // No nula
        [StringLength(80)] // Maximo 80 caracteres
        public string Direccion { get; set; } = null!;

        // Propiedad de navegación 
        ICollection<Maquina> Maquinas { get; set; } = new List<Maquina>(); 
    }
}