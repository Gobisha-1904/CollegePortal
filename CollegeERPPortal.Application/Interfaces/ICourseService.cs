using System.Collections.Generic;
using System.Threading.Tasks;
using CollegeERPPortal.Application.DTOs;
public interface ICourseService
{
    Task<List<CourseDto>> GetAllAsync();
    Task<CourseDto> GetByIdAsync(int id);
    Task AddAsync(CourseDto dto);
    Task UpdateAsync(CourseDto dto);
    Task DeleteAsync(int id);
}
