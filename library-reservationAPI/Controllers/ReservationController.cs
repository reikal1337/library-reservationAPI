using Microsoft.AspNetCore.Mvc;

using library_reservationAPI.Entities;
using library_reservationAPI.DTOs;
using library_reservationAPI.Helpers;

using library_reservation.Application;
using library_reservation.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace library_reservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public IReservationService reservationService;


        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }


        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> Get([FromQuery] GetQueryDTO paginationDTO)
        {
            var ( reservations, totalRecords) = await reservationService.GetPaginatedReservations(paginationDTO);

            // Inserting pagination details in the header
            await HttpContext.InsertParametersPaginationInHeader(totalRecords.ToString());

            return Ok(reservations);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservation([FromBody] CreateReservationDTO createReservationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }
             await reservationService.CreateReservation(createReservationDTO);

            return Created();
        }


        [HttpPost("get-price")]
        public  ActionResult<decimal> GetReservationPrice(List<ReservationItemPricingDTO> items)
        {


            if (items == null || !items.Any())
            {
                ModelState.AddModelError("Items", "The list of items cannot be empty.");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
       
            decimal totalPrice = reservationService.GetReservationPrice(items);

            Console.WriteLine($"Price: {totalPrice}");


            return Ok(totalPrice);
        }

    }
}
