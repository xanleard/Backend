using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class CarroAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly CarroDomainService  _carroDomainServices;

        public CarroAppService(UniversidadDataContext baseDatos, CarroDomainService carroDomainService)
        {
            _baseDatos = baseDatos;
            _carroDomainServices = carroDomainService;
        }

        public async Task<string> RegistrarCarro(Carro carroRequest)
        {
            var carro = _baseDatos.Carro.FirstOrDefault(q => q.Id == carroRequest.Id);

            var carroExiste = carro != null;
            if (carroExiste)
            {
                return "El carro ya existe";
            }

            var mo = _baseDatos.Modelo.FirstOrDefault(q => q.Id == carroRequest.ModeloId);
            var noExistemo = mo == null;
            if (noExistemo)
            {
                return "El Modelo no existe";
            }


            var respuestaDomain = _carroDomainServices.RegistrarCarro(carroRequest);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Carro.Add(carroRequest);

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
