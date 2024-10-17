using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;


namespace library_reservation.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<(List<Book>, int TotalRecords)> GetPaginatedBooks(PaginationDTO paginationDTO)
        {

            return await bookRepository.GetPaginatedBooks(paginationDTO);
        }
    }
}
