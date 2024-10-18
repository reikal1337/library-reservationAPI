using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_reservation.Application.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ImageSrc { get; set; } = default!;
        public int Year { get; set; }
        public List<string> Types { get; set; } = default!;
    }
}
