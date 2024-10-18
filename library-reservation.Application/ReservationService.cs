using AutoMapper;
using library_reservation.Application.DTOs;
using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;
using System.Runtime.ConstrainedExecution;

namespace library_reservation.Application
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IMapper mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper) 
        {
            this.reservationRepository = reservationRepository;
            this.mapper = mapper;
        }
        public async Task<(List<Reservation>, int TotalRecords)> GetPaginatedReservations(GetQueryDTO paginationDTO)
        {
            return await reservationRepository.GetPaginatedReservations(paginationDTO);
        }

        //• Reservation sum is determined by type: Book(€2/day), Audiobook(€3/day).
        //• Discount is applied: > 3 days – 10% off; > 10 days – 20% off.
        //• Service fee: €3 per reservation, applied to all bookings.
        //• Quick pick up: €5 per reservation if selected.
        private const decimal BOOK_PER_DAY_PRICE = 2m;
        private const decimal AUDIOBOOK_PER_DAY_PRICE = 3m;
        private const decimal DISCOUNT_3D = 0.9m; //10% discount
        private const decimal DISCOUNT_10D = 0.8m; //20% discount
        private const decimal SERVICE_FEE = 3m;
        private const decimal QUICK_PICK_UP_FEE = 5m;
        public decimal GetReservationPrice(List<ReservationItemPricingDTO> items)
        {
            if (items.Count() <= 0) return 0;
            decimal totalPrice = 0m;
            foreach (var item in items) 
            {
                totalPrice += CalculateItemPrice(item); 

                if(item.QuickPickUp) 
                {
                    totalPrice += QUICK_PICK_UP_FEE;
                }
            }


            return totalPrice + SERVICE_FEE;
        }

        private decimal CalculateItemPrice(ReservationItemPricingDTO item) {

            decimal pricePerDay = item.Type.ToLower() == "book" ? BOOK_PER_DAY_PRICE : AUDIOBOOK_PER_DAY_PRICE;
            decimal regularPrice = pricePerDay * item.Days;

            decimal discountedPrice = CalculateDiscountedPrice(regularPrice, item.Days);



            return discountedPrice;
        }

        private decimal CalculateDiscountedPrice(decimal price, int days) 
        {
            switch (days) 
            {
                case > 10: 
                    return price * DISCOUNT_10D;
                case > 3:
                    return price * DISCOUNT_3D;
                default:
                    return price;

            }
        }

        public async Task CreateReservation(CreateReservationDTO createReservationDTO)
        {
            var prisingItems = mapper.Map<List<ReservationItemPricingDTO>>(createReservationDTO);
            var totalPrice = GetReservationPrice(prisingItems);
            var reservation = mapper.Map<Reservation>(prisingItems);

            reservation.TotalPrice = totalPrice;
            await reservationRepository.CreateReservation(reservation);
        }
    }
}
