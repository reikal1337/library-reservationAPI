using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using library_reservationAPI.Db;
using library_reservationAPI.Entities;
using library_reservation.Application;

namespace library_reservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var books = await bookService.GetAllBooks();
            return Ok(books);
        }

    }
}
