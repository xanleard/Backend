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
    public class CarroController : Controller
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly CarroAppService _carroAppService;

        public CarroController(UniversidadDataContext context, CarroAppService carroAppService)
        {
            _baseDatos = context;
            _carroAppService = carroAppService;


        }

        // GET: api/Carro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarros()
        {
            return await _baseDatos.Carro.Include(q => q.Modelo).ToListAsync();
        }


        // GET: api/Carro/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetCarro(long id)
        {
            var car = await _baseDatos.Carro.FirstOrDefaultAsync(q => q.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // POST: api/PaisHacer
        [HttpPost]
        public async Task<ActionResult<Carro>> PostCarro(Carro item)
        {
            var respuesta = await _carroAppService.RegistrarCarro(item);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetCarro), new { id = item.Id }, item);
        }

        // POST Rango: api/PaisHacer
        [HttpPost("rango")]
        public async Task<ActionResult<Carro>> PostCarro(IEnumerable<Carro> items)
        {
            _baseDatos.Carro.AddRange(items);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarros), items);
        }

        // DELETE: api/Carro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            var carro = await _baseDatos.Carro.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            _baseDatos.Carro.Remove(carro);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // DELETE Range: api/Carro/5
        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteCarro(IEnumerable<int> ids)
        {
            IEnumerable<Carro> car = _baseDatos.Carro.Where(q => ids.Contains(q.Id));

            if (car == null)
            {
                return NotFound();
            }

            _baseDatos.Carro.RemoveRange(car);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(int id, Carro item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }


            Carro car = await _baseDatos.Carro.AsNoTracking().FirstOrDefaultAsync(q => q.Id == item.Id);
            if (car == null)
            {
                return NotFound("El car no existe");
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");

        }

    }
}
