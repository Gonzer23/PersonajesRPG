using System.ComponentModel.DataAnnotations;

namespace PersonajesRPG.Models;

public class Guerrero : Personaje
{
    [Required(ErrorMessage = "El tipo de arma es obligatorio")]
    public string TipoArma { get; set; } = string.Empty;

    [Range(1, 100, ErrorMessage = "La defensa física debe estar entre 1 y 100")]
    public int DefensaFisica { get; set; } = 1;
}