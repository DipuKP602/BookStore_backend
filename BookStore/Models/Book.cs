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
        public string ISBN { get; set; }
        public DateTime Year { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public int Status { get; set; }
        public string ImageURL { get; set; }


        public Book(int bookId, int catId, string title, string iSBN, DateTime year, int price, string description, int position, int status, string imageURL)
        {
            BookId = bookId;
            CatId = catId;
            Title = title;
            ISBN = iSBN;
            Year = year;
            Price = price;
            Description = description;
            Position = position;
            Status = status;
            ImageURL = imageURL;
        }
    }
}