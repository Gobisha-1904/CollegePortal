using CollegeERPPortal.Application.DTOs;
using CollegeERPPortal.Application.Interfaces;
using CollegeERPPortal.Domain.Entities;
using CollegeERPPortal.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeERPPortal.Persistence.Repositories
{
    public class FacultyService : IFacultyService
    {
        private readonly CollegeDbContext _context;

        public FacultyService(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task<List<FacultyDto>> GetAllAsync()
        {
            return await _context.Faculties
                .Select(f => new FacultyDto
                {
                    Name = f.Name,
                    Department = f.Department,
                    Email = f.Email,
                    JoinDate = f.JoinDate
                })
                .ToListAsync();
        }

        public async Task AddAsync(FacultyDto dto)
        {
            var faculty = new Faculty
            {
                Name = dto.Name,
                Department = dto.Department,
                Email = dto.Email,
                JoinDate = dto.JoinDate
            };

            _context.Faculties.Add(faculty);
            await _context.SaveChangesAsync();
        }
    }
}
