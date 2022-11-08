using Assignment_Api.Helper;
using Assignment_Api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Assignment_Api.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        public BookingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(
                    _configuration.GetConnectionString("WebApiDatabase"));
        }

        public List<Books> getAllBooks()
        {
            var books = new List<Books>();
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                conn.Open();
                string commandtext = "SELECT * FROM Books";

                SqlCommand cmd = new SqlCommand(commandtext, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var book = new Books()
                    {
                        AuthorName = reader["AuthorName"].ToString(),
                        BookName = reader["BookName"].ToString(),
                        Id = reader["Id"].ToString().GetGuid()
                    };
                    books.Add(book);
                }
            }
            return books;
        }

        public Books getBook(Guid id)
        {
            var books = new List<Books>();
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                conn.Open();
                string commandtext = $"SELECT * FROM Books where id='{id}'";

                SqlCommand cmd = new SqlCommand(commandtext, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var book = new Books()
                    {
                        AuthorName = reader["AuthorName"].ToString(),
                        BookName = reader["BookName"].ToString(),
                        Id = reader["Id"].ToString().GetGuid()
                    };
                    books.Add(book);
                }
            }
            return books.FirstOrDefault();
        }

        public void addBooks(Books books)
        {
            var bookList = new List<Books>();
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                conn.Open();
                string commandtext = $"Insert into books VALUES ('{books.Id}','{books.BookName}','{books.AuthorName}')";

                SqlCommand cmd = new SqlCommand(commandtext, conn);

                var reader = cmd.ExecuteReader();
            }
        }

        public void updateBookName(Books books)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                conn.Open();
                string commandtext = $"Update books set BookName = '{books.BookName}' where Id = '{books.Id}'";

                SqlCommand cmd = new SqlCommand(commandtext, conn);

                var reader = cmd.ExecuteReader();
            }
        }

        public void updateAuthor(Books books)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                conn.Open();
                string commandtext = $"Update books set AuthorName = '{books.AuthorName}' where Id = '{books.Id}'";

                SqlCommand cmd = new SqlCommand(commandtext, conn);

                var reader = cmd.ExecuteReader();
            }
        }

        public void delete(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                conn.Open();
                string commandtext = $"delete from books where Id = '{id}'";

                SqlCommand cmd = new SqlCommand(commandtext, conn);

                var reader = cmd.ExecuteReader();
            }
        }
    }
}