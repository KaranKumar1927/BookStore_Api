using Assignment_Api.Helper;
using Assignment_Api.Models;
using Assignment_Api.Repository;
using System;
using System.Collections.Generic;

namespace Assignment_Api.Service
{
    public class BookService : IBookService
    {
        private readonly IBookingRepository _bookRepository;

        public BookService(IBookingRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Books> getAllBooks()
        {
            try
            {
                return _bookRepository.getAllBooks();

            }
            catch
            {
                throw;
            }
           
        }

        public Books getBook(string id)
        {
            try
            { return _bookRepository.getBook(id.GetGuid()); }
            catch
            {
                throw;
            }
                
        }

        public void addBooks(Books books)
        {
            try
            {
                _bookRepository.addBooks(books);
            }
            catch 
            {
                throw;
            }
        }

        public void updateBookName(Books books)
        {
            try
            {
                _bookRepository.updateBookName(books);
            }
            catch
            {
                throw;
            }
            
        }

        public void updateAuthor(Books books)
        {
            try
            {
                _bookRepository.updateAuthor(books);
            }
            catch
            {
                throw;
            }
           
        }

        public void delete(Guid id)
        {
            try
            {
                _bookRepository.delete(id);
            }
            catch {
                throw;
            }   
            
        }
    }
}