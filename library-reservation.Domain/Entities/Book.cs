using System.ComponentModel.DataAnnotations;

namespace library_reservationAPI.Entities
{
    
       


        public class Book
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string ImageSrc { get; set; } = default!;
            public int Year { get; set; }
            public List<string> Types { get; set; } = default!;
        }


    
}
