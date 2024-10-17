using library_reservation.Infrastructure.Seeders;
using library_reservationAPI.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace library_reservation.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration )
        {

            var connectionString = configuration.GetConnectionString("LibraryDb");

            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase(connectionString)
                );

            services.AddScoped<IBookSeeder, BookSeeder>();
        }
    }
}
