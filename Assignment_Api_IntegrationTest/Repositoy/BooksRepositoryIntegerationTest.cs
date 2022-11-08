using Assignment_Api.Helper;
using Assignment_Api.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment_Api_IntegrationTest.Repositoy
{
    public class BooksRepositoryIntegerationTest
    {
        protected IConfiguration _configuration;
        private IDbConnection _connection;
        private BookingRepository bookingRepository;

        [SetUp]
        public void SetUp()
        {
            _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.development.json")
            .Build();
            _connection = new SqlConnection(
                    _configuration.GetConnectionString("WebApiDatabase"));
            bookingRepository = new BookingRepository(_configuration);
        }

        [Test]
        public void Should_Get_All_the_Books_from_Db_When_getAllBooks_method_is_called()
        {
            //act
            var res = bookingRepository.getAllBooks();

            //Assert
            Assert.AreEqual(res.Count, 4);
            Assert.AreEqual(res.FirstOrDefault(_ => _.AuthorName == "Karan").AuthorName, "Karan");

        }

        [Test]
        public void Should_Get_Book_Details_from_Db_When_getBookByID_method_is_called()
        {
            //act
            var res = bookingRepository.getBook("f3efbaa1-f3b1-46ab-aea2-190a46d4eb4b".GetGuid());

            //Assert
            Assert.AreEqual(res.AuthorName, "Karan");
            Assert.AreEqual(res.BookName, "Life is crazy");

        }

    }
}
