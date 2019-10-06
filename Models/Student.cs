using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.LibraryWebAPI.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public double FineAmount { get; set; } = 0;
        public IList<BookIssue> BookIssues { get; set; }
        public IList<BookReturn> BookReturns { get; set; }
    }
}
