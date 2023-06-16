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

builder.Services.AddTransient<IQuejasService, QuejasService>();
builder.Services.AddTransient<IQuejasRepository, QuejasRepository>();

builder.Services.AddTransient<ITipoUsuarioRepository, TipoUsuarioRepository>();
builder.Services.AddTransient<ITipoUsuarioService, TipoUsuarioService>();

builder.Services.AddTransient<ICalificacionService, CalificacionService>();
builder.Services.AddTransient<ICalificacionRepository, CalificacionRepository >();

builder.Services.AddTransient<IOfertasService, OfertasService>();
builder.Services.AddTransient<IOfertasRepository, OfertasRepository>(); 

builder.Services.AddTransient<IPagoService, PagoService>();
builder.Services.AddTransient<IPagoRepository, PagoRepository>();

builder.Services.AddTransient<ITipoHabitacionRepository, TipoHabitacionRepository>();
builder.Services.AddTransient<ITipoHabitacionService, TipoHabitacionService>();

builder.Services.AddTransient<IHabitacionRepository, HabitacionRepository>();
builder.Services.AddTransient<IHabitacionService, HabitacionService>();

builder.Services.AddTransient<IReservasOrderRepository, ReservasOrderRepository>();
builder.Services.AddTransient<IReservasOrderService, ReservasOrderService>();

builder.Services.AddTransient<IDetalleServiciosRepository, DetalleServiciosRepository>();
builder.Services.AddTransient<IDetalleServiciosService, DetalleServiciosService>();


builder.Services.AddTransient<IDetalleReservasRepository, DetalleReservasRepository>();
builder.Services.AddTransient<IDetalleReservaService, DetalleReservaService>();

builder.Services.AddTransient<IIdEstadoReservaRepository, IdEstadoReservaRepository>();
builder.Services.AddTransient<IIdEstadoReservaService, IdEstadoReservaService>();

builder.Services.AddTransient<IServicioRepository, ServicioRepository>();
builder.Services.AddTransient<IServicioService, ServicioService>();

builder.Services.AddTransient<ISalaDeEventosRepository, SalaDeEventosRepository>();
builder.Services.AddTransient<ISalaDeEventosService, SalaDeEventosService>();

builder.Services.AddTransient<IDetalleSalaDeEventosService, DetalleSalaDeEventosService>();
builder.Services.AddTransient<IDetalleSalaEventosRepository, DetalleSalaEventosRepository>();




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
