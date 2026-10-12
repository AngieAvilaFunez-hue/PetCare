using Microsoft.AspNetCore.Mvc;
using PetCare.Application.Features.Vacunas.DTOs;
using PetCare.Domain.Entities;
using PetCare.Infrastructure.Repositories;

namespace PetCare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacunasController : ControllerBase {
    private readonly VacunaRepository _vacunaRepository;

    public VacunasController(VacunaRepository vacunaRepository) {
        _vacunaRepository = vacunaRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var vacunas = await _vacunaRepository.GetAllAsync();
        return Ok(vacunas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) {
        var vacuna = await _vacunaRepository.GetByIdAsync(id);
        if (vacuna == null) {
            return NotFound();
        }
        return Ok(vacuna);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VacunaGlobal vacuna) {
        var createdVacuna = await _vacunaRepository.AddAsync(vacuna);
        return CreatedAtAction(nameof(GetById), new { id = createdVacuna.Id }, createdVacuna);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateVacunaRequestDto dto) {
        var vacuna = await _vacunaRepository.GetByIdAsync(id);
        if (vacuna == null) {
            return NotFound();
        }

        // Actualizamos las propiedades válidas de la entidad
        vacuna.Nombre = dto.Nombre;
        vacuna.Especie = dto.Especie;

        await _vacunaRepository.UpdateAsync(vacuna);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        var vacuna = await _vacunaRepository.GetByIdAsync(id);
        if (vacuna == null) {
            return NotFound();
        }

        await _vacunaRepository.DeleteAsync(vacuna);
        return NoContent();
    }
}