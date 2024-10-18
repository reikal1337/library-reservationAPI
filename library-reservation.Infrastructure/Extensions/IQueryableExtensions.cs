using library_reservationAPI.DTOs;
using library_reservationAPI.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace library_reservation.Infrastructure.Extensions
{
    public static class IQueryableExtensions
    {
        //Pagination for db queries.
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, GetQueryDTO getQueryDTO)
        {
            return queryable.Skip((getQueryDTO.Page - 1) * getQueryDTO.RecordsPerPage)
                             .Take(getQueryDTO.RecordsPerPage);
        }

        public static IQueryable<Book> SearchBooks(this IQueryable<Book> queryable, GetQueryDTO getQueryDTO)
        {

            //Serach by name
            if (!string.IsNullOrEmpty(getQueryDTO.Name))
            {
                queryable = queryable.Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{getQueryDTO.Name.ToLower()}%"));

            }

            //Serach by year
            if (getQueryDTO.Year.HasValue)
            {
                queryable = queryable.Where(x => x.Year == getQueryDTO.Year);
            }

            //Serach by type
            if (!string.IsNullOrEmpty(getQueryDTO.Type))
            {
                queryable = queryable.Where(x => x.Types.Any(t => t == getQueryDTO.Type));
            }
            return queryable;

        }
    }
}
