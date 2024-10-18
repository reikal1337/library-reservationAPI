

using System.ComponentModel.DataAnnotations;

namespace library_reservation.Application.DTOs
{
    public class CreateReservationDTO
    {
        [Required]
        public List<ReservationItemDTO> Items { get; set; } = new List<ReservationItemDTO>();
    }

}
