using PetCare.Domain.Entities;

namespace PetCare.Application.Interfaces;

public interface IVacunaRepository 
{
    Task<IEnumerable<VacunaGlobal>> GetAllAsync();
    Task<VacunaGlobal> AddAsync(VacunaGlobal vacuna); 
}