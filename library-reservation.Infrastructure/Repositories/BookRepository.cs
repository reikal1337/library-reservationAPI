using library_reservation.Application;
using library_reservation.Infrastructure.Extensions;
using library_reservationAPI.Db;
using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;


namespace library_reservation.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public BookRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Book> GetById(int Id)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == Id);
            Console.WriteLine(book);
            return book;
        }

        public async Task<(List<Book>, int TotalRecords)> GetPaginatedBooks(PaginationDTO paginationDTO)
        {

            var queryable = context.Books.AsQueryable();

            int totalRecords = await queryable.CountAsync();

            var books = await queryable
                        .Paginate(paginationDTO)
                        .ToListAsync();

            return (books, totalRecords);
        }
    }
}
