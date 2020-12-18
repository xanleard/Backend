namespace MatriculaWebApplicationEF.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public int CursoId { get; set; }
        public int ProfesorId { get; set; }
        public int PaisHacerId { get; set; }
        public Curso Curso { get; set; }
        public PaisHacer PaisHacer { get; set; }
        public Profesor Profesor { get; set; }
    }
}
