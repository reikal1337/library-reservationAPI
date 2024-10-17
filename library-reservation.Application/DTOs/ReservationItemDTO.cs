namespace library_reservation.Application.DTOs
{
    public class ReservationItemDTO
    {
        public int BookId { get; set; }
        public string Type { get; set; } = default!;
        public int Days { get; set; }
        public bool QuickPickUp { get; set; }
    
    }
}
