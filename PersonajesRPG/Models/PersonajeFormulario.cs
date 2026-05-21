using System.ComponentModel.DataAnnotations;

namespace PersonajesRPG.Models;

public class PersonajeFormulario : IValidatableObject
{
    [Required(ErrorMessage = "Debe seleccionar un tipo de personaje")]
    public string TipoPersonaje { get; set; } = string.Empty;

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    [Range(1, 99, ErrorMessage = "El nivel debe estar entre 1 y 99")]
    public int Nivel { get; set; } = 1;

    [Range(1, 10000, ErrorMessage = "Los puntos de vida deben ser mínimo 1")]
    public int PuntosVida { get; set; } = 1;

    [Range(0, int.MaxValue, ErrorMessage = "La experiencia debe ser positiva")]
    public int Experiencia { get; set; }

    public string TipoArma { get; set; } = string.Empty;
    public int DefensaFisica { get; set; } = 1;

    public string EscuelaMagia { get; set; } = string.Empty;
    public int Mana { get; set; } = 1;

    public string TipoArco { get; set; } = string.Empty;
    public int Precision { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (TipoPersonaje == "Guerrero")
        {
            if (string.IsNullOrWhiteSpace(TipoArma))
            {
                yield return new ValidationResult(
                    "El tipo de arma es obligatorio",
                    new[] { nameof(TipoArma) }
                );
            }

            if (DefensaFisica < 1 || DefensaFisica > 100)
            {
                yield return new ValidationResult(
                    "La defensa física debe estar entre 1 y 100",
                    new[] { nameof(DefensaFisica) }
                );
            }
        }

        if (TipoPersonaje == "Mago")
        {
            if (string.IsNullOrWhiteSpace(EscuelaMagia))
            {
                yield return new ValidationResult(
                    "La escuela de magia es obligatoria",
                    new[] { nameof(EscuelaMagia) }
                );
            }

            if (Mana < 1)
            {
                yield return new ValidationResult(
                    "El mana debe ser mínimo 1",
                    new[] { nameof(Mana) }
                );
            }
        }

        if (TipoPersonaje == "Arquero")
        {
            if (string.IsNullOrWhiteSpace(TipoArco))
            {
                yield return new ValidationResult(
                    "El tipo de arco es obligatorio",
                    new[] { nameof(TipoArco) }
                );
            }

            if (Precision < 0 || Precision > 100)
            {
                yield return new ValidationResult(
                    "La precisión debe estar entre 0 y 100",
                    new[] { nameof(Precision) }
                );
            }
        }
    }
}