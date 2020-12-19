using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class ModeloAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly ModeloDomainService _modeloDomainServices;
        public ModeloAppService(UniversidadDataContext baseDatos, ModeloDomainService modeloDomainService)
        {
            _baseDatos = baseDatos;
            _modeloDomainServices = modeloDomainService;
        }


        public async Task<string> RegistrarModelo(Modelo modeloRequest)
        {
            var cursoe = _baseDatos.Modelo.FirstOrDefault(q => q.Id == modeloRequest.Id);

            var cursoeExiste = cursoe != null;
            if (cursoeExiste)
            {
                return "El Curso ya existe";
            }

            var respuestaDomain = _modeloDomainServices.RegistrarCurso(modeloRequest);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Modelo.Add(modeloRequest);

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
