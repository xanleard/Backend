using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UsuariosTest
    {
        [TestMethod]
        public void ValidarNombre()
        {
            //AAA

            //Arrange
            UsuarioDomainService cursoDomainService = new UsuarioDomainService();
            Usuario curso = new Usuario();
            curso.UsuarioId = "HN";


            //Act
            var respuesta = cursoDomainService.ValidarNombre(curso.UsuarioId);

            //Assert
            Assert.IsTrue(respuesta);
        }

        [TestMethod]
        public void ValidarPass()
        {
            //AAA

            //Arrange
            UsuarioDomainService cursoDomainService = new UsuarioDomainService();
            Usuario curso = new Usuario();
            curso.Contrasenia = "HN";


            //Act
            var respuesta = cursoDomainService.ValidarPass(curso.Contrasenia);

            //Assert
            Assert.IsTrue(respuesta);
        }

        [TestMethod]
        public void ValidarActivo()
        {
            //AAA

            //Arrange
            UsuarioDomainService cursoDomainService = new UsuarioDomainService();
            Usuario curso = new Usuario();
            curso.EstaActivo = true;


            //Act
            var respuesta = cursoDomainService.ValidarPass(curso.Contrasenia);

            //Assert
            Assert.IsTrue(respuesta);
        }
    }
}
