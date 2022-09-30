using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();

        List<Book> GetBooksByCategory(int catId);

        string AddBook(Book book);

        bool EditBook(int id,Book book);

        bool DeleteBook(int id);
    }
}
