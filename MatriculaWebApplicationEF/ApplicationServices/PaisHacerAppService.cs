using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class PaisHacerAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly PaisHacerDomainService _paisDomainServices;

        public PaisHacerAppService(UniversidadDataContext baseDatos, PaisHacerDomainService paisHacerDomainServiceaseDatos)
        {
            _baseDatos = baseDatos;
            _paisDomainServices = paisHacerDomainServiceaseDatos;
        }

        public async Task<string> RegistrarCurso(PaisHacer paisHacerRequest)
        {
            var pais = _baseDatos.Cursos.FirstOrDefault(q => q.Id == paisHacerRequest.Id);

            var cursoeExiste = pais != null;
            if (cursoeExiste)
            {
                return "El pais ya existe";
            }

            var respuestaDomain = _paisDomainServices.RegistrarPais(paisHacerRequest);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.PaisHacer.Add(paisHacerRequest);

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
