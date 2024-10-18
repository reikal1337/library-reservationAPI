using library_reservation.Application.DTOs;
using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;


namespace library_reservation.Application
{
    public interface IReservationService
    {
        Task<(List<Reservation>, int TotalRecords)> GetPaginatedReservations(GetQueryDTO paginationDTO);

        decimal GetReservationPrice(List<ReservationItemDTO> items);

        Task CreateReservation(CreateReservationDTO createReservationDTO);

    }
}
