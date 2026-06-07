namespace SistemaAcademicoAPI.Models
{
    public class Docente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;

        public ICollection<Horario>? Horarios { get; set; }
    }
}