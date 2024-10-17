using library_reservationAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_reservation.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public List<Book> GetAllBooks()
        {
            var books = bookRepository.GetAllBooks();
            return books; 
        }
    }
}
