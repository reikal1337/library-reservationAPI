using AutoMapper;
using library_reservation.Application.DTOs;
using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;


namespace library_reservation.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task<BookDTO> GetById(int Id)
        {
            var book = await bookRepository.GetById(Id);


            return mapper.Map<BookDTO>(book);
        }

        public async Task<(List<BookDTO>, int TotalRecords)> GetPaginatedBooks(GetQueryDTO getQueryDTO)
        {
            var (books, TotalRecords) = await bookRepository.GetPaginatedBooks(getQueryDTO);
            var booksDto = mapper.Map<List<BookDTO>>(books);
            return (booksDto, TotalRecords);
        }
    }
}
