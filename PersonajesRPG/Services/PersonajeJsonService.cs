using System.Text.Json;
using PersonajesRPG.Models;

namespace PersonajesRPG.Services;

public class PersonajeJsonService
{
    private readonly string _rutaArchivo;

    public PersonajeJsonService(IWebHostEnvironment environment)
    {
        _rutaArchivo = Path.Combine(environment.ContentRootPath, "Data", "personajes.json");
    }

    public async Task<List<Personaje>> ObtenerPersonajesAsync()
    {
        if (!File.Exists(_rutaArchivo))
        {
            return new List<Personaje>();
        }

        string json = await File.ReadAllTextAsync(_rutaArchivo);

        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<Personaje>();
        }

        return JsonSerializer.Deserialize<List<Personaje>>(json) ?? new List<Personaje>();
    }

    public async Task GuardarPersonajesAsync(List<Personaje> personajes)
    {
        string carpeta = Path.GetDirectoryName(_rutaArchivo)!;

        if (!Directory.Exists(carpeta))
        {
            Directory.CreateDirectory(carpeta);
        }

        JsonSerializerOptions opciones = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(personajes, opciones);

        await File.WriteAllTextAsync(_rutaArchivo, json);
    }
}