using System.ComponentModel.DataAnnotations;

namespace GestorTareas.Models
{
    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }

    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Máximo 500 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "La materia es obligatoria")]
        public string Materia { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha límite es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaLimite { get; set; }

        public Prioridad Prioridad { get; set; } = Prioridad.Media;

        public bool Completada { get; set; }
    }
}