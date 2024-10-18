using library_reservationAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace library_reservation.Application.DTOs
{
    public class ReservationItemPricingDTO
    {
        [Required]
        [RegularExpression("^(book|audiobook)$", ErrorMessage = "Type must be either 'book' or 'audiobook'")]
        public string Type { get; set; } = default!;
        [Required]
        [Range(1, 180, ErrorMessage = "Days must be between 1 and 180")]
        public int Days { get; set; }
        [Required]
        public bool QuickPickUp { get; set; }
    }
}
