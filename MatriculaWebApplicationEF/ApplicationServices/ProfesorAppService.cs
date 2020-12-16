using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class ProfesorAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly ProfesorDomainService _profesorDomainServices;

        public ProfesorAppService(UniversidadDataContext baseDatos, ProfesorDomainService profesorDomainService)
        {
            _baseDatos = baseDatos;
            _profesorDomainServices = profesorDomainService;
        }

        public async Task<string> RegistrarCurso(Profesor profesorRequest)
        {
            var prof = _baseDatos.Cursos.FirstOrDefault(q => q.Id == profesorRequest.Id);

            var profExiste = prof != null;
            if (profExiste)
            {
                return "El Profesor ya existe";
            }

            var profe = _baseDatos.Cursos.FirstOrDefault(q => q.Id == profesorRequest.Id);
            var noExisteprofe = profe == null;
            if (noExisteprofe)
            {
                return "El Profesor no existe";
            }


            var respuestaDomain = _profesorDomainServices.RegistrarProfesor(profesorRequest);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Profesor.Add(profesorRequest);

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
