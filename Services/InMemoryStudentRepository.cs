using Assignment5.LibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.LibraryWebAPI.Services
{
    public class InMemoryStudentRepository : IStudentInfoRepository
    {
        private readonly LibraryContext _libraryContext;

        public InMemoryStudentRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public Student AddStudent(Student student)
        {
            var addStudent = _libraryContext.Add(student);
            ContextSvaeChanges(_libraryContext);
            student.StudentId = addStudent.Entity.StudentId;
            return student;
        }
        public void Delete(Student student)
        {
            _libraryContext.Remove(student);
            ContextSvaeChanges(_libraryContext);
        }
        public IEnumerable<Student> SearchAllStudents()
        {
            return _libraryContext.Students.ToList();
        }
        public Student SearchStudentById(int id)
        {
            return _libraryContext.Students.FirstOrDefault(s => s.StudentId == id);
        }
        public void Update(Student student)
        {
            var updatedstudent = SearchStudentById(student.StudentId);
            updatedstudent.Name = student.Name;
            updatedstudent.FineAmount = student.FineAmount;
            updatedstudent.BookIssues = student.BookIssues;
            updatedstudent.BookReturns = student.BookReturns;
            _libraryContext.Update(updatedstudent);
            ContextSvaeChanges(_libraryContext);
        }
        private void ContextSvaeChanges(LibraryContext libraryContext)
        {
            libraryContext.SaveChanges();
        }
    }
}
