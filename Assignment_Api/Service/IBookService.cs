using Assignment_Api.Models;
using System;
using System.Collections.Generic;

namespace Assignment_Api.Service
{
    public interface IBookService
    {
        List<Books> getAllBooks();

        Books getBook(string id);

        public void addBooks(Books books);

        public void updateBookName(Books books);

        public void updateAuthor(Books books);

        public void delete(Guid id);
    }
}