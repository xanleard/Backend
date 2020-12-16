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
        private readonly PaisHacerAppServices _paisAppServices;

        public PaisHacerController(UniversidadDataContext baseDeDatos, PaisHacerAppServices paisHacerAppServices)
        {
            _baseDatos = baseDeDatos;
            _paisAppServices = paisHacerAppServices;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisHacer>>> GetPaisHacer()
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

    }
}
