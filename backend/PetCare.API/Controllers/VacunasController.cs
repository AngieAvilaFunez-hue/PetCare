using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Entities;
using PetCare.Application.Features.Vacunas.DTOs;
using PetCare.Infrastructure.Repositories;

namespace PetCare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacunasController : ControllerBase {
    private readonly VacunaRepository _repository;
    private readonly IValidator<CreateVacunaRequestDto> _validator;

    public VacunasController(VacunaRepository repository, IValidator<CreateVacunaRequestDto> validator) {
        _repository = repository;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetVacunas() {
        var vacunas = await _repository.GetAllAsync();

        var response = vacunas.Select(h => new VacunaResponseDto {
            Id = h.Id,
            Nombre = h.Nombre,
            Especie = h.Especie
        });

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CrearVacuna([FromBody] CreateVacunaRequestDto request) {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid) {
            return BadRequest(validationResult.Errors);
        }

        var nuevaVacuna = new VacunaGlobal {
            Nombre = request.Nombre,
            Especie = request.Especie
        };

        var vacunaCreada = await _repository.AddAsync(nuevaVacuna);

        var response = new VacunaResponseDto {
            Id = vacunaCreada.Id,
            Nombre = vacunaCreada.Nombre,
            Especie = vacunaCreada.Especie
        };

        return CreatedAtAction(nameof(GetVacunas), new { id = response.Id }, response);
    }
}