

using System.ComponentModel.DataAnnotations;

namespace library_reservation.Application.DTOs
{
    public class CreateReservationDTO
    {
        [Required(ErrorMessage = "Items are required.")]
        [MinLength(1, ErrorMessage = "At least one reservation item is required.")]
        public List<ReservationItemDTO> Items { get; set; } = new List<ReservationItemDTO>();
    }

}
