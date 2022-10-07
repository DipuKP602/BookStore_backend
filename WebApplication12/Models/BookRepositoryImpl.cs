namespace WebApplication12.Models
{
    public class BookRepositoryImpl : IBookRepository
    {
        private readonly BookDBContext _dbContext;

        public BookRepositoryImpl(BookDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Book> GetAllBooks()
        {
            return _dbContext.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _dbContext.Books.FirstOrDefault(book => book.BookId == id);
        }
        public Book AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return book;
        }

        public void DeleteBook(int id)
        {
            Book book = GetBookById(id);
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

        public Book EditBook(int id, Book book)
        {
            Book newBook = GetBookById(id);
            newBook.CatId = book.CatId;
            newBook.Title = book.Title;
            newBook.ISBN = book.ISBN;
            newBook.Year = book.Year;
            newBook.Price = book.Price;
            newBook.Description = book.Description;
            newBook.Position = book.Position;
            newBook.Status = book.Status;
            newBook.ImageURL = book.ImageURL;

            _dbContext.SaveChanges();
            return newBook;
        }
    }
}
