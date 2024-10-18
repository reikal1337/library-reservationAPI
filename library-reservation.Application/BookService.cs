﻿using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;


namespace library_reservation.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<Book> GetById(int Id)
        {
            return await bookRepository.GetById(Id);
        }

        public async Task<(List<Book>, int TotalRecords)> GetPaginatedBooks(GetQueryDTO getQueryDTO)
        {

            return await bookRepository.GetPaginatedBooks(getQueryDTO);
        }
    }
}
