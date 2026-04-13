
using AutoMapper;
using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Repositories;
using HerederosDelReyBackend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// =========================
// Configuración DbContext
// =========================
builder.Services.AddDbContext<HerederosDelReyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// =========================
// Repositorios y servicios
// =========================
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// =========================
// AutoMapper v16
// =========================
builder.Services.AddSingleton<IMapper>(provider =>
{
    var loggerFactory = provider.GetRequiredService<ILoggerFactory>();

    var config = new MapperConfiguration(cfg =>
    {
        cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
    }, loggerFactory);

    return config.CreateMapper();
});

// =========================
// Controladores
// =========================
builder.Services.AddControllers();

// =========================
// Swagger / OpenAPI
// =========================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ApiUsuarios",
        Version = "v1",
        Description = "API de gestión de usuarios y ventas"
    });
});

var app = builder.Build();

// =========================
// Middleware Swagger (abre automáticamente)
// =========================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiUsuarios v1");
        c.RoutePrefix = ""; // <-- hace que Swagger sea la página raíz
    });
}

// =========================
// Middleware general
// =========================
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();