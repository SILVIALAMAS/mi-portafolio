using Microsoft.EntityFrameworkCore;
using TicketingAPI.Domain;using TicketingAPI.Application.UseCases.User.Handlers;

using TicketingAPI.Application.Interfaces;
using TicketingAPI.Application.Services;
using TicketingAPI.Infrastructure.Persistence;
using TicketingAPI.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserServicePORACAMEQUEDE>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();
builder.Services.AddScoped<SectorService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<ISeatRepository, ButacaRepository>();
builder.Services.AddScoped<SeatService>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<AuditLogService>();
builder.Services.AddScoped<CreateUserHandler>();
builder.Services.AddScoped<GetUsersHandler>();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer(); // required for Swagger/OpenAPI discovery
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//Base de datos
var app = builder.Build();
/*using (var scope = app.Services.CreateScope())
{ var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureDeleted(); 
    db.Database.EnsureCreated(); }
    /* Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }*/
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticketing API v1");
    c.RoutePrefix = "swagger"; // keep default route
});
app.UseHttpsRedirection();//Middlewares

app.UseAuthorization();
app.MapControllers();//Endpoints

app.Run();
