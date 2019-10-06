using System.Collections.Generic;
using Assignment5.LibraryWebAPI.Models;

namespace Assignment5.LibraryWebAPI.Services
{
    public interface IBookInfoRepository
    {
        BookIssue AddBook(BookIssue bookIssue);
        void Delete(Book book);
        IEnumerable<Book> SearchAllBooks();
        Book SearchBookById(int id);
        void Update(Book book);
    }
}