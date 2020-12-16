using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.ApplicationServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatriculaWebApplicationEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {

        private readonly UniversidadDataContext _baseDatos;
        private readonly CursoAppService _cursoAppService;
        public CursoController(UniversidadDataContext baseDeDatos)
        {
            _baseDatos = baseDeDatos;
            
            if (_baseDatos.Cursos.Count() == 0)
            {
                _baseDatos.Cursos.Add(new Curso { Nombre = "Algebra" });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return await _baseDatos.Cursos.ToListAsync();
        }



        // GET: api/Curso/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(long id)
        {
            var cursos = await _baseDatos.Cursos.FirstOrDefaultAsync(q => q.Id == id);

            if (cursos == null)
            {
                return NotFound();
            }

            return cursos;
        }


        // POST: api/Curso
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso item)
        {
            //var respuesta = await _cursoAppService.RegistrarCurso(item);

            //if (respuesta != null)
            //{
            //    return BadRequest(respuesta);
            //}

            return CreatedAtAction(nameof(GetCurso), new { id = item.Id }, item);
        }

        // POST Rango: api/Curso
        [HttpPost("rango")]
        public async Task<ActionResult<Curso>> PostCurso(IEnumerable<Curso> items)
        {
            _baseDatos.Cursos.AddRange(items);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCursos), items);
        }


        // DELETE: api/Curso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _baseDatos.Cursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            _baseDatos.Cursos.Remove(curso);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // DELETE Range: api/Cursos/5
        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteCursos(IEnumerable<int> ids)
        {
            IEnumerable<Curso> cursos = _baseDatos.Cursos.Where(q => ids.Contains(q.Id));

            if (cursos == null)
            {
                return NotFound();
            }

            _baseDatos.Cursos.RemoveRange(cursos);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }


        // PUT: api/Curso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            Curso curso = await _baseDatos.Cursos.FirstOrDefaultAsync(q => q.Id == item.Id);
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
