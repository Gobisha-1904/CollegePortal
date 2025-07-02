using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CollegeERPPortal.Application.DTOs;
using CollegeERPPortal.Application.Interfaces;
using CollegeERPPortal.Domain.Entities;
using CollegeERPPortal.Persistence.Context;

namespace CollegeERPPortal.Persistence.Repositories
{
    public class StudentService : IStudentService
    {
        private readonly CollegeDbContext _context;

        public StudentService(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Course = dto.Course,
                DOB = dto.DOB
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            return await _context.Students
                .Select(s => new StudentDto
                {
                    Name = s.Name,
                    Email = s.Email,
                    Course = s.Course,
                    DOB = s.DOB
                })
                .ToListAsync();
        }
    }
}
