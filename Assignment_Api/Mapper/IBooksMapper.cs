using Assignment_Api.Models;
using System;

namespace Assignment_Api.Mapper
{
    public interface IBooksMapper
    {
        public Books Map(string authorName, string bookName);

        public Books Map(Guid id, string authorName, string bookName);
    }
}