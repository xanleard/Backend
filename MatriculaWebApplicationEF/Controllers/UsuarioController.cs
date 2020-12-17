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
                _baseDatos.Usuarios.Add(new Usuario { UsuarioId = "jaleman", Contrasenia = "123", EstaActivo = true });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _baseDatos.Usuarios.ToListAsync();
        }

        // GET: api/Estudiante/1
        [HttpGet("{usuarioId}/{contrasenia}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string usuarioId, string contrasenia)
        {
            var response = await _usuarioAppService.TieneAccesoUsuario(usuarioId, contrasenia);

            if (response != "success")
            {
                return BadRequest(response);

            }
            return Ok("success");
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario item)
        {
            //var respuesta = await _usuarioAppService.RegistrarUsuario(item);

            //if (respuesta != null)
            //{
            //    return BadRequest(respuesta);
            //}

            return CreatedAtAction(nameof(GetUsuario), new { id = item.UsuarioId }, item);
        }

        // POST Rango: api/Usuario
        [HttpPost("rango")]
        public async Task<ActionResult<Usuario>> PostUsuario(IEnumerable<Usuario> items)
        {
            _baseDatos.Usuarios.AddRange(items);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarios), items);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _baseDatos.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _baseDatos.Usuarios.Remove(usuario);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // DELETE Range: api/Usuario/5
        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteCursos(IEnumerable<string> ids)
        {
            IEnumerable<Usuario> usuarios = _baseDatos.Usuarios.Where(q => ids.Contains(q.UsuarioId));

            if (usuarios == null)
            {
                return NotFound();
            }

            _baseDatos.Usuarios.RemoveRange(usuarios);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(string id, Usuario item)
        {
            if (id != item.UsuarioId)
            {
                return BadRequest();
            }

            Usuario usuario = await _baseDatos.Usuarios.FirstOrDefaultAsync(q => q.UsuarioId == item.UsuarioId);
            if (usuario == null)
            {
                return NotFound("El Usuario no existe");
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");

        }

    }
}
