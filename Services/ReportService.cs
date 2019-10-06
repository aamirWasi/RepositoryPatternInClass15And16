using Assignment5.LibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.LibraryWebAPI.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public double CheckFine(BookReturn bookReturn, BookIssue bookIssue, Student student)
        {
            var returnBook = _reportRepository.ReturnBook(bookReturn);
            var timeSpan = bookIssue.BookIssueDate - returnBook.BookReturingDate;
            var fine = student.FineAmount;
            if (timeSpan.Days > 7)
            {
                fine *= 10;
            }
            return fine;
        }
    }
}
