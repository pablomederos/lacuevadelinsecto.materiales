using System.ComponentModel.DataAnnotations;

namespace LaCuevaDelInsecto.Bridge.Models
{
    public class Persona
    {
        public int idPersona { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Nombre { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Apellido { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}
