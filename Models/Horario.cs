namespace SistemaAcademicoAPI.Models
{
    public class Horario
    {
        public int Id { get; set; }

        public int CursoId { get; set; }
        public Curso? Curso { get; set; }

        public int DocenteId { get; set; }
        public Docente? Docente { get; set; }

        public string Dia { get; set; } = string.Empty;

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFin { get; set; }

        public string Aula { get; set; } = string.Empty;
    }
}