using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment5.LibraryWebAPI.Models;
using Assignment5.LibraryWebAPI.Services;

namespace Assignment5.LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _context;

        public BooksController(IBookService context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _context.GetAllBooks();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _context.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            var updateNode = _context.GetBookById(id);
            if (updateNode == null)
                return NotFound();
            book.BookId = id;
            _context.PutBook(book);
            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            var addedBook = _context.CreateBook(book);
            //_context.Books.Add(book);
           // await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookId }, addedBook);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBook(int id)
        {
            var book = _context.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.DeleteBook(book);
            return NoContent();
        }

    }
}
