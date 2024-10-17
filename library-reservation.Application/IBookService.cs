using library_reservationAPI.Entities;


namespace library_reservation.Application
{
    public interface IBookService
    {
        List<Book> GetAllBooks(); 
    }
}
