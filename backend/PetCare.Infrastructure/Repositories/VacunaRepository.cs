using Microsoft.EntityFrameworkCore;
using PetCare.Application.Interfaces;
using PetCare.Domain.Entities;
using PetCare.Infrastructure.Data;

namespace PetCare.Infrastructure.Repositories;

public class VacunaRepository : IVacunaRepository 
{
    private readonly PetCareDbContext _context;

    public VacunaRepository(PetCareDbContext context) 
    {
        _context = context;
    }

    public async Task<IEnumerable<VacunaGlobal>> GetAllAsync() 
    {
        return await _context.VacunasGlobales.ToListAsync();
    }

    public async Task<VacunaGlobal> AddAsync(VacunaGlobal vacuna) 
    {
        await _context.VacunasGlobales.AddAsync(vacuna);
        await _context.SaveChangesAsync(); // Ejecuta el COMMIT en la base de datos
        return vacuna;
    }
}