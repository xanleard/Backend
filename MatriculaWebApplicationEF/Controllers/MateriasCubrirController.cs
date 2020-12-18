using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWebApplicationEF.ApplicationServices;
using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculaWebApplicationEF.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MateriasCubrirController : Controller
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly MateriasCubrirAppService _materiaAppServices;

        public MateriasCubrirController(UniversidadDataContext baseDeDatos, MateriasCubrirAppService materiasCubrirAppService )
        {
            _baseDatos = baseDeDatos;
            _materiaAppServices = materiasCubrirAppService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MateriasCubrir>>> GetMateriasCubrir()
        {
            return await _baseDatos.MateriasCubrir.Include(q => q.Curso).ToListAsync();
        }

        // GET: api/MateriasCubrir/1
        [HttpGet("{id}")]
        public async Task<ActionResult<MateriasCubrir>> GetMateriasCubrirs(long id)
        {
            var materia = await _baseDatos.MateriasCubrir.Include(q => q.Curso).FirstOrDefaultAsync(q => q.Id == id);

            if (materia == null)
            {
                return NotFound();
            }

            return materia;
        }

        // POST: api/MateriasCubrir
        [HttpPost]
        public async Task<ActionResult<MateriasCubrir>> PostMateriasCubrir(MateriasCubrir item)
        {
            var respuesta = await _materiaAppServices.RegistrarMateria(item);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetMateriasCubrir), new { id = item.Id }, item);
        }

        // POST Rango: api/PaisHacer
        [HttpPost("rango")]
        public async Task<ActionResult<MateriasCubrir>> PostMateriasCubrir(IEnumerable<MateriasCubrir> items)
        {
            _baseDatos.MateriasCubrir.AddRange(items);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMateriasCubrirs), items);
        }

        // DELETE: api/MateriasCubrirs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateriasCubrir(int id)
        {
            var materia = await _baseDatos.MateriasCubrir.FindAsync(id);

            if (materia == null)
            {
                return NotFound();
            }

            _baseDatos.MateriasCubrir.Remove(materia);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // DELETE Range: api/MateriasCubrir/5
        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteMateriasCubrirs(IEnumerable<int> ids)
        {
            IEnumerable<MateriasCubrir> materia = _baseDatos.MateriasCubrir.Where(q => ids.Contains(q.Id));

            if (materia == null)
            {
                return NotFound();
            }

            _baseDatos.MateriasCubrir.RemoveRange(materia);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // PUT: api/MateriasCubrir/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateriasCubrir(int id, MateriasCubrir item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            MateriasCubrir materia = await _baseDatos.MateriasCubrir.FirstOrDefaultAsync(q => q.Id == item.Id);
            if (materia == null)
            {
                return NotFound("El materia no existe");
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");

        }

    }
}
