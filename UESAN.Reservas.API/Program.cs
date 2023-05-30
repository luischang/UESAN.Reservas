using Microsoft.EntityFrameworkCore;
using UESAN.Reservas.Core.Interfaces;
using UESAN.Reservas.Core.Services;
using UESAN.Reservas.Infrastructure.Data;
using UESAN.Reservas.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder
    .Services
    .AddDbContext<ReservasContext>
    (options => options.UseSqlServer(cnx));
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
