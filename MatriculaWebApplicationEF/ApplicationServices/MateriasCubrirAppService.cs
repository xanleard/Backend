using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class MateriasCubrirAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly MateriasCubrirDomainService _materiaDomainServices;

        public MateriasCubrirAppService(UniversidadDataContext baseDatos, MateriasCubrirDomainService materiasCubrirDomainService )
        {
            _baseDatos = baseDatos;
            _materiaDomainServices = materiasCubrirDomainService;
        }

        public async Task<string> RegistrarMateria(MateriasCubrir materiaCubrirRequest)
        {
            var materia = _baseDatos.MateriasCubrir.FirstOrDefault(q => q.Id == materiaCubrirRequest.Id);

            var materiaExiste = materia != null;
            if (materiaExiste)
            {
                return "La materia ya existe";
            }

            var respuestaDomain = _materiaDomainServices.RegistrarMateria(materiaCubrirRequest);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.MateriasCubrir.Add(materiaCubrirRequest);

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
