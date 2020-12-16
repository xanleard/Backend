using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UnitTestEstudiante
    {
        [TestMethod]
        public void ValidarEdadEstudianteMenorA18()
        {
            //AAA

            //Arrange
            EstudianteDomainService estudianteDomainService = new EstudianteDomainService();
            Estudiante estudiante = new Estudiante();
            estudiante.Nombre = "Test Vanguardia";
            estudiante.Edad = 14;
            estudiante.Sexo = "M";

            //Act
            var respuesta =  estudianteDomainService.RegistrarEstudiante(estudiante);

            //Assert
            Assert.AreEqual("Edad es inválida, debe ser mayor a 18", respuesta);
        }

        [TestMethod]
        public void ValidarEdadEstudianteMayorA18()
        {
            //AAA

            //Arrange
            EstudianteDomainService estudianteDomainService = new EstudianteDomainService();
            Estudiante estudiante = new Estudiante();
            estudiante.Nombre = "Test Vanguardia";
            estudiante.Edad = 20;
            estudiante.Sexo = "M";

            //Act
            var respuesta = estudianteDomainService.RegistrarEstudiante(estudiante);

            //Assert
            Assert.AreEqual(null, respuesta);
        }

    }
}
