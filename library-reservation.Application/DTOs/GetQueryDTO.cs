using System.ComponentModel.DataAnnotations;

namespace library_reservationAPI.DTOs
{
    public class GetQueryDTO
    {
        public int Page { get; set; }

        private int recordsPerPage = 10;
        private readonly int maxRecordsPerPage = 50;

        public int RecordsPerPage
        {
            get 
            {
                return recordsPerPage;
            }
            set 
            {
                recordsPerPage = (value > maxRecordsPerPage) ? maxRecordsPerPage: value;
            }
        }
        [MaxLength(255)]
        public string? Name { get; set; }
        [Range(0, 3000)]
        public int? Year { get; set; }
        [RegularExpression(@"^(audiobook|book)$", ErrorMessage = "Type must be either 'audiobook' or 'book'.")]
        public string? Type { get; set; }
    }


}
