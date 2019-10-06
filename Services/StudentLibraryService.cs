using Assignment5.LibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.LibraryWebAPI.Services
{
    public class StudentLibraryService : ILibraryServiceForStudents
    {
        private readonly IStudentInfoRepository _studentRepository;

        public StudentLibraryService(IStudentInfoRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.SearchAllStudents();
        }
        public Student GetStudentById(int id)
        {
            return _studentRepository.SearchStudentById(id);
        }
        public Student AddSingleStudent(Student student)
        {
            return _studentRepository.AddStudent(student);
        }
        public void DeleteStudent(Student student)
        {
            _studentRepository.Delete(student);
        }
        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }
    }
}
