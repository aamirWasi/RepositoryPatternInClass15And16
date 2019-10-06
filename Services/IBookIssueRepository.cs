using Assignment5.LibraryWebAPI.Models;

namespace Assignment5.LibraryWebAPI.Services
{
    public interface IBookIssueRepository
    {
        BookIssue CreateBookIssue(BookIssue bookIssuebook);
        Book GetStock(Book book);
    }
}