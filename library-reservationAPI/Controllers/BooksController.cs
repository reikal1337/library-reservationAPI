﻿using Microsoft.AspNetCore.Mvc;
using library_reservationAPI.Entities;
using library_reservationAPI.DTOs;
using library_reservationAPI.Helpers;
using library_reservation.Application;
using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;


namespace library_reservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Book>>> Get([FromQuery] PaginationDTO paginationDTO)
        //{

        //    List<Book> books = [

        //        new Book { Id = 1, Name = "The Great Gatsby", ImageSrc = "https://images.thegreatestbooks.org/mett28u51a92h6yh90le1pbn8aai", Year = 1925, Types = new[] { "book" } },
        //        new Book { Id = 2, Name = "Ulysses", ImageSrc = "https://images.thegreatestbooks.org/sbd37b2dsyuw15cv63l87biw63kv", Year = 1922, Types = new[] { "book", "audiobook" } },
        //        new Book { Id = 3, Name = "In Search of Lost", ImageSrc = "https://images.thegreatestbooks.org/myvbhitdua7h1etye2hvfjej2p4j", Year = 1913, Types = new[] { "book" } },
        //        new Book { Id = 4, Name = "One Hundred Years of Solitude", ImageSrc = "https://images.thegreatestbooks.org/fzce7ac1jcmx6fi8ppnea65ct3u9", Year = 1967, Types = new[] { "book" } },
        //        new Book { Id = 5, Name = "The Catcher in the Rye", ImageSrc = "https://images.thegreatestbooks.org/azrr7j37ttxak2wmpmdoczhvd36t", Year = 1951, Types = new[] { "book" } },
        //        new Book { Id = 6, Name = "Lolita", ImageSrc = "https://images.thegreatestbooks.org/t9epsngv7thxsjalsswqzgtnzlpu", Year = 1955, Types = new[] { "book" } },
        //        new Book { Id = 7, Name = "Nineteen Eighty Four", ImageSrc = "https://images.thegreatestbooks.org/oka7y4u1r23osldhnx42q9lvxtpz", Year = 1949, Types = new[] { "book" } },
        //        new Book { Id = 8, Name = "Anna Karenina", ImageSrc = "https://images.thegreatestbooks.org/m8kb7ah2lhy960dbp473zna11wb4", Year = 1877, Types = new[] { "book" } },
        //        new Book { Id = 9, Name = "Moby-Dick", ImageSrc = "https://images.thegreatestbooks.org/4zdrnqgrbobtunihoxvad8kxotot", Year = 1851, Types = new[] { "book" } },
        //        new Book { Id = 10, Name = "Wuthering Heights", ImageSrc = "https://images.thegreatestbooks.org/8lg4exp38r6236mjmp8nkx4k3k2j", Year = 1847, Types = new[] { "book" } },
        //        new Book { Id = 11, Name = "Pride and Prejudice", ImageSrc = "https://images.thegreatestbooks.org/hfiptkzo82hkprq8p4yfxoxb8pns", Year = 1813, Types = new[] { "book" } },

        //    ];
        //    return Ok(books);
        //}

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Book>> GetById(int Id)
        {
            var books = await bookService.GetById(Id);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get([FromQuery] GetQueryDTO getQueryDTO)
        {
            var (books, totalRecords) = await bookService.GetPaginatedBooks(getQueryDTO);

            // Inserting pagination details in the header
            await HttpContext.InsertParametersPaginationInHeader(totalRecords.ToString());

            return Ok(books);
        }

    }
}
