﻿using System.ComponentModel.DataAnnotations;

namespace library_reservationAPI.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageSrc { get; set; }

        public int Year { get; set; }

        public string Type {  get; set; }



    }
}
