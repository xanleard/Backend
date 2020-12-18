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
    public class CursoTest
    {

        [TestMethod]
        public void ValidarNombreCurso()
        {
            //AAA

            //Arrange
            CursoDomainService cursoDomainService = new CursoDomainService();
            Curso curso = new Curso();
            curso.Nombre = "Algebra";


            //Act
            var respuesta = cursoDomainService.ValidarNombre(curso.Nombre);

            //Assert
            Assert.IsTrue(respuesta);
        }


    }
}
