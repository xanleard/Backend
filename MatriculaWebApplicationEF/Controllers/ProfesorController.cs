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
    public class ProfesorController : Controller
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly ProfesorAppService _profesorAppService;
        public ProfesorController(UniversidadDataContext baseDeDatos, ProfesorAppService profesorAppService)
        {
            _baseDatos = baseDeDatos;
            _profesorAppService = profesorAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesores()
        {
            return await _baseDatos.Profesores.ToListAsync();
        }

        // GET: api/Profesor/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(long id)
        {
            var pro = await _baseDatos.Profesores.FirstOrDefaultAsync(q => q.Id == id);

            if (pro == null)
            {
                return NotFound();
            }

            return pro;
        }

        // POST: api/Curso
        [HttpPost]
        public async Task<ActionResult<Profesor>> PostProfesor(Profesor item)
        {
            var respuesta = await _profesorAppService.RegistrarProfesor(item);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(_profesorAppService), new { id = item.Id }, item);
        }

        // POST Rango: api/Profesor
        [HttpPost("rango")]
        public async Task<ActionResult<Profesor>> PostCurso(IEnumerable<Profesor> items)
        {
            _baseDatos.Profesores.AddRange(items);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfesores), items);
        }

        // DELETE: api/Profesor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            var pro = await _baseDatos.Profesores.FindAsync(id);

            if (pro == null)
            {
                return NotFound();
            }

            _baseDatos.Profesores.Remove(pro);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // DELETE Range: api/Profesor/5
        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteCursos(IEnumerable<int> ids)
        {
            IEnumerable<Profesor> profesor = _baseDatos.Profesores.Where(q => ids.Contains(q.Id));

            if (profesor == null)
            {
                return NotFound();
            }

            _baseDatos.Profesores.RemoveRange(profesor);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // PUT: api/Profesor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesor(int id, Profesor item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            Profesor profesor = await _baseDatos.Profesores.FirstOrDefaultAsync(q => q.Id == item.Id);
            if (profesor == null)
            {
                return NotFound("El Profesor no existe");
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");

        }

    }

   
}
