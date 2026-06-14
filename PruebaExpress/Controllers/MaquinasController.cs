using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaApiExpress.Models;
using PruebaExpress.DTOs;
using PruebaExpress.Models;

namespace PruebaExpress.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaquinasController : ControllerBase
    {

        // Este bloque de codigo sirve para inyectar el contexto de la base de datos en el controlador,
        // lo que nos permite acceder a los datos de la base de datos a través del contexto.
        private readonly AppDbContext _context; // readonly significa que esta variable solo se puede asignar en el constructor y no se puede modificar después

        public MaquinasController(AppDbContext context) // constructor
        {
            _context = context;
        }

        [HttpGet] // Obtener todos
        public async Task<ActionResult<IEnumerable<Maquina>>> GetMaquinas()
        {
            var maquinas = await _context.Maquinas.ToListAsync(); // ToListAsync() devuelve una lista de objetos
            return Ok(maquinas); // el ok devuelve un código de estado HTTP 200 junto con los datos de las máquinas en formato JSON
        }

        [HttpGet("{id}")] // Obtener por id 
        // Espera un parámetro en la URL, ese número entra directo a la variable int id
        public async Task<ActionResult<Maquina>> GetMaquina(int id)
        {
            var maquina = await _context.Maquinas.FindAsync(id); // FindAsync busca un registro en la base de datos por su clave primaria 

            if (maquina == null)
                return NotFound(new { mensaje = "El Id de la maquina no existe" });

            return Ok(maquina);
        }

        [HttpPost] // Crear
        public async Task<ActionResult<Maquina>> PostMaquina(MaquinaRequest maquinaDto)
        {
            var nuevaMaquina = new Maquina
            {
                Nombre = maquinaDto.Nombre,
                AñoCreacion = maquinaDto.AñoCreacion,
                IdEmpresa = maquinaDto.IdEmpresa
            };

            _context.Maquinas.Add(nuevaMaquina); // Agrega la nueva máquina al contexto de la base de datos
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            // que lo explique mejor: CreatedAtAction es un método que se utiliza para devolver una respuesta
            // HTTP 201 (Created) cuando se ha creado un nuevo recurso. En este caso, se está utilizando para
            // indicar que se ha creado una nueva máquina. El primer parámetro es el nombre de la acción que
            // se utilizará para obtener la máquina recién creada (en este caso, GetMaquina). El segundo
            // parámetro es un objeto anónimo que contiene los parámetros necesarios para construir la URL
            // de la máquina recién creada (en este caso, el id de la máquina). El tercer parámetro es el
            //  objeto de la máquina recién creada que se incluirá en el cuerpo de la respuesta.

            return CreatedAtAction(nameof(GetMaquina), new { id = nuevaMaquina.Id }, nuevaMaquina); // Toda esta linea significa que se ha creado un nuevo recurso (máquina) y devuelve un código de estado HTTP 201 junto con la ubicación del nuevo recurso en la cabecera de la respuesta y el objeto de la máquina creada en el cuerpo de la respuesta.
        }

        [HttpPut("{id}")] // Modificar
        public async Task<IActionResult> PutMaquina(int id, MaquinaRequest MaquinaDto)
        {
            // Buscamos primero si la Maquina existe en la base de datos
            var MaquinaExistente = await _context.Maquinas.FindAsync(id);

            if (MaquinaExistente == null)
                return NotFound(new { mensaje = "Maquina no existe" });

            // Actualizamos solo los campos necesarios
            MaquinaExistente.Nombre = MaquinaDto.Nombre;
            MaquinaExistente.AñoCreacion = MaquinaDto.AñoCreacion;
            MaquinaExistente.IdEmpresa = MaquinaDto.IdEmpresa;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Maquinas.Any(e => e.Id == id)) return NotFound();
                throw;
            }

            return Ok(MaquinaExistente); 
        }


        [HttpDelete("{id}")] // Eliminar
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            // Buscamos que exista
            var maquina = await _context.Maquinas.FindAsync(id);
            if (maquina == null)
                return NotFound( new { mensaje = "Maquina no existe" });

            _context.Maquinas.Remove(maquina);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Maquina eliminada" });
        }
    }
}
