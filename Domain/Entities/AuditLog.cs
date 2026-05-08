namespace TicketingAPI.Domain.Entities
{
    public class AuditLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int? UserId { get; set; }// Puede ser null para acciones del sistema
        public string Action { get; set; } = string.Empty;//ReservaCreada, ReservaPagada, ReservaExpirada, etc.
        public string EntityType { get; set; }= string.Empty;//Seat, Reservation, User, etc.
        public string EntityId { get; set; }= string.Empty;//Id de la entidad afectada
        public string Details { get; set; } = string.Empty;//Información adicional en formato JSON o texto
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
        public User? User { get; set; }
    }
}
