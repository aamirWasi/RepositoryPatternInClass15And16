using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment5.LibraryWebAPI.Models;
using Assignment5.LibraryWebAPI.Services;

namespace Assignment5.LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILibraryServiceForStudents _context;

        public StudentsController(ILibraryServiceForStudents context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return _context.GetStudents();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _context.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }
            var updateNode = _context.GetStudentById(id);
            if (updateNode == null)
                return NotFound();
            student.StudentId = id;
            _context.UpdateStudent(student);
            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            var addedStudent = _context.AddSingleStudent(student);
            return CreatedAtAction("GetStudent", new { id = student.StudentId }, addedStudent);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.DeleteStudent(student);
            

            return NoContent();
        }
    }
}
