using Assignment5.LibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.LibraryWebAPI.Services
{
    public class InMemoryBookIssueRepository : IBookIssueRepository
    {
        private readonly LibraryContext _libraryContext;

        public InMemoryBookIssueRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public void CreateBookIssue(BookIssue bookIssue)
        {
            var issueBook = _libraryContext.Add(bookIssue);
            bookIssue.Id = issueBook.Entity.BookId;
            bookIssue.Barcode = issueBook.Entity.Barcode;
            bookIssue.StudentId = issueBook.Entity.StudentId;
            bookIssue.BookIssueDate = issueBook.Entity.BookIssueDate;
            bookIssue.Book.CopyCount = issueBook.Entity.Book.CopyCount;
            Save();
        }

        public Book GetStock(Book book)
        {
            return book;
        }

        BookIssue IBookIssueRepository.CreateBookIssue(BookIssue bookIssue)
        {
            throw new NotImplementedException();
        }

        private void Save()
        {
            _libraryContext.SaveChanges();
        }
    }
}
