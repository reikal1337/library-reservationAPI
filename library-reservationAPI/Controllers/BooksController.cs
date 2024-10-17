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
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = bookService.GetAllBooks();
            return Ok(books);
        }

    }
}
