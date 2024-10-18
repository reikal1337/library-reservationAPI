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

            //modelBuilder.Entity<Reservation>()
            //    .HasMany(r => r.ReservationItems)
            //    .WithOne()
            //    .HasForeignKey(ri => ri.ReservationId) 
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<ReservationItem>()
            //    .HasOne<Book>()
            //    .WithMany()
            //    .HasForeignKey(ri => ri.BookId);

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.ReservationItems)
                .WithOne()
                .HasForeignKey(ri => ri.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReservationItem>()
                .HasOne<Book>(ri => ri.Book)
                .WithMany() 
                .HasForeignKey(ri => ri.BookId);


        }
        
    }
}
