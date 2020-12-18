using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class MateriasCubrirDomainService
    {
        public string RegistrarMateria(MateriasCubrir materiaRequest)
        {
            var esName = materiaRequest.Nombre != "";
            if (esName)
            {
                return null;
            }


            return "El nombre no es es inválido";
        }

    }
}
