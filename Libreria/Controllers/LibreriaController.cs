using Libreria.Data;
using Libreria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibreriaController : ControllerBase
    {
        private readonly DataContext _context;

        public LibreriaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            return await _context.Libros.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Libro>> AddLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return Ok(libro);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLibro(int id)
        {
            var libroDelete = await _context.Libros.FindAsync(id);

            if(libroDelete is null)
            {
                return NotFound($"Libro con id {id} no fue encontrado");
            }

            _context.Libros.Remove(libroDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Libro>> UpdateLibro(int id, Libro libro)
        {
            var libroUpdate = await _context.Libros.FindAsync(id);

            if(libroUpdate is null)
            {
                return NotFound($"Libro con id {id} no fue encontrado");
            }

            libroUpdate.Retirado = libro.Retirado;
            libroUpdate.Autores = libro.Autores;
            libroUpdate.NombreLibro = libro.NombreLibro;

            await _context.SaveChangesAsync();

            return Ok(libroUpdate);
        }
    }
}
