using System;
using System.Collections.Generic;
using Assignment5.LibraryWebAPI.Models;

namespace Assignment5.LibraryWebAPI.Services
{
    public class BookIssueService : IBookIssueService
    {
        private readonly IBookIssueRepository _bookIssueRepository;

        public BookIssueService(IBookIssueRepository bookIssueRepository)
        {
            _bookIssueRepository = bookIssueRepository;
        }
        public IEnumerable<BookIssue> GetIssueBook(BookIssue bookIssue)
        {
            yield return _bookIssueRepository.CreateBookIssue(bookIssue);
        }

        public void StockBook(Book book, int quantity)
        {
            var stock = _bookIssueRepository.GetStock(book);
            if (stock.CopyCount >= quantity)
                stock.CopyCount -= quantity;
            else
            {
                throw new InvalidOperationException("Quantity is greater than available Books");
            }
        }
    }
}
