using System.Collections.Generic;
using Assignment5.LibraryWebAPI.Models;

namespace Assignment5.LibraryWebAPI.Services
{
    public interface IBookService
    {
        BookIssue CreateBook(BookIssue bookIssue);
        void DeleteBook(Book book);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void PutBook(Book book);
    }
}