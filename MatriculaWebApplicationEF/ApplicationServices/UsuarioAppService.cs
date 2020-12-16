using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class UsuarioAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly UsuarioDomainService _usuarioDomainServices;

        public UsuarioAppService(UniversidadDataContext baseDatos, UsuarioDomainService usuarioDomainService)
        {
            _baseDatos = baseDatos;
            _usuarioDomainServices = usuarioDomainService;
        }

        public async Task<string> RegistrarCurso(Usuario usuarioRequest)
        {
            var usu = _baseDatos.Usuarios.FirstOrDefault(q => q.Id == usuarioRequest.Id);

            var usuExiste = usu != null;
            if (usuExiste)
            {
                return "El Usuario ya existe";
            }

            var usuario = _baseDatos.Usuarios.FirstOrDefault(q => q.Id == usuarioRequest.Id);
            var noExisteUsuario = usuario == null;
            if (noExisteUsuario)
            {
                return "El Usuario no existe";
            }


            var respuestaDomain = _usuarioDomainServices.RegistrarUsuario(usuarioRequest);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Usuarios.Add(usuarioRequest);

            try
            {
                await _baseDatos.SaveChangesAsync();
                return null;
            }
            catch (Exception)
            {

                return "Oops! hubo un problema al guardar en la base de datos";
            }

        }

    }
}
