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
    public class ReservationController : ControllerBase
    {
        public IReservationService reservationService;


        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var ( reservations, totalRecords) = await reservationService.GetPaginatedReservations(paginationDTO);

            // Inserting pagination details in the header
            await HttpContext.InsertParametersPaginationInHeader(totalRecords.ToString());

            return Ok(reservations);
        }

        [HttpPost("get-price")]
        public  ActionResult<decimal> GetReservationPrice(List<ReservationItemDTO> items)
        {
            decimal totalPrice = reservationService.GetReservationPrice(items);

            return Ok();
        }

    }
}
