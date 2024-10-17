using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;

namespace library_reservation.Application
{
    public class ReservationService : IReservationService
    {
        public async Task<(List<Reservation>, int TotalRecords)> GetPaginatedReservations(PaginationDTO paginationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
