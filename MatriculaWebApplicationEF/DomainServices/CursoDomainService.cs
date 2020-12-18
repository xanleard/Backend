using MatriculaWebApplicationEF.Models;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class CursoDomainService
    {
        public string RegistrarCurso(Curso cursoRequest)
        {
            var esName = cursoRequest.Nombre != "";
            if (esName)
            {
                return null;
            }
           

            return "El nombre no es es inválido";
        }

        public bool ValidarNombre(string nombre)
        {
            if (nombre != "")
            {
                return true;
            }
            return false;

        }
    }
}
