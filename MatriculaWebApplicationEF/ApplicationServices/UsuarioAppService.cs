using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<string> TieneAccesoUsuario(string usuarioId, string contrasenia)
        {
            var usuario = await _baseDatos.Usuarios.FirstOrDefaultAsync(q => q.UsuarioId == usuarioId
            && q.Contrasenia == contrasenia);


            var respuestaDomain = _usuarioDomainServices.TieneAcceso(usuario);

            bool vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }

            return "sucess";

        }

    }
}
