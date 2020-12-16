using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class ProfesorDomainService
    {

        public string RegistrarProfesor(Profesor profesorRequest)
        {
            var esName = profesorRequest.Nombre != "";
            if (esName)
            {
                return "El nombre no es es inválido";
            }


            return null;
        }
    }
}
