using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PersonajesRPG.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$tipo")]
[JsonDerivedType(typeof(Guerrero), "Guerrero")]
[JsonDerivedType(typeof(Mago), "Mago")]
[JsonDerivedType(typeof(Arquero), "Arquero")]
public abstract class Personaje
{
    [Required(ErrorMessage = "El nombre del personaje es obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    [Range(1, 99, ErrorMessage = "El nivel debe estar entre 1 y 99")]
    public int Nivel { get; set; } = 1;

    [Range(1, 10000, ErrorMessage = "Los puntos de vida deben ser mínimo 1")]
    public int PuntosVida { get; set; } = 1;

    [Range(0, int.MaxValue, ErrorMessage = "La experiencia debe ser un número positivo")]
    public int Experiencia { get; set; }
}