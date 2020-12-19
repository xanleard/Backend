using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Carro> Carros { get; set; }
    }
}
