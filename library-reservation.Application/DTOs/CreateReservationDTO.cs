

namespace library_reservation.Application.DTOs
{
    public class CreateReservationDTO
    {
        public List<ReservationItemDTO> ReservationItems { get; set; } = new List<ReservationItemDTO>();
    }
}
