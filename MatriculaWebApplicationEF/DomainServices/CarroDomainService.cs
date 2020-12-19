using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class CarroDomainService
    {
        public string RegistrarCarro(Carro carroRequest)
        {
            var esSexoValid = carroRequest.Anio != 0;
            if (esSexoValid)
            {
                return null;
            }

            return "El año es valido";
        }

    }
}
