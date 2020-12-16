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
    public class UsuarioController : Controller
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly UsuarioAppService _usuarioAppService;
        public UsuarioController(UniversidadDataContext baseDeDatos, UsuarioAppService usuarioAppService)
        {
            _baseDatos = baseDeDatos;
            _usuarioAppService = usuarioAppService;


            if (_baseDatos.Usuarios.Count() == 0)
            {
                _baseDatos.Usuarios.Add(new Usuario { Nombre = "Algebra" , IsValid = true});
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetCursos()
        {
            return await _baseDatos.Usuarios.ToListAsync();
        }



        // GET: api/Usuario/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetCurso(long id)
        {
            var usuario = await _baseDatos.Usuarios.FirstOrDefaultAsync(q => q.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
    }
}
