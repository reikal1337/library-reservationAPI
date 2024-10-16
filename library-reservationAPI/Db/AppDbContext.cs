using library_reservationAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace library_reservationAPI.Db
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
    }
}
