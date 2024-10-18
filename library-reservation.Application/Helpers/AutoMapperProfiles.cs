using AutoMapper;
using library_reservation.Application.DTOs;
using library_reservationAPI.Entities;

namespace library_reservationAPI.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() { 
            CreateMap<Book,BookDTO>().ReverseMap();
           
            CreateMap<CreateReservationDTO, ReservationItemPricingDTO>();
            CreateMap<ReservationItemPricingDTO, Reservation>();
        }
    }
}
