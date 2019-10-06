using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.LibraryWebAPI.Models
{
    public class BookReturn
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public DateTime BookReturingDate { get; set; }
        public string Barcode { get; set; }
    }
}
