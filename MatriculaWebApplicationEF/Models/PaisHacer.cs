using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.Models
{
    public class PaisHacer
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Estudiante> Estudiantes { get; set; }
    }
}
