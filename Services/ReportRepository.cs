using Assignment5.LibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.LibraryWebAPI.Services
{
    public class ReportRepository : IReportRepository
    {
        private readonly LibraryContext _libraryContext;

        public ReportRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public BookReturn ReturnBook(BookReturn bookReturn)
        {
            var returnBook = _libraryContext.Add(bookReturn);
            bookReturn.BookId = returnBook.Entity.BookId;
            bookReturn.Barcode = returnBook.Entity.Barcode;
            bookReturn.StudentId = returnBook.Entity.StudentId;
            bookReturn.BookReturingDate = returnBook.Entity.BookReturingDate.AddDays(7);
            ContextSaveChanges(_libraryContext);
            return bookReturn;
        }

        private void ContextSaveChanges(LibraryContext libraryContext)
        {
            libraryContext.SaveChanges();
        }
    }
}
