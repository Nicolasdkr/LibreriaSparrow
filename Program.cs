using Microsoft.EntityFrameworkCore;
using LibreriaSparrow.Api.Data;
using LibreriaSparrow.Api.Repositories;
using LibreriaSparrow.Api.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using LibreriaSparrow.Api.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<LibreriaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibreriaContext>();
    if (!context.Usuarios.Any())
    {
        var hasher = new PasswordHasher<Usuario>();
        var admin = new Usuario
        {
            Username = builder.Configuration["AdminSeed:Username"]!,
            PasswordHash = string.Empty
        };
        admin.PasswordHash = hasher.HashPassword(admin, builder.Configuration["AdminSeed:Password"]!);
        context.Usuarios.Add(admin);
        context.SaveChanges();
    }
}

app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();