using library_reservation.Application;
using library_reservation.Infrastructure.Extensions;
using library_reservationAPI.Db;
using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_reservation.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext context;

        public ReservationRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<(List<Reservation>, int TotalRecords)> GetPaginatedReservations(PaginationDTO paginationDTO)
        {
            var queryable = context.Reservations.AsQueryable();

            int totalRecords = await queryable.CountAsync();

            var books = await queryable
                        .Paginate(paginationDTO)
                        .ToListAsync();

            return (books, totalRecords);
        }
    }
}
