using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class UsuarioDomainService
    {
        public string TieneAcceso(Usuario usuario)
        {
            var usuarioExiste = usuario == null;
            if (usuarioExiste)
            {
                return "El usuario o la contraseña no son válidos";
            }

            if (usuario.EstaActivo == false)
            {
                return "El usuario no está activo";
            }

            return "sucess";
        }

        public bool ValidarNombre(string nombre)
        {
            if (nombre != "")
            {
                return true;
            }
            return false;

        }

        public bool ValidarPass(string pass)
        {
            if (pass != "")
            {
                return true;
            }
            return false;

        }

        public bool ValidarActivo(bool isactive)
        {
            if (isactive)
            {
                return true;
            }
            return false;

        }


    }
}
