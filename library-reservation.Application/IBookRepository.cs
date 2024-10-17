﻿using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_reservation.Application
{
    public interface IBookRepository
    {
        Task<(List<Book>, int TotalRecords)> GetPaginatedBooks(PaginationDTO paginationDTO);

    }
}
