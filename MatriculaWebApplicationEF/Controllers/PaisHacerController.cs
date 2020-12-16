using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.ApplicationServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatriculaWebApplicationEF.DomainServices;

namespace MatriculaWebApplicationEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisHacerController : Controller
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly PaisHacerAppService _paisAppServices;

        public PaisHacerController(UniversidadDataContext baseDeDatos, PaisHacerAppService paisHacerAppService)
        {
            _baseDatos = baseDeDatos;
            _paisAppServices = paisHacerAppService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisHacer>>> GetPaisHacers()
        {
            return await _baseDatos.PaisHacer.ToListAsync();
         }

        // GET: api/PaisHacer/1
        [HttpGet("{id}")]
        public async Task<ActionResult<PaisHacer>> GetPaisHacer(long id)
        {
            var pais = await _baseDatos.PaisHacer.FirstOrDefaultAsync(q => q.Id == id);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        // POST: api/PaisHacer
        [HttpPost]
        public async Task<ActionResult<Curso>> PostPaisHacer(PaisHacer item)
        {
            var respuesta = await _paisAppServices.RegistrarCurso(item);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetPaisHacer), new { id = item.Id }, item);
        }

        // POST Rango: api/PaisHacer
        [HttpPost("rango")]
        public async Task<ActionResult<PaisHacer>> PostPaisHacer(IEnumerable<PaisHacer> items)
        {
            _baseDatos.PaisHacer.AddRange(items);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaisHacers), items);
        }


        // DELETE: api/PaisHacer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaisHacer(int id)
        {
            var pais = await _baseDatos.PaisHacer.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            _baseDatos.PaisHacer.Remove(pais);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // DELETE Range: api/PaisHacer/5
        [HttpDelete("rango")]
        public async Task<IActionResult> DeletePaisHacers(IEnumerable<int> ids)
        {
            IEnumerable<PaisHacer> pais = _baseDatos.PaisHacer.Where(q => ids.Contains(q.Id));

            if (pais == null)
            {
                return NotFound();
            }

            _baseDatos.PaisHacer.RemoveRange(pais);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // PUT: api/PaisHacer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaisHacer(int id, PaisHacer item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            PaisHacer pais = await _baseDatos.PaisHacer.FirstOrDefaultAsync(q => q.Id == item.Id);
            if (pais == null)
            {
                return NotFound("El pais no existe");
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");

        }

    }
}
