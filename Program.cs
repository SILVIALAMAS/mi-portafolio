using Microsoft.EntityFrameworkCore;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Application.Services;
using TicketingAPI.Application.UseCases.AuditLog.Handlers;
using TicketingAPI.Application.UseCases.Event.Handlers;
using TicketingAPI.Application.UseCases.Reservations.Handlers;
using TicketingAPI.Application.UseCases.Seats.Handlers;
using TicketingAPI.Application.UseCases.Sectors.Handlers;
using TicketingAPI.Application.UseCases.User.Handlers;
using TicketingAPI.Infrastructure.Persistence;
using TicketingAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


// ======================================================
// BASE DE DATOS
// ======================================================

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
// Conecta Entity Framework con SQL Server usando el connection string
// configurado en appsettings.json
//using(var scope = app.Services.CreateScope())
//{
   // var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //db.Database.Migrate();
//}
// ======================================================
// REPOSITORIOS
// ======================================================

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();

// Scoped = se crea una instancia nueva por cada request HTTP
// Los repositorios acceden directamente a la base de datos


// ======================================================
// HANDLERS DE EVENTS
// ======================================================

builder.Services.AddScoped<GetAllEventsHandler>();
builder.Services.AddScoped<GetEventByIdHandler>();
builder.Services.AddScoped<CreateEventHandler>();
builder.Services.AddScoped<UpdateEventHandler>();


// ======================================================
// HANDLERS DE SECTORS
// ======================================================

builder.Services.AddScoped<GetSectorsByEventHandler>();
builder.Services.AddScoped<GetSectorByIdHandler>();
builder.Services.AddScoped<CreateSectorHandler>();
builder.Services.AddScoped<UpdateSectorHandler>();


// ======================================================
// HANDLERS DE SEATS
// ======================================================

builder.Services.AddScoped<GetSeatsBySectorHandler>();
builder.Services.AddScoped<GetSeatByIdHandler>();
builder.Services.AddScoped<CreateSeatHandler>();
builder.Services.AddScoped<ReserveSeatHandler>();


// ======================================================
// HANDLERS DE USERS
// ======================================================

builder.Services.AddScoped<GetAllUsersHandler>();
builder.Services.AddScoped<GetUserByIdHandler>();
builder.Services.AddScoped<CreateUserHandler>();
builder.Services.AddScoped<UpdateUserHandler>();


// ======================================================
// HANDLERS DE RESERVATIONS
// ======================================================

builder.Services.AddScoped<GetReservationByIdHandler>();
builder.Services.AddScoped<GetReservationsByUserHandler>();
builder.Services.AddScoped<UpdateReservationHandler>();


// ======================================================
// HANDLERS DE AUDITLOGS
// ======================================================

builder.Services.AddScoped<GetAuditLogsByEntityHandler>();
builder.Services.AddScoped<GetAuditLogsByUserHandler>();


// ======================================================
// SERVICES
// ======================================================

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();

// Los Services contienen la lógica de negocio
// y utilizan los repositorios


// ======================================================
// CORS (para permitir conexión desde frontend)
// ======================================================

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Esto permite conectar React, Angular, Vue, etc.
// sin errores de CORS


// ======================================================
// CONTROLLERS + SWAGGER
// ======================================================

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "TicketingAPI",
        Version = "v1",
        Description = "Sistema de venta de entradas - Proyecto de Software"
    });
});

// Swagger genera documentación automática de la API
// URL: https://localhost:xxxx/swagger


var app = builder.Build();


// ======================================================
// MIGRACIÓN AUTOMÁTICA AL INICIAR
// ======================================================

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.Migrate();
}

// Aplica automáticamente las migraciones pendientes
// y crea la base si no existe


// ======================================================
// SWAGGER SOLO EN DESARROLLO
// ======================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// ======================================================
// PIPELINE HTTP
// ======================================================

app.UseHttpsRedirection();

// Fuerza uso de HTTPS

app.UseCors("AllowAll");

// Habilita CORS

// app.UseAuthentication();
// app.UseAuthorization();

// Descomentarlos cuando implementes JWT/Login

app.MapControllers();

// Habilita los controllers de la API

app.Run();
