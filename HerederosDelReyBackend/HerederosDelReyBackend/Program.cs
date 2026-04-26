using System.Text;
using AutoMapper;
using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using HerederosDelReyBackend.Repositories;
using HerederosDelReyBackend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// =========================
// Configuración DbContext
// =========================
builder.Services.AddDbContext<HerederosDelReyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Mauri"))
);

// =========================
// Configuración JWT
// =========================
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings")
);

var jwtSettings = builder.Configuration
    .GetSection("JwtSettings")
    .Get<JwtSettings>();

if (jwtSettings == null || string.IsNullOrWhiteSpace(jwtSettings.Key))
{
    throw new Exception("La configuración JwtSettings no está definida correctamente en appsettings.json");
}

var key = Encoding.UTF8.GetBytes(jwtSettings.Key);

// =========================
// Autenticación JWT
// =========================
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtSettings.Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// =========================
// Repositorios y servicios
// =========================
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasherService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();

builder.Services.AddScoped<ICompraRepository, CompraRepository>();
builder.Services.AddScoped<ICompraService, CompraService>();





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
// OpenAPI nativo
// =========================
builder.Services.AddOpenApi();

// =========================
// CORS
// =========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// =========================
// OpenAPI + Scalar
// =========================
app.MapOpenApi();

app.MapScalarApiReference(options =>
{
    options.Title = "HerederosDelRey API";
});

// =========================
// Redirección raíz -> Scalar
// =========================
app.MapGet("/", context =>
{
    context.Response.Redirect("/scalar");
    return Task.CompletedTask;
});

// =========================
// Middleware general
// =========================
app.UseHttpsRedirection();

app.UseCors("PermitirTodo");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


