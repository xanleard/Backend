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
    public class EstudianteController : ControllerBase
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly EstudianteAppService _estudianteAppService;

        // GET: /<controller>/
        public EstudianteController(UniversidadDataContext context, EstudianteAppService estudianteAppService)
        {
            _baseDatos = context;
            _estudianteAppService = estudianteAppService;

            if (_baseDatos.Estudiantes.Count() == 0)
            {
                _baseDatos.Estudiantes.Add(new Estudiante { Nombre = "Josue", Edad = 25, Sexo = "M", CursoId = 1 });
                _baseDatos.SaveChanges();
            }
        }


        // GET: api/Estudiante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            return await _baseDatos.Estudiantes.Include(q => q.Curso).ToListAsync();
        }

        // GET: api/Estudiante/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(long id)
        {
            var estudiante = await _baseDatos.Estudiantes.Include(q => q.Curso).FirstOrDefaultAsync(q => q.Id == id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        // POST: api/Estudiante
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante item)
        {
            var respuesta = await _estudianteAppService.RegistrarEstudiante(item);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetEstudiante), new { id = item.Id }, item);
        }

        // POST Rango: api/Estudiante
        [HttpPost("rango")]
        public async Task<ActionResult<Estudiante>> PostEstudiante(IEnumerable<Estudiante> items)
        {
            _baseDatos.Estudiantes.AddRange(items);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstudiantes), items);
        }


        // DELETE: api/Estudiante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _baseDatos.Estudiantes.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            _baseDatos.Estudiantes.Remove(estudiante);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // DELETE Range: api/Estudiante/5
        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteEstudiantes(IEnumerable<int> ids)
        {
            IEnumerable<Estudiante> estudiantes = _baseDatos.Estudiantes.Where(q => ids.Contains(q.Id));

            if (estudiantes == null)
            {
                return NotFound();
            }

            _baseDatos.Estudiantes.RemoveRange(estudiantes);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // PUT: api/Estudiante/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            Curso curso = await _baseDatos.Cursos.FirstOrDefaultAsync(q => q.Id == item.CursoId);
            if (curso == null)
            {
                return NotFound("El curso no existe");
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");

        }
    }
}
