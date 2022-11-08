using Assignment_Api.Models;
using System;
using System.Collections.Generic;

namespace Assignment_Api.Repository
{
    public interface IBookingRepository
    {
        List<Books> getAllBooks();

        Books getBook(Guid id);

        void addBooks(Books books);

        void updateBookName(Books books);

        void updateAuthor(Books books);

        void delete(Guid id);
    }
}