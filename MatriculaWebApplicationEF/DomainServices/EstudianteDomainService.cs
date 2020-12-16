using MatriculaWebApplicationEF.Models;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class EstudianteDomainService
    {
        public string RegistrarEstudiante(Estudiante estudianteRequest)
        {
            var esSexoValid = estudianteRequest.Sexo != "M" && estudianteRequest.Sexo != "F";
            if (esSexoValid)
            {
                return "El sexo es inválido";
            }

            var esEdadValida = estudianteRequest.Edad < 18;
            if (esEdadValida)
            {
                return "Edad es inválida, debe ser mayor a 18";
            }

            return null;
        }
    }
}
