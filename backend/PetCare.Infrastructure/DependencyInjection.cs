using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetCare.Application.Interfaces;
using PetCare.Infrastructure.Data;
using PetCare.Infrastructure.Repositories;

namespace PetCare.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PetCareDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<VacunaRepository>();

        return services;
    }
}