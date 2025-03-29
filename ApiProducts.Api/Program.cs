using System.Text;
using ApiProducts.Api.Middleware;
using ApiProducts.Application.Services;
using ApiProducts.Domain.Interfaces;
using ApiProducts.Infrastructure.Data;
using ApiProducts.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:8080")  // URL del frontend (Vue)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();  // Permitir credenciales (si usas cookies o autenticación de sesión)
    });
});

// Configurar la base de datos
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyectar dependencias
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductConfigService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductConfigRepository, ProductConfigRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Configurar Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()  // Mostrar logs en la consola
    .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day) // Guardar en archivo con rotación diaria
    .Enrich.FromLogContext()
    .CreateLogger();

// Usar Serilog como proveedor de logs
builder.Host.UseSerilog();

// Cargar configuración de JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar CORS
app.UseCors("AllowVueApp");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = "swagger"; // La URL será http://localhost:<puerto>/swagger
    });
    //app.UseSwaggerUI();
}
//app.UseWelcomePage();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSerilogRequestLogging(); // Agregar logs de solicitudes HTTP
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();