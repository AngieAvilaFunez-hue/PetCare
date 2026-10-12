namespace PetCare.Domain.Entities;

public class VacunaGlobal
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty; // Ej. Perro, Gato
}