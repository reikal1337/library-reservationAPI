﻿using library_reservation.Application.DTOs;
using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;

namespace library_reservation.Application

{
    public interface IReservationRepository
    {
        Task<(List<Reservation>, int TotalRecords)> GetPaginatedReservations(GetQueryDTO getQueryDTO);

        public Task CreateReservation(Reservation reservation);

    }
}
