using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class PaisHacerDomainService
    {
        public string RegistrarPais(PaisHacer paisRequest)
        {
            var esName = paisRequest.Nombre != "";
            if (esName)
            {
                return "El nombre no es es inválido";
            }


            return null;
        }
    }
}
