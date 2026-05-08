namespace TicketingAPI.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Emit;
    using TicketingAPI.Domain.Entities;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<Sector> Sectors => Set<Sector>();
        public DbSet<Seat> Seats => Set<Seat>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<User> Users => Set<User>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  //----------EVENT----------------
            modelBuilder.Entity<Event>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired().HasMaxLength(200);
                e.Property(x => x.Venue).IsRequired().HasMaxLength(300);
                e.Property(x => x.Status).IsRequired().HasMaxLength(20);
            });
            //----------SECTOR---------------
            modelBuilder.Entity<Sector>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired().HasMaxLength(100);
                e.Property(x => x.Price).HasColumnType("decimal(10,2)");
                e.HasOne(x => x.Event).WithMany(e => e.Sectors).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.Cascade);
            });
            //----------SEAT---------------
            modelBuilder.Entity<Seat>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.RowIdentifier).IsRequired().HasMaxLength(10);
                e.Property(x => x.Status).IsRequired().HasMaxLength(20);
                e.Property(x => x.Version).IsConcurrencyToken(); e.HasOne(x => x.Sector).WithMany(e => e.Seats).HasForeignKey(x => x.SectorId).OnDelete(DeleteBehavior.Cascade);
            });
            //----------USER---------------
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired().HasMaxLength(150);
                e.Property(x => x.Email).IsRequired().HasMaxLength(200);
                e.HasIndex(x => x.Email).IsUnique();
            });
            //----------RESERVATION---------------
            modelBuilder.Entity<Reservation>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Status).IsRequired().HasMaxLength(20);
                e.HasOne(x => x.User).WithMany(x => x.Reservations).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(x => x.Seat).WithMany(x => x.Reservations).HasForeignKey(x => x.SeatId).OnDelete(DeleteBehavior.Restrict);
            });
            //----------AUDIT LOG--------------
            modelBuilder.Entity<AuditLog>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Action).IsRequired().HasMaxLength(50);
                e.Property(x => x.EntityType).IsRequired().HasMaxLength(50);
                e.Property(x => x.EntityId).IsRequired().HasMaxLength(100);
                e.Property(x => x.Details).HasColumnType("nvarchar(max)");
                e.HasOne(x => x.User).WithMany(x => x.AuditLogs).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);
            });
            SeedData(modelBuilder);
        }
        private static void SeedData(ModelBuilder modelBuilder)
        { //--------------3 EVENTOS-----------------------------------------
            modelBuilder.Entity<Event>().HasData(
            new Event { Id = 1, Name = "Concierto de Rock", EventDate = new DateTime(2025, 12, 20, 21, 0, 0), Venue = "Estadio Luna Park", Status = "Active" },
            new Event { Id = 2, Name = "Festival de Jazz", EventDate = new DateTime(2025, 11, 15, 19, 0, 0), Venue = "Teatro Gran Rex", Status = "Active" },
            new Event { Id = 3, Name = "Obra de Teatro", EventDate = new DateTime(2025, 10, 10, 20, 0, 0), Venue = "Teatro Cervantes", Status = "Active" }
            );
            //------------3 SECTORES POR EVENTO-----------------------------
            modelBuilder.Entity<Sector>().HasData(
           //Evento 1
           new Sector { Id = 1, EventId = 1, Name = "Campo", Price = 5000, Capacity = 50 },
           new Sector { Id = 2, EventId = 1, Name = "Platea", Price = 8000, Capacity = 50 },
           new Sector { Id = 3, EventId = 1, Name = "VIP", Price = 15000, Capacity = 50 },
           //Evento 2
           new Sector { Id = 4, EventId = 2, Name = "Platea Baja", Price = 6000, Capacity = 50 },
           new Sector { Id = 5, EventId = 2, Name = "Platea Alta", Price = 4000, Capacity = 50 },
           new Sector { Id = 6, EventId = 2, Name = "Palcos", Price = 12000, Capacity = 50 },
           //Evento 3
           new Sector { Id = 7, EventId = 3, Name = "Platea", Price = 3000, Capacity = 50 },
           new Sector { Id = 8, EventId = 3, Name = "Pulmlman", Price = 2000, Capacity = 50 },
           new Sector { Id = 9, EventId = 3, Name = "VIP", Price = 8000, Capacity = 50 }
       );
            //----------3 USUARIOS DE PRUEBA-------------------
            modelBuilder.Entity<User>().HasData(

           new User { Id = 1, Name = "Admin", Email = "admin@example.com", PasswordHash = "hash123" },
           new User { Id = 2, Name = "User1", Email = "user1@example.com", PasswordHash = "hash456" },
           new User { Id = 3, Name = "User2", Email = "user2@example.com", PasswordHash = "hash789" }
         );
            //----------50 BUTACAS POR SECTOR-------------------
            var seats = new List<Seat>();
            string[] rows = { "A", "B", "C", "D", "E" };
            int seatCounter = 1;
            for (int sectorId = 1; sectorId <= 9; sectorId++)
            {
                for (int i = 0; i < 10; i++)
                {
                    foreach (var row in rows)
                    {
                        for (int num = 1; num <= 10; num++)
                        {
                            seats.Add(new Seat { Id = Guid.Parse($"00000000-0000-0000-{sectorId:D4}-{seatCounter:D12}"), SectorId = sectorId, RowIdentifier = row, SeatNumber = num, Status = "Available", Version = 0 });
                            seatCounter++;
                        }
                    }
                }
                modelBuilder.Entity<Seat>().HasData(seats);
            }
        }
    }
}