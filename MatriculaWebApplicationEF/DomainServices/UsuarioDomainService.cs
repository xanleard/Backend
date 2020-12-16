using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class UsuarioDomainService
    {
        public string RegistrarUsuario(Usuario usuarioRequest)
        {
            var esName = usuarioRequest.Nombre != "";
            if (esName)
            {
                return "El nombre no es es inválido";
            }


            return null;
        }

    }
}
