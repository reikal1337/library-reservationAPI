using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;


namespace library_reservation.Application
{
    public interface IBookService
    {
        Task<(List<Book>, int TotalRecords)> GetPaginatedBooks(PaginationDTO paginationDTO);
    }
}
