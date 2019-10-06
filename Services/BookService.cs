using Assignment5.LibraryWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assignment5.LibraryWebAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookInfoRepository _bookInfoRepository;

        public BookService(IBookInfoRepository bookInfoRepository)
        {
            _bookInfoRepository = bookInfoRepository;
        }
        public BookIssue CreateBook(BookIssue bookIssue)
        {

            return _bookInfoRepository.AddBook(bookIssue);
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _bookInfoRepository.SearchAllBooks().ToList();
        }
        public Book GetBookById(int id)
        {
            return _bookInfoRepository.SearchBookById(id);
        }
        public void DeleteBook(Book book)
        {
            _bookInfoRepository.Delete(book);
        }
        public void PutBook(Book book)
        {
            _bookInfoRepository.Update(book);
        }
    }
}
