using Microsoft.AspNetCore.Mvc;
using PetCare.Application.Interfaces;
using PetCare.Domain.Entities;

namespace PetCare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacunasController : ControllerBase
{
    private readonly IVacunaRepository _repository;

    public VacunasController(IVacunaRepository repository)
    {
        _repository = repository;
    }

    // VERBO GET: Solicitar lectura de datos (HTTP 200 OK)
    [HttpGet]
    public async Task<IActionResult> GetVacunas()
    {
        var vacunas = await _repository.GetAllAsync();
        return Ok(vacunas);
    }

    // VERBO POST: Solicitar creación de un recurso
    [HttpPost]
    public async Task<IActionResult> CrearVacuna([FromBody] VacunaGlobal vacuna)
    {
        if (string.IsNullOrWhiteSpace(vacuna.Nombre))
        {
            return BadRequest("El nombre de la vacuna es obligatorio."); // HTTP 400 Bad Request
        }

        var nuevaVacuna = await _repository.AddAsync(vacuna);

        // HTTP 201 Created: Devuelve el recurso recién creado por cortesía RESTful
        return CreatedAtAction(nameof(GetVacunas), new { id = nuevaVacuna.Id }, nuevaVacuna);
    }
}