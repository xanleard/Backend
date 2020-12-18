using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestMatricula
{
    [TestClass]
    public class ProfesorTest
    {
        [TestMethod]
        public void ValidarNombre()
        {
            //AAA

            //Arrange
            ProfesorDomainService cursoDomainService = new ProfesorDomainService();
            Profesor curso = new Profesor();
            curso.Nombre = "HN";


            //Act
            var respuesta = cursoDomainService.ValidarNombre(curso.Nombre);

            //Assert
            Assert.IsTrue(respuesta);
        }
    }
}
