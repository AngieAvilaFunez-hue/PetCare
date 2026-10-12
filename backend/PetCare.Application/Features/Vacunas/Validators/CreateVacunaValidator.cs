using FluentValidation;
using PetCare.Application.Features.Vacunas.DTOs;

namespace PetCare.Application.Features.Vacunas.Validators;

public class CreateVacunaValidator : AbstractValidator<CreateVacunaRequestDto> {
    public CreateVacunaValidator() {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre de la vacuna no puede estar vacío.")
            .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres.")
            .MaximumLength(100).WithMessage("El nombre es demasiado largo.");

        RuleFor(x => x.Especie)
            .NotEmpty().WithMessage("La especie no puede estar vacía.");
    }
}