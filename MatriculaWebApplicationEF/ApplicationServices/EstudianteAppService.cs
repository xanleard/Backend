using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class EstudianteAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly EstudianteDomainService _estudianteDomainServices;

        public EstudianteAppService(UniversidadDataContext baseDatos, EstudianteDomainService estudianteDomainServiceaseDatos)
        {
            _baseDatos = baseDatos;
            _estudianteDomainServices = estudianteDomainServiceaseDatos;
        }

        public async Task<string> RegistrarEstudiante(Estudiante estudianteRequest)
        {
            var estudiante = _baseDatos.Estudiantes.FirstOrDefault(q => q.Id == estudianteRequest.Id);

            var estudianteExiste = estudiante != null;
            if (estudianteExiste)
            {
                return "El estudiante ya existe";
            }

            var curso = _baseDatos.Cursos.FirstOrDefault(q => q.Id == estudianteRequest.CursoId);
            var noExisteCurso = curso == null;
            if (noExisteCurso)
            {
                return "El curso no existe";
            }


            var respuestaDomain = _estudianteDomainServices.RegistrarEstudiante(estudianteRequest);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Estudiantes.Add(estudianteRequest);

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
