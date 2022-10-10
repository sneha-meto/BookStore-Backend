using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class BookSql : IBook
    {
        SqlCommand comm;
        SqlConnection conn;

        public BookSql()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public void AddBook(Book book)
        {
            int statBit = book.Status ? 1 : 0;
            comm.CommandText = "insert into Books values("+book.CategoryId+",'"+book.Title+"','"+book.ISBN+"',"+book.Year+","+book.Price+",'"+book.Description+"',"+book.Position+ "," + statBit + ",'" + book.Image + "','" + book.Author + "')";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteBook(int id)
        {
            comm.CommandText = "delete from Books where BookId=" + id + "";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void EditBook(Book book)
        {
            int statBit = book.Status ? 1 : 0;

            comm.CommandText = "update Books set CategoryId=" + book.CategoryId+", Title='" + book.Title + "', ISBN='" + book.ISBN + "',Year=" + book.Year + ",Price=" + book.Price + ",[Description]='" + book.Description + "',Position=" + book.Position + ",[Status]=" + statBit + ",[Image]='" + book.Image+"', Author='"+book.Author+"'  where BookId=" + book.BookId + ";";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Book> GetBooks()
        {
            List<Book> bookList = new List<Book>();
            comm.CommandText = "select * from Books";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["BookId"]);
                int categoryId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                float price = float.Parse(reader["Price"].ToString());
                string description = reader["Description"].ToString();
                int position = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                string image = reader["Image"].ToString();
                string author = reader["Author"].ToString();

                Book book = new Book(bookId,categoryId,title,isbn,year,price,description, position, status, image, author);
                bookList.Add(book);
            }
            conn.Close();
            return bookList;
        }

        public Book GetBookById(int id)
        {
            Book book=new Book();
            comm.CommandText = "select * from Books where BookId =" + id + ";";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["BookId"]);
                int categoryId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                float price = float.Parse(reader["Price"].ToString());
                string description = reader["Description"].ToString();
                int position = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                string image = reader["Image"].ToString();
                string author = reader["Author"].ToString();

                book = new Book(bookId, categoryId, title, isbn, year, price, description, position, status, image, author);

                               
            }
            
            conn.Close();
            return book;
         
        }

        public List<Book> GetBooksByCategory(int id)
        {
            List<Book> bookList = new List<Book>();
            comm.CommandText = "select * from Books where CategoryId =" + id + " and Status= 1 order by Position ;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["BookId"]);
                int categoryId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                float price = float.Parse(reader["Price"].ToString());
                string description = reader["Description"].ToString();
                int position = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                string image = reader["Image"].ToString();
                string author = reader["Author"].ToString();

                Book book = new Book(bookId, categoryId, title, isbn, year, price, description, position, status, image, author);
                bookList.Add(book);
            }
            conn.Close();
            return bookList;
        }

        public List<Book> SearchBooks(string type, string key)
        {
            //User can search for book by name / category / ISBN / Author
            List<Book> bookList = new List<Book>();
            comm.CommandText = "select b.BookId, b.CategoryId, b.Title, b.ISBN, b.Year, b.Price, b.Description, b.Position,b.Status,b.Image,b.Author,c.CategoryName from Books b inner join Category c on b.CategoryId=c.CategoryId  where " + type + " like '%" + key + "%' and b.Status = 1;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["BookId"]);
                int categoryId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                float price = float.Parse(reader["Price"].ToString());
                string description = reader["Description"].ToString();
                int position = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                string image = reader["Image"].ToString();
                string author = reader["Author"].ToString();

                Book book = new Book(bookId, categoryId, title, isbn, year, price, description, position, status, image, author);
                bookList.Add(book);
            }
            conn.Close();
            return bookList;
        }

        public List<Book> SearchAllBooks(string type, string key)
        {
            //User can search for book by name / category / ISBN / Author
            List<Book> bookList = new List<Book>();
            comm.CommandText = "select b.BookId, b.CategoryId, b.Title, b.ISBN, b.Year, b.Price, b.Description, b.Position,b.Status,b.Image,b.Author,c.CategoryName from Books b inner join Category c on b.CategoryId=c.CategoryId  where " + type + " like '%" + key + "%'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["BookId"]);
                int categoryId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                float price = float.Parse(reader["Price"].ToString());
                string description = reader["Description"].ToString();
                int position = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                string image = reader["Image"].ToString();
                string author = reader["Author"].ToString();

                Book book = new Book(bookId, categoryId, title, isbn, year, price, description, position, status, image, author);
                bookList.Add(book);
            }
            conn.Close();
            return bookList;
        }
    }
}