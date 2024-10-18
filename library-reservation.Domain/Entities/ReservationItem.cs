using library_reservationAPI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace library_reservationAPI.Entities
{
    public class ReservationItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Type { get; set; } = default!;
        public int Days { get; set; }
        public bool QuickPickUp { get; set; }

        public int ReservationId { get; set; }
        public virtual Book Book { get; set; } = default!;
    }


}
