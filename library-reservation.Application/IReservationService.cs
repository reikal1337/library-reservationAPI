using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;


namespace library_reservation.Application
{
    public interface IReservationService
    {
        Task<(List<Reservation>, int TotalRecords)> GetPaginatedReservations(PaginationDTO paginationDTO);
    }
}
