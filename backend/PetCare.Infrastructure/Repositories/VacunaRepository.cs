using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Entities;
using PetCare.Infrastructure.Data;

namespace PetCare.Infrastructure.Repositories;

public class VacunaRepository {
    private readonly PetCareDbContext _context;

    public VacunaRepository(PetCareDbContext context) {
        _context = context;
    }

    public async Task<List<VacunaGlobal>> GetAllAsync() {
        return await _context.Set<VacunaGlobal>().ToListAsync();
    }

    public async Task<VacunaGlobal> AddAsync(VacunaGlobal vacuna) {
        _context.Set<VacunaGlobal>().Add(vacuna);
        await _context.SaveChangesAsync();
        return vacuna;
    }
}