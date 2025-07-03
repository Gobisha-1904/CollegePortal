using CollegeERPPortal.Application.DTOs;
using CollegeERPPortal.Application.Interfaces;
using CollegeERPPortal.Domain.Entities;
using CollegeERPPortal.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class CourseService : ICourseService
{
    private readonly CollegeDbContext _context;

    public CourseService(CollegeDbContext context)
    {
        _context = context;
    }

    public async Task<List<CourseDto>> GetAllAsync()
    {
        return await _context.Courses
            .Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Duration = c.Duration
            })
            .ToListAsync();
    }

    public async Task<CourseDto> GetByIdAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return null;

        return new CourseDto
        {
            Id = course.Id,
            Name = course.Name,
            Duration = course.Duration
        };
    }

    public async Task AddAsync(CourseDto dto)
    {
        var course = new Course
        {
            Name = dto.Name,
            Duration = dto.Duration
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CourseDto dto)
    {
        var course = await _context.Courses.FindAsync(dto.Id);
        if (course != null)
        {
            course.Name = dto.Name;
            course.Duration = dto.Duration;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}
