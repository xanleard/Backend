using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestMatricula
{
    [TestClass]
    public class MateriaTest
    {
        [TestMethod]
        public void ValidarNombre()
        {
            //AAA

            //Arrange
            MateriasCubrirDomainService cursoDomainService = new MateriasCubrirDomainService();
            MateriasCubrir curso = new MateriasCubrir();
            curso.Nombre = "test";


            //Act
            var respuesta = cursoDomainService.ValidarNombre(curso.Nombre);

            //Assert
            Assert.IsTrue(respuesta);
        }
    }
}
