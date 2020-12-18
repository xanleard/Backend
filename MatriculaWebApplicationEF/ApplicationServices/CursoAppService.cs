using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class CursoAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly CursoDomainService _cursoDomainServices;

        public CursoAppService(UniversidadDataContext baseDatos, CursoDomainService cursoDomainServiceaseDatos)
        {
            _baseDatos = baseDatos;
            _cursoDomainServices = cursoDomainServiceaseDatos;
        }

        public async Task<string> RegistrarCurso(Curso cursoRequest)
        {
            var cursoe = _baseDatos.Cursos.FirstOrDefault(q => q.Id == cursoRequest.Id);

            var cursoeExiste = cursoe != null;
            if (cursoeExiste)
            {
                return "El Curso ya existe";
            }

            var respuestaDomain = _cursoDomainServices.RegistrarCurso(cursoRequest);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Cursos.Add(cursoRequest);

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
