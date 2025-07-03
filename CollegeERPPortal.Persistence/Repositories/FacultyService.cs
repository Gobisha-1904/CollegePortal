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
                    Id = f.Id, 
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
        // Persistence/Services/FacultyService.cs
        public async Task<FacultyDto> GetByIdAsync(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
                if (faculty == null)
                return null;
            return new FacultyDto
            {
                Id = faculty.Id,
                Name = faculty.Name,
                Email = faculty.Email,
                Department = faculty.Department,
                JoinDate = faculty.JoinDate
            };
        }
        public async Task UpdateAsync(FacultyDto dto)
        {
            var faculty = await _context.Faculties.FindAsync(dto.Id);
            if (faculty != null)
            {   
                faculty.Name = dto.Name;
                faculty.Email = dto.Email;
                faculty.Department = dto.Department;
                faculty.JoinDate = dto.JoinDate;

                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                await _context.SaveChangesAsync();
            }
        }


    }
}
