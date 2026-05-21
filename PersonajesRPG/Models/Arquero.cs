using System.ComponentModel.DataAnnotations;

namespace PersonajesRPG.Models;

public class Arquero : Personaje
{
    [Required(ErrorMessage = "El tipo de arco es obligatorio")]
    public string TipoArco { get; set; } = string.Empty;

    [Range(0, 100, ErrorMessage = "La precisión debe estar entre 0 y 100")]
    public int Precision { get; set; }
}