using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_reservation.Application.DTOs
{
    public class ReservationItemDTO
    {

        public int BookId { get; set; }

        [Required]
        [RegularExpression("^(book|audiobook)$", ErrorMessage = "Type must be either 'book' or 'audiobook'")]
        public string Type { get; set; } = default!;

        [Required]
        [Range(1, 180, ErrorMessage = "Days must be between 1 and 180")]
        public int Days { get; set; }

        public bool QuickPickUp { get; set; }

    }
}
