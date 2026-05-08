namespace TicketingAPI.Application.Interfaces
{
    using TicketingAPI.Domain.Entities;

    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
