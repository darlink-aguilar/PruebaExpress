using Microsoft.EntityFrameworkCore;
using PruebaApiExpress.Models;

var builder = WebApplication.CreateBuilder(args);

// Todo lo que empiece por builder.Services.Add... sirve para registrar herramientas
// que tu aplicación va a necesitar más adelante. Si no las registras aquí, el programa
// no sabrá que existen.

// 1. Registramos los controladores 
builder.Services.AddControllers(); 

// 2. Configuramos Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Registramos la conexión a la Base de Datos con AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 4. Configuramos el pipeline HTTP (Entorno de desarrollo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Esto es lo que genera el JSON de la documentación de la API
    app.UseSwaggerUI(); // Esto es lo que abre la interfaz visual
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();