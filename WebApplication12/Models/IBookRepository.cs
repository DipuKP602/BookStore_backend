namespace WebApplication12.Models
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();

        //List<Book> GetBooksByCategory(int catId);

        Book GetBookById(int id);

        Book AddBook(Book book);

        Book EditBook(int id, Book book);

        void DeleteBook(int id);
    }
}
