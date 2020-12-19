using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class ModeloDomainService
    {
        public string RegistrarCurso(Modelo modeloRequest)
        {
            var esName = modeloRequest.Nombre != "";
            if (esName)
            {
                return null;
            }


            return "El nombre no es es inválido";
        }

        public bool ValidarNombre(string nombre)
        {
            if (nombre != "")
            {
                return true;
            }
            return false;

        }
    }
}
