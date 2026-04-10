using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // GET all students
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _service.GetStudents();
            return Ok(students);
        }

        // GET student by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _service.GetStudentById(id);
            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }
        [Authorize]
        // ADD student
        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            await _service.AddStudent(student);
            return Ok("Student added successfully");
        }
        [Authorize]
        // UPDATE student
        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            var existing = await _service.GetStudentById(student.Id);

            if (existing == null)
                return NotFound("Student not found");

            await _service.UpdateStudent(student);
            return Ok("Student updated successfully");
        }
        [Authorize]
        // DELETE student
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetStudentById(id);

            if (student == null)
                return NotFound("Student not found");

            await _service.DeleteStudent(id);
            return Ok("Deleted successfully");
        }
    }
}