using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaApiExpress.Models;
using PruebaExpress.DTOs;

namespace PruebaApiExpress.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpresasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            var empresas = await _context.Empresas.ToListAsync();
            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa == null) return NotFound(new { mensaje = "Empresa no encontrada" });

            return Ok(empresa);
        }

        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(EmpresaRequest empresaDto)
        {
            // Mapeamos los datos del DTO a la entidad real de la Base de Datos
            var nuevaEmpresa = new Empresa
            {
                NombreEmpresa = empresaDto.NombreEmpresa,
                Direccion = empresaDto.Direccion
            };

            _context.Empresas.Add(nuevaEmpresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpresa), new { id = nuevaEmpresa.Id }, nuevaEmpresa);
        }

        // 4. PUT: api/Empresas/5 (ACTUALIZAR)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(int id, EmpresaRequest empresaDto)
        {
            // Buscamos primero si la empresa existe en la base de datos
            var empresaExistente = await _context.Empresas.FindAsync(id);

            if (empresaExistente == null)
                return NotFound(new { mensaje = "Empresa no encontrada" });

            // Actualizamos solo los campos necesarios
            empresaExistente.NombreEmpresa = empresaDto.NombreEmpresa;
            empresaExistente.Direccion = empresaDto.Direccion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Empresas.Any(e => e.Id == id)) return NotFound();
                throw;
            }

            return NoContent(); // Retorna 204
        }

        // 5. DELETE: api/Empresas/5 (ELIMINAR)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null) return NotFound();

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}