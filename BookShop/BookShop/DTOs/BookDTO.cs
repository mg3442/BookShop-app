﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.DTOs

{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }
    }
}