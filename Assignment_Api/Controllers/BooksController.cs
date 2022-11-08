using Assignment_Api.Exceptions;
using Assignment_Api.Helper;
using Assignment_Api.Mapper;
using Assignment_Api.Models;
using Assignment_Api.Service;
using Assignment_Api.Validator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IBooksMapper _booksMapper;
        private readonly IInputValidator _inputValidator;
        private List<string> input;
        private List<Error> errors = new List<Error>();

        public BooksController(IBookService bookService, IBooksMapper booksMapper, IInputValidator inputValidator)
        {
            _bookService = bookService;
            _booksMapper = booksMapper;
            _inputValidator = inputValidator;
        }

        // GET: api/<BooksController>
        [HttpGet]
        [Route("/GetAll")]
        public List<Books> Get()
        {
            return _bookService.getAllBooks();
        }

        // GET api/<BooksController>/5
        [HttpGet("/GetBookById/{id}")]
        public ActionResult<Books> Get(string id)
        {
            var isValidInput = _inputValidator.ValidateGuid(id, out errors);
            if (!isValidInput)
            {
                return BadRequest(errors);
            }

            var book = _bookService.getBook(id);

            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        [Route("/AddBook")]
        public ActionResult<Books> Post(string bookName, string authorName)
        {
            var books = new Books();
            input = new List<string>() { bookName, authorName };
            var isValid = _inputValidator.ValidatedName(input, out errors);
            if (!isValid)
            {
                return BadRequest(errors);
            }

            try
            {
                books = _booksMapper.Map(authorName, bookName);
                _bookService.addBooks(books);
            }
            catch
            {
                throw;
            }
            return Created("Record updated", books);
        }

        // PUT api/<BooksController>/5
        //This is was optoional and due to some time contraint I did not add the validations for these API just i m doing the basic check
        [HttpPut("/UpdateBookName/{id}")]
        public ActionResult UpdateBookName(string id, [FromBody] string bookName)
        {
            input = new List<string>() { bookName };
            var isValid = _inputValidator.ValidateGuid(id, out errors) && _inputValidator.ValidatedName(input, out errors);

            if (!isValid)
            {
                return BadRequest(errors);
            }
            var res = _bookService.getBook(id);
            if (res != null)
            {
                var books = _booksMapper.Map(id.GetGuid(), res.AuthorName, bookName);
                _bookService.updateBookName(books);
                return Ok();
            }
            return NotFound($"Book with {id} not found");
        }

        // PUT api/<BooksController>/5
        //This is was optional and due to some time contraint I did not add the validations for these API just I m doing the basic check
        [HttpPut("/UpdateAuthor/{id}")]
        public void UpdateAuthor(Guid id, [FromBody] string authorName)
        {
            var res = _bookService.getBook(id.GetString());
            if (res != null)
            {
                var books = _booksMapper.Map(id, authorName, res.BookName);
                _bookService.updateAuthor(books);
            }
        }

        // DELETE api/<BooksController>/5
        //This is was optoional and due to some time contraint I did not add the validations for these API just I m doing the basic check 
        [HttpDelete("/deleteBook/{id}")]
        public void Delete(Guid id)
        {
            var res = _bookService.getBook(id.GetString());
            if (res != null)
            {
                _bookService.delete(id);
            }
        }
    }
}