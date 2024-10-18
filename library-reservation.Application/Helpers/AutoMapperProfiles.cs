using AutoMapper;
using library_reservation.Application.DTOs;
using library_reservationAPI.Entities;

namespace library_reservationAPI.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Book, BookDTO>().ReverseMap();

            CreateMap<ReservationItemDTO, ReservationItem>().ReverseMap();


            CreateMap<ReservationItemDTO, ReservationItem>();
            CreateMap<CreateReservationDTO, Reservation>()
    .ForMember(dest => dest.ReservationItems, opt => opt.MapFrom(src =>
        src.Items.Select(item => new ReservationItem
        {
            BookId = item.BookId,
            Type = item.Type,
            Days = item.Days,
            QuickPickUp = item.QuickPickUp
        })))
    .ForMember(dest => dest.Id, opt => opt.Ignore())
    .ForMember(dest => dest.TotalPrice, opt => opt.Ignore());

        }
    }
}
