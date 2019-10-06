using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.LibraryWebAPI.Models
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookReturn>()
                .HasKey(br => new { br.Barcode, br.StudentId });
            builder.Entity<BookIssue>()
                .HasOne(bi => bi.Student)
                .WithMany(s => s.BookIssues)
                .HasForeignKey(bi => bi.StudentId);
            builder.Entity<BookReturn>()
                .HasOne(br => br.Student)
                .WithMany(s => s.BookReturns)
                .HasForeignKey(bi => bi.StudentId);
            base.OnModelCreating(builder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookIssue> BookIssues { get; set; }
        public DbSet<BookReturn> BookReturns { get; set; }
    }
}
