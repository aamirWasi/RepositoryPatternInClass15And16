using Assignment5.LibraryWebAPI.Models;
using System.Collections.Generic;

namespace Assignment5.LibraryWebAPI.Services
{
    public interface IBookIssueService
    {
        IEnumerable<BookIssue> GetIssueBook(BookIssue bookIssue);
        void StockBook(Book book,int quantity);
    }
}