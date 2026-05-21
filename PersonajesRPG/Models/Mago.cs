using System.ComponentModel.DataAnnotations;

namespace PersonajesRPG.Models;

public class Mago : Personaje
{
    [Required(ErrorMessage = "La escuela de magia es obligatoria")]
    public string EscuelaMagia { get; set; } = string.Empty;

    [Range(1, 10000, ErrorMessage = "El mana debe ser mínimo 1")]
    public int Mana { get; set; } = 1;
}