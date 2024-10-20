﻿using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace library_reservationAPI.Helpers
{
    public static class HttpContextExtensions
    {
        //Adds header to response. Total records of db table, used for pagination.
        public async static Task InsertParametersPaginationInHeader(this HttpContext httpContext, string totalRecords)
        {
            if (httpContext == null)
            {
                throw new ArgumentException(nameof(httpContext));
            }

            httpContext.Response.Headers.Add("totalAmountOfRecords", totalRecords); 
        }

        
    }
}
