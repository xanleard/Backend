using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class PaisTest
    {
        [TestMethod]
        public void ValidarNombre()
        {
            //AAA

            //Arrange
            PaisHacerDomainService cursoDomainService = new PaisHacerDomainService();
            PaisHacer curso = new PaisHacer();
            curso.Nombre = "HN";


            //Act
            var respuesta = cursoDomainService.ValidarNombre(curso.Nombre);

            //Assert
            Assert.IsTrue(respuesta);
        }
    }
}
