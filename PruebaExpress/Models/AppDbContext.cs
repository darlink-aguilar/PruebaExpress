using Microsoft.EntityFrameworkCore;
using PruebaExpress.Models;

namespace PruebaApiExpress.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet es una clase que representa una tabla en la base de datos
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Maquina> Maquinas{ get; set; }
    }
}