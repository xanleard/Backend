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
                return "El nombre no es es inválido";
            }
           

            return null;
        }
    }
}
