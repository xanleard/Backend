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
            return await _baseDatos.Profesor.ToListAsync();
        }
    }

   
}
