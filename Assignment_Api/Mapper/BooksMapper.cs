using Assignment_Api.Models;
using System;

namespace Assignment_Api.Mapper
{
    public class BooksMapper : IBooksMapper
    {
        public Books Map(string authorName, string bookName)
        {
            return new Books()
            {
                Id = Guid.NewGuid(),
                AuthorName = authorName,
                BookName = bookName
            };
        }

        public Books Map(Guid id, string authorName, string bookName)
        {
            return new Books()
            {
                Id = id,
                AuthorName = authorName,
                BookName = bookName
            };
        }
    }
}