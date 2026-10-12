namespace PetCare.Application.Features.Vacunas.DTOs;

public class CreateVacunaRequestDto {
    public string Nombre { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
}