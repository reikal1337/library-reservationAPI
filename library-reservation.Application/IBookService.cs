using library_reservation.Application.DTOs;
using library_reservationAPI.DTOs;


namespace library_reservation.Application
{
    public interface IBookService
    {
        Task<(List<BookDTO>, int TotalRecords)> GetPaginatedBooks(GetQueryDTO paginationDTO);
        Task<BookDTO> GetById(int Id);

    }
}
