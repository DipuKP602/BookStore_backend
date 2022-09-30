using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BookStore.Models
{ 
    public class Book
    {
        public int BookId { get; set; }
        public int CatId { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public DateTime Year { get; set; }
        public int Price { get; set; }
        public int Description { get; set; }
        public int Position { get; set; }
        public int Status { get; set; }
        public string ImageURL { get; set; }

    }
}