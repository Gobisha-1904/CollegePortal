using System.Collections.Generic;
using System.Threading.Tasks;
using CollegeERPPortal.Application.DTOs;

namespace CollegeERPPortal.Application.Interfaces
{
    public interface IFacultyService
    {        Task<List<FacultyDto>> GetAllAsync();
        Task AddAsync(FacultyDto dto);
        Task<FacultyDto> GetByIdAsync(int id);
        Task UpdateAsync(FacultyDto facultyDto);
        Task DeleteAsync(int id);
}
}
