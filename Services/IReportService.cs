using Assignment5.LibraryWebAPI.Models;

namespace Assignment5.LibraryWebAPI.Services
{
    public interface IReportService
    {
        double CheckFine(BookReturn bookReturn, BookIssue bookIssue, Student student);
    }
}