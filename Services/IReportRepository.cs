using Assignment5.LibraryWebAPI.Models;

namespace Assignment5.LibraryWebAPI.Services
{
    public interface IReportRepository
    {
        BookReturn ReturnBook(BookReturn bookReturn);
    }
}