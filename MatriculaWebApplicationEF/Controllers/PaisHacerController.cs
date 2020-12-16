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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisHacer>>> GetPaisHacer()
        {
            return await _baseDatos.PaisHacer.ToListAsync();
         }

}
}
