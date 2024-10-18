using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;


namespace library_reservation.Application
{
    public interface IBookService
    {
        Task<(List<Book>, int TotalRecords)> GetPaginatedBooks(GetQueryDTO paginationDTO);
        Task<Book> GetById(int Id);

    }
}
