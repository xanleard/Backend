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
    public class ModeloController : Controller
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly ModeloAppService _modeloAppService;

     
        public ModeloController(UniversidadDataContext context, ModeloAppService modeloAppService)
        {
            _baseDatos = context;
            _modeloAppService= modeloAppService;
        }


        // GET: api/Modelo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelo>>> GetModelos()
        {
            return await _baseDatos.Modelo.ToListAsync();
        }

        // GET: api/Modelo/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetModelo(long id)
        {
            var mod = await _baseDatos.Modelo.FirstOrDefaultAsync(q => q.Id == id);

            if (mod == null)
            {
                return NotFound();
            }

            return mod;
        }




        // POST: api/Modelo
        [HttpPost]
        public async Task<ActionResult<Modelo>> PostModelo(Modelo item)
        {
            var respuesta = await _modeloAppService.RegistrarModelo(item);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetModelo), new { id = item.Id }, item);
        }

        // POST Rango: api/Modelo
        [HttpPost("rango")]
        public async Task<ActionResult<Modelo>> PostModelo(IEnumerable<Modelo> items)
        {
            _baseDatos.Modelo.AddRange(items);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetModelos), items);
        }


        // DELETE: api/Modelo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            var mod = await _baseDatos.Modelo.FindAsync(id);

            if (mod == null)
            {
                return NotFound();
            }

            _baseDatos.Modelo.Remove(mod);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // DELETE Range: api/Modelo/5
        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteModelo(IEnumerable<int> ids)
        {
            IEnumerable<Modelo> mod = _baseDatos.Modelo.Where(q => ids.Contains(q.Id));

            if (mod == null)
            {
                return NotFound();
            }

            _baseDatos.Modelo.RemoveRange(mod);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // PUT: api/Modelo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelo(int id, Modelo item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }


            Modelo car = await _baseDatos.Modelo.AsNoTracking().FirstOrDefaultAsync(q => q.Id == item.Id);
            if (car == null)
            {
                return NotFound("El Modelo no existe");
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");

        }


    }
}
