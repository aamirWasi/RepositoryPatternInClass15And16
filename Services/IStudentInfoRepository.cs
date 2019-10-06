using System.Collections.Generic;
using Assignment5.LibraryWebAPI.Models;

namespace Assignment5.LibraryWebAPI.Services
{
    public interface IStudentInfoRepository
    {
        void Delete(Student student);
        IEnumerable<Student> SearchAllStudents();
        Student AddStudent(Student student);
        Student SearchStudentById(int id);
        void Update(Student student);
    }
}