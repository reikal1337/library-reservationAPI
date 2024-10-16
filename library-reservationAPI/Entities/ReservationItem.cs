using library_reservationAPI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace library_reservationAPI.Entities
{
    public class ReservationItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required]
        [RegularExpression("(book|audiobook)", ErrorMessage = "Type must be either 'book' or 'audiobook'")]
        public string Type { get; set; }

        [Range(Constants.MIN_RESERVE_DAYS, Constants.MAX_RESERVE_DAYS, ErrorMessage = "Days to reserve must be within the allowed range")]
        public int Days { get; set; }
        public bool QuickPickUp { get; set; }


    }
}
