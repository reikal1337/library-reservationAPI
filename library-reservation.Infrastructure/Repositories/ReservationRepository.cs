﻿using library_reservation.Application;
using library_reservation.Infrastructure.Extensions;
using library_reservationAPI.Db;
using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;
using Microsoft.EntityFrameworkCore;


namespace library_reservation.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext context;

        public ReservationRepository(AppDbContext context)
        {
            this.context = context;
        }

        public  async Task CreateReservation(Reservation reservation)
        {
            Console.WriteLine(reservation);
            await context.Reservations.AddAsync(reservation);
            await context.SaveChangesAsync();
        }

        public async Task<(List<Reservation>, int TotalRecords)> GetPaginatedReservations(GetQueryDTO getQueryDTO)
        {
            var queryable = context.Reservations.Include(r => r.ReservationItems)
                .ThenInclude(ri => ri.Book)
                .AsQueryable();

            int totalRecords = await queryable.CountAsync();

            var reservations = await queryable
                        .Paginate(getQueryDTO)
                        .ToListAsync();

            return (reservations, totalRecords);
        }
    }
}
