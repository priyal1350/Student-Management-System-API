using StudentManagement.Models;
using StudentManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task Add(Student student)
        {
            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding student: " + ex.Message);
            }
        }

        public async Task Update(Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.Id);

            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Email = student.Email;
                existingStudent.Age = student.Age;
                existingStudent.Course = student.Course;
                existingStudent.CreatedDate = student.CreatedDate;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}