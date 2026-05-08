namespace TicketingAPI.Application.Services
{
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Application.UseCases.Seats.Handlers;
    using TicketingAPI.Application.UseCases.Seats.Queries;
    using TicketingAPI.Application.UseCases.Seats.Commands;
    using TicketingAPI.Application.DTOs.Seat;
    using TicketingAPI.Application.DTOs.Reservation;

    public class SeatService : ISeatService
    {
        private readonly GetSeatsBySectorHandler _getBySectorHandler;
        private readonly GetSeatByIdHandler _getByIdHandler;
        private readonly CreateSeatHandler _createHandler;
        private readonly ReserveSeatHandler _reserveHandler;
        public SeatService(GetSeatsBySectorHandler getBySectorHandler, GetSeatByIdHandler getByIdHandler, CreateSeatHandler createHandler, ReserveSeatHandler reserveHandler)
        {
            _getBySectorHandler = getBySectorHandler;
            _getByIdHandler = getByIdHandler;
            _createHandler = createHandler;
            _reserveHandler = reserveHandler;
        }

        public async Task<IEnumerable<SeatResponseDto>> GetBySectorIdAsync(int sectorId)
          => await _getBySectorHandler.HandleAsync(new GetSeatsBySectorQuery { SectorId = sectorId });
        public async Task<SeatResponseDto?> GetByIdAsync(Guid id)
              => await _getByIdHandler.HandleAsync(new GetSeatByIdQuery { Id = id });
        public async Task<SeatResponseDto> CreateAsync(CreateSeatCommand command)
              => await _createHandler.HandleAsync(command);
        public async Task<(bool Success, ReserveSeatResponseDto? Result, string?Error) >ReserveAsync(ReserveSeatCommand command)
              => await _reserveHandler.HandleAsync(command);

    }
}