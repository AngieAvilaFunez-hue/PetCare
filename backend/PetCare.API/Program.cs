using DotNetEnv;
using PetCare.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresConnection")
    ?? throw new InvalidOperationException("Falta la cadena de conexión.");

// Inyección de dependencias de la capa de infraestructura y controladores
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddControllers();

// Configuración estándar de Swagger / OpenAPI compatible con tu versión de .NET
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Habilitamos Swagger para generar el JSON de la API
    app.UseSwagger();
    
    // Mantenemos también Swagger UI por si deseas consultarlo de forma clásica
    app.UseSwaggerUI();

    // Integramos Scalar apuntando correctamente a la ruta del archivo JSON de Swagger
    app.MapScalarApiReference(options =>
    {
        options.WithOpenApiRoutePattern("/swagger/v1/swagger.json");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();