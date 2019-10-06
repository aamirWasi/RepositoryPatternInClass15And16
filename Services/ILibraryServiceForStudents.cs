using System.Collections.Generic;
using Assignment5.LibraryWebAPI.Models;

namespace Assignment5.LibraryWebAPI.Services
{
    public interface ILibraryServiceForStudents
    {
        Student AddSingleStudent(Student student);
        void DeleteStudent(Student student);
        IEnumerable<Student> GetStudents();
        void UpdateStudent(Student student);
        Student GetStudentById(int id);
    }
}