namespace WebApplication12.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int CatId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Year { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public int Status { get; set; }
        public string ImageURL { get; set; }
    }
}
