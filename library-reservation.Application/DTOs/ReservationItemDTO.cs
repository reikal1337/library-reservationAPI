using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_reservation.Application.DTOs
{
    internal class ReservationItemDTO
    {

        
        public int BookId { get; set; }
        public string Type { get; set; } = default!;
        public int Days { get; set; }
        public bool QuickPickUp { get; set; }
    
    }
}
