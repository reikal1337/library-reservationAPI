using library_reservationAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace library_reservationAPI.Db
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        internal DbSet<Book> Books { get; set; }
        internal DbSet<Reservation> Reservations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<ReservationItem>().OwnsOne(x => x.Book);

            modelBuilder.Entity<Reservation>().HasMany(x => x.ReservationItems);

            

        }
        
    }
}
