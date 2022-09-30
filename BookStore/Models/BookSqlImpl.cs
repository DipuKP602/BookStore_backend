using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class BookSqlImpl : IBookRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public BookSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }

        public string AddBook(Book book)
        {
            comm.Connection = conn;
            comm.CommandText = "insert into book values ("+book.BookId+","+book.CatId+",'"+book.Title+"','"+book.ISBN+"','"+book.Year+","+book.Price+",'"+book.Description+"',"+book.Position+","+book.Status+",'"+book.ImageURL+"');";
            conn.Open();
            return comm.CommandText;
            //int rows = comm.ExecuteNonQuery();
            conn.Close();
            //if (rows > 0)
            //    return book;
            //else
            //    return null;
        }

        public bool DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditBook(int id, Book book)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            List<Book> booksList = new List<Book>();
            comm.Connection = conn;
            comm.CommandText = "select * from book;";
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["bookId"]);
                int catId = Convert.ToInt32(reader["categoryId"]);
                int price = Convert.ToInt32(reader["price"]);
                int position = Convert.ToInt32(reader["position"]);
                int status = Convert.ToInt32(reader["status"]);

                string title = reader["title"].ToString();
                string iSBN = reader["isbn"].ToString();
                DateTime year = Convert.ToDateTime(reader["year"].ToString());
                string description = reader["description"].ToString();
                string imageURL = reader["image"].ToString();

                Book book = new Book(bookId,catId,title,iSBN,year,price,description,position,status,imageURL);
                booksList.Add(book);
            }
            conn.Close();
            return booksList;
        }

        public List<Book> GetBooksByCategory(int catId)
        {
            throw new NotImplementedException();
        }
    }
}