using library_reservation.Application;
using library_reservationAPI.Db;
using library_reservationAPI.Entities;
using Microsoft.EntityFrameworkCore;


namespace library_reservation.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public BookRepository(AppDbContext context)
        {
            this.context = context;
        }


        public static List<Book> tempBook = new List<Book>() {
            new Book { Id = 1, Name = "The Great Gatsby", ImageSrc = "https://images.thegreatestbooks.org/mett28u51a92h6yh90le1pbn8aai", Year = 1925, Type = ["book"]
            }
        };

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await context.Books.ToListAsync();

            return books;
        }
    }
}
