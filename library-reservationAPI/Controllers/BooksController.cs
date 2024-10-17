using Microsoft.AspNetCore.Mvc;
using library_reservationAPI.Entities;
using library_reservationAPI.DTOs;
using library_reservationAPI.Helpers;
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
        public async Task<ActionResult<List<Book>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var (books, totalRecords) = await bookService.GetPaginatedBooks(paginationDTO);

            // Inserting pagination details in the header
            await HttpContext.InsertParametersPaginationInHeader(totalRecords.ToString());

            return Ok(books);
        }

    }
}
