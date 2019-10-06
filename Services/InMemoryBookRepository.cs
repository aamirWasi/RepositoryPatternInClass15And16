using Assignment5.LibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.LibraryWebAPI.Services
{
    public class InMemoryBookRepository : IBookInfoRepository
    {
        private readonly LibraryContext _libraryContext;

        public InMemoryBookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public Book AddBook(Book book)
        {
            var addedBook = _libraryContext.Add(book);
            Save();
            book.BookId = addedBook.Entity.BookId;
            return book;
        }
        public void Delete(Book book)
        {
            _libraryContext.Remove(book);
            Save();
        }

        public IEnumerable<Book> SearchAllBooks()
        {
            return _libraryContext.Books.ToList();
        }
        public Book SearchBookById(int id)
        {
            return _libraryContext.Books.FirstOrDefault(b => b.BookId == id);
        }
        public void Update(Book book)
        {
            var updatedBook = SearchBookById(book.BookId);
            updatedBook.Author = book.Author;
            updatedBook.Barcode = book.Barcode;
            updatedBook.CopyCount = book.CopyCount;
            updatedBook.Title = book.Title;
            updatedBook.Edition = book.Edition;
            updatedBook.BookIssuesByStudent = book.BookIssuesByStudent;
            updatedBook.CopyCount = book.CopyCount;
            _libraryContext.Update(updatedBook);
            Save();
        }
        private void Save()
        {
            _libraryContext.SaveChanges();
        }
    }
}
