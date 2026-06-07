namespace SistemaAcademicoAPI.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string CodigoCurso { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int Creditos { get; set; }
        public int Ciclo { get; set; }

        public ICollection<Matricula>? Matriculas { get; set; }
        public ICollection<Horario>? Horarios { get; set; }
    }
}