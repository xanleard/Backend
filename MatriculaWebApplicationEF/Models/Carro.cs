using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Anio { get; set; }
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }

    }
}
