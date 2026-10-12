using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCare.Infrastructure.Data;
using PetCare.Domain.Entities;

namespace PetCare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacunasController : ControllerBase
{
    private readonly PetCareDbContext _context;

    public VacunasController(PetCareDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetVacunas()
    {
        var vacunas = await _context.VacunasGlobales.ToListAsync();
        return Ok(vacunas);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVacuna([FromBody] VacunaGlobal vacuna)
    {
        _context.VacunasGlobales.Add(vacuna);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetVacunas), new { id = vacuna.Id }, vacuna);
    }
}