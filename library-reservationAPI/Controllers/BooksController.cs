using Microsoft.AspNetCore.Mvc;
using library_reservationAPI.Entities;
using library_reservationAPI.DTOs;
using library_reservationAPI.Helpers;
using library_reservation.Application;
using library_reservation.Application.DTOs;



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

       

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<BookDTO>> GetById(int Id)
        {
            var books = await bookService.GetById(Id);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> Get([FromQuery] GetQueryDTO getQueryDTO)
        {
            var (books, totalRecords) = await bookService.GetPaginatedBooks(getQueryDTO);

            // Inserting pagination details in the headerreate Reservation.
            await HttpContext.InsertParametersPaginationInHeader(totalRecords.ToString());

            return Ok(books);
        }

    }
}
