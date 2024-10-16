using System.ComponentModel.DataAnnotations.Schema;

namespace library_reservationAPI.Entities
{
    public class Reservation
    {


        public int Id { get; set; }

        public int[] ItemIds { get; set; }

        public ICollection<ReservationItem> ReservationItems { get; set; } = new List<ReservationItem>();

        [Column(TypeName = "decimal(18, 2)")]
        public decimal  TotalPrice { get; set; }
    }
}
