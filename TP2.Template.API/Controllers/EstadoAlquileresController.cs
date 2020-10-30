using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP.Template.AccessData;
using TP2.Template.Domain.Entities;

namespace TP2.Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     class EstadoAlquileresController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public EstadoAlquileresController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/EstadoAlquileres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoAlquiler>>> GetEstadoAlquileres()
        {
            return await _context.EstadoAlquileres.ToListAsync();
        }

        // GET: api/EstadoAlquileres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoAlquiler>> GetEstadoAlquiler(int id)
        {
            var estadoAlquiler = await _context.EstadoAlquileres.FindAsync(id);

            if (estadoAlquiler == null)
            {
                return NotFound();
            }

            return estadoAlquiler;
        }

        // PUT: api/EstadoAlquileres/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoAlquiler(int id, EstadoAlquiler estadoAlquiler)
        {
            if (id != estadoAlquiler.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoAlquiler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoAlquilerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EstadoAlquileres    
        [HttpPost]
        public async Task<ActionResult<EstadoAlquiler>> PostEstadoAlquiler(EstadoAlquiler estadoAlquiler)
        {
            _context.EstadoAlquileres.Add(estadoAlquiler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoAlquiler", new { id = estadoAlquiler.Id }, estadoAlquiler);
        }

        // DELETE: api/EstadoAlquileres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoAlquiler>> DeleteEstadoAlquiler(int id)
        {
            var estadoAlquiler = await _context.EstadoAlquileres.FindAsync(id);
            if (estadoAlquiler == null)
            {
                return NotFound();
            }

            _context.EstadoAlquileres.Remove(estadoAlquiler);
            await _context.SaveChangesAsync();

            return estadoAlquiler;
        }

        private bool EstadoAlquilerExists(int id)
        {
            return _context.EstadoAlquileres.Any(e => e.Id == id);
        }
    }
}
